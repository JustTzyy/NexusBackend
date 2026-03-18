using System.Security.Cryptography;
using System.Text;
using System.Text.Json;
using Microsoft.EntityFrameworkCore;
using NexUs.Data;
using NexUs.Models.Entities;
using NexUs.Services.Interfaces;
using NexUs.Utilities;
using MailKit.Net.Smtp;
using MimeKit;
using MailKit.Security;

namespace NexUs.Services
{
    public class MarketingEmailService : IMarketingEmailService
    {
        private readonly IServiceScopeFactory _scopeFactory;
        private readonly IConfiguration _configuration;
        private readonly IWebHostEnvironment _env;
        private readonly ILogger<MarketingEmailService> _logger;

        public MarketingEmailService(
            IServiceScopeFactory scopeFactory,
            IConfiguration configuration,
            IWebHostEnvironment env,
            ILogger<MarketingEmailService> logger)
        {
            _scopeFactory = scopeFactory;
            _configuration = configuration;
            _env = env;
            _logger = logger;
        }

        public async Task<bool> SendAsync(int emailMessageId)
        {
            // Each send gets its own isolated DbContext so it never conflicts with
            // the caller's scope (AutomationService, CampaignSenderBackgroundService, etc.)
            using var scope = _scopeFactory.CreateScope();
            var context = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();

            var message = await context.EmailMessages
                .Include(m => m.EmailTemplate)
                .FirstOrDefaultAsync(m => m.Id == emailMessageId);

            if (message == null) return false;
            if (message.Status != "Queued") return false;

            // Atomically claim the message: only the first caller to succeed the
            // Queued→Sending update will proceed. This prevents a race between
            // TriggerAndSendImmediatelyAsync and CampaignSenderBackgroundService
            // both picking up the same Queued message (e.g. OTP emails).
            var claimed = await context.EmailMessages
                .Where(m => m.Id == emailMessageId && m.Status == "Queued")
                .ExecuteUpdateAsync(s => s
                    .SetProperty(m => m.Status, "Sending")
                    .SetProperty(m => m.UpdatedAt, DateTimeHelper.PhilippineNow));
            if (claimed == 0) return false;

            // Detach tracked entity so SaveChanges only writes the EmailEvent,
            // not a redundant re-UPDATE of the message row.
            context.Entry(message).State = EntityState.Detached;
            message.Status = "Sending";

            await AppendEventAsync(context, message.Id, "Sending", null);

            try
            {
                // Render body if it's a template reference (format: [Template:filename.html])
                string htmlBody = message.Body;
                if (message.Body.StartsWith("[Template:") && message.EmailTemplate != null)
                {
                    // Prefer DB body; fall back to file for templates not yet migrated
                    string? templateHtml = message.EmailTemplate.Body;
                    if (string.IsNullOrEmpty(templateHtml))
                    {
                        var filePath = Path.Combine(_env.ContentRootPath, "Templates", "Email", message.EmailTemplate.FileName);
                        if (File.Exists(filePath))
                            templateHtml = await File.ReadAllTextAsync(filePath);
                    }
                    if (!string.IsNullOrEmpty(templateHtml))
                    {
                        htmlBody = templateHtml;
                        var frontendUrl = _configuration["ApplicationSettings:FrontendUrl"] ?? "";
                        var unsubscribeEmail = message.RecipientEmail ?? "";
                        var unsubscribeSecret = _configuration["ApplicationSettings:UnsubscribeSecret"] ?? "nexus-unsubscribe-secret";
                        var unsubscribeToken = ComputeHmac(unsubscribeEmail, unsubscribeSecret);
                        var unsubscribeUrl = $"{frontendUrl}/unsubscribe?email={Uri.EscapeDataString(unsubscribeEmail)}&token={Uri.EscapeDataString(unsubscribeToken)}";
                        // Replace all template tokens
                        htmlBody = htmlBody
                            .Replace("{{RecipientName}}", message.RecipientName ?? "")
                            .Replace("{{FirstName}}", message.RecipientName?.Split(' ').FirstOrDefault() ?? "")
                            .Replace("{{CompanyName}}", _configuration["ApplicationSettings:CompanyName"] ?? "NexUs")
                            .Replace("{{Year}}", DateTime.UtcNow.Year.ToString())
                            .Replace("{{LoginUrl}}", _configuration["ApplicationSettings:LoginUrl"] ?? "")
                            .Replace("{{UnsubscribeUrl}}", unsubscribeUrl)
                            .Replace("{{CampaignSubject}}", message.Subject ?? "");

                        // Apply per-email custom token variables (e.g. OtpCode, ResetLink, SubjectName…)
                        if (!string.IsNullOrEmpty(message.VariablesJson))
                        {
                            var vars = JsonSerializer.Deserialize<Dictionary<string, string>>(message.VariablesJson);
                            if (vars != null)
                                foreach (var (key, value) in vars)
                                    htmlBody = htmlBody.Replace($"{{{{{key}}}}}", value ?? "");
                        }
                    }
                }

                // Read SMTP settings
                var smtpHost = _configuration["EmailSettings:SmtpHost"];
                var smtpPort = int.Parse(_configuration["EmailSettings:SmtpPort"] ?? "587");
                var senderEmail = _configuration["EmailSettings:SenderEmail"];
                var senderName = _configuration["EmailSettings:SenderName"];
                var senderPassword = _configuration["EmailSettings:SenderPassword"];

                if (string.IsNullOrEmpty(smtpHost) || string.IsNullOrEmpty(senderEmail) || string.IsNullOrEmpty(senderPassword))
                {
                    throw new InvalidOperationException("Email configuration is incomplete.");
                }

                var mimeMessage = new MimeMessage();
                mimeMessage.From.Add(new MailboxAddress(senderName, senderEmail));
                mimeMessage.To.Add(new MailboxAddress(message.RecipientName, message.RecipientEmail));

                // Resolve any tokens in the subject line
                var resolvedSubject = (message.Subject ?? "")
                    .Replace("{{CompanyName}}", _configuration["ApplicationSettings:CompanyName"] ?? "NexUs")
                    .Replace("{{Year}}", DateTime.UtcNow.Year.ToString());
                if (!string.IsNullOrEmpty(message.VariablesJson))
                {
                    var subjectVars = JsonSerializer.Deserialize<Dictionary<string, string>>(message.VariablesJson);
                    if (subjectVars != null)
                        foreach (var (key, value) in subjectVars)
                            resolvedSubject = resolvedSubject.Replace($"{{{{{key}}}}}", value ?? "");
                }
                mimeMessage.Subject = resolvedSubject;
                mimeMessage.Body = new BodyBuilder { HtmlBody = htmlBody }.ToMessageBody();

                using var client = new SmtpClient();
                await client.ConnectAsync(smtpHost, smtpPort, SecureSocketOptions.StartTls);
                await client.AuthenticateAsync(senderEmail, senderPassword);
                await client.SendAsync(mimeMessage);
                await client.DisconnectAsync(true);

                var sentAt = DateTimeHelper.PhilippineNow;
                await context.EmailMessages
                    .Where(m => m.Id == emailMessageId)
                    .ExecuteUpdateAsync(s => s
                        .SetProperty(m => m.Status, "Sent")
                        .SetProperty(m => m.SentAt, sentAt)
                        .SetProperty(m => m.UpdatedAt, sentAt));
                await AppendEventAsync(context, message.Id, "Sent", null);

                return true;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Failed to send email message {Id} to {Email}", message.Id, message.RecipientEmail);

                var retryCount = message.RetryCount + 1;
                var failedAt = DateTimeHelper.PhilippineNow;

                if (retryCount < 3)
                {
                    await context.EmailMessages
                        .Where(m => m.Id == emailMessageId)
                        .ExecuteUpdateAsync(s => s
                            .SetProperty(m => m.Status, "Queued")
                            .SetProperty(m => m.RetryCount, retryCount)
                            .SetProperty(m => m.UpdatedAt, failedAt));
                    await AppendEventAsync(context, message.Id, "Retrying", $"Attempt {retryCount}: {ex.Message}");
                }
                else
                {
                    var errorMsg = ex.Message.Length > 1000 ? ex.Message[..1000] : ex.Message;
                    await context.EmailMessages
                        .Where(m => m.Id == emailMessageId)
                        .ExecuteUpdateAsync(s => s
                            .SetProperty(m => m.Status, "Failed")
                            .SetProperty(m => m.RetryCount, retryCount)
                            .SetProperty(m => m.FailedAt, failedAt)
                            .SetProperty(m => m.ErrorMessage, errorMsg)
                            .SetProperty(m => m.UpdatedAt, failedAt));
                    await AppendEventAsync(context, message.Id, "Failed", errorMsg);

                    // Auto-suppress the address after exhausting all retries — treat it as a bounce.
                    // Future campaigns and automations will automatically skip this address.
                    if (!string.IsNullOrEmpty(message.RecipientEmail))
                    {
                        try
                        {
                            var suppressionService = scope.ServiceProvider.GetRequiredService<ISuppressionService>();
                            await suppressionService.EnsureSuppressedAsync(message.RecipientEmail, "Bounced", "System");
                            _logger.LogInformation("Auto-suppressed bounced address {Email} after {Retries} failed attempts.", message.RecipientEmail, retryCount);
                        }
                        catch (Exception suppressEx)
                        {
                            _logger.LogWarning(suppressEx, "Failed to auto-suppress bounced address {Email}.", message.RecipientEmail);
                        }
                    }
                }

                return false;
            }
        }

        private static string ComputeHmac(string data, string key)
        {
            using var hmac = new HMACSHA256(Encoding.UTF8.GetBytes(key));
            return Convert.ToHexString(hmac.ComputeHash(Encoding.UTF8.GetBytes(data))).ToLower();
        }

        private static async Task AppendEventAsync(ApplicationDbContext context, int emailMessageId, string eventType, string? notes)
        {
            var now = DateTimeHelper.PhilippineNow;
            context.EmailEvents.Add(new EmailEvent
            {
                EmailMessageId = emailMessageId,
                EventType = eventType,
                Notes = notes,
                OccurredAt = now,
                CreatedAt = now
            });
            await context.SaveChangesAsync();
        }
    }
}
