using Microsoft.EntityFrameworkCore;
using NexUs.Data;
using NexUs.Models.Entities;
using NexUs.Services.Interfaces;
using NexUs.Utilities;

namespace NexUs.Services
{
    public class CampaignSenderBackgroundService : BackgroundService
    {
        private readonly IServiceScopeFactory _scopeFactory;
        private readonly ILogger<CampaignSenderBackgroundService> _logger;
        private readonly TimeSpan _interval = TimeSpan.FromMinutes(2);

        public CampaignSenderBackgroundService(
            IServiceScopeFactory scopeFactory,
            ILogger<CampaignSenderBackgroundService> logger)
        {
            _scopeFactory = scopeFactory;
            _logger = logger;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            _logger.LogInformation("CampaignSenderBackgroundService started.");

            while (!stoppingToken.IsCancellationRequested)
            {
                try
                {
                    await ProcessAsync(stoppingToken);
                }
                catch (Exception ex)
                {
                    _logger.LogError(ex, "CampaignSenderBackgroundService encountered an error.");
                }

                await Task.Delay(_interval, stoppingToken);
            }
        }

        private async Task ProcessAsync(CancellationToken ct)
        {
            using var scope = _scopeFactory.CreateScope();
            var context = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();
            var marketingEmailService = scope.ServiceProvider.GetRequiredService<IMarketingEmailService>();
            var suppressionService = scope.ServiceProvider.GetRequiredService<ISuppressionService>();
            var emailTemplateService = scope.ServiceProvider.GetRequiredService<IEmailTemplateService>();

            var now = DateTimeHelper.PhilippineNow;

            // 1. Queue email_messages for campaigns ready to send:
            //    - "Scheduled" campaigns whose ScheduledAt has passed
            //    - "Sending" campaigns that still have Queued targets but no active messages yet
            //      (covers campaigns started immediately via "Send Now")
            var campaignsToProcess = await context.Campaigns
                .Where(c => c.DeletedAt == null &&
                    ((c.Status == "Scheduled" && c.ScheduledAt <= now) ||
                     (c.Status == "Sending" && !context.EmailMessages
                         .Any(m => m.CampaignId == c.Id && (m.Status == "Queued" || m.Status == "Sending")))))
                .ToListAsync(ct);

            foreach (var campaign in campaignsToProcess)
            {
                // Build email_messages for each queued target
                var queuedTargets = await context.CampaignTargets
                    .Where(t => t.CampaignId == campaign.Id && t.Status == "Queued")
                    .ToListAsync(ct);

                // Resolve template once per campaign
                EmailTemplate? template = campaign.EmailTemplateId.HasValue
                    ? await context.EmailTemplates.FindAsync(campaign.EmailTemplateId.Value)
                    : null;

                foreach (var target in queuedTargets)
                {
                    // Re-check suppression at send time
                    var suppressed = await suppressionService.IsSuppressedAsync(target.Email);
                    if (suppressed)
                    {
                        target.Status = "Suppressed";
                        target.UpdatedAt = now;
                        campaign.SuppressedCount++;
                        continue;
                    }

                    // Subject: campaign override takes priority, otherwise template subject
                    string subject = !string.IsNullOrEmpty(campaign.Subject)
                        ? campaign.Subject
                        : (template?.Subject ?? "");
                    string body = $"[Template:{template?.FileName ?? ""}]";

                    var message = new EmailMessage
                    {
                        CampaignId = campaign.Id,
                        EmailTemplateId = campaign.EmailTemplateId,
                        RecipientUserId = target.UserId,
                        RecipientEmail = target.Email,
                        RecipientName = $"{target.FirstName} {target.LastName}".Trim(),
                        Subject = subject,
                        Body = body,
                        Status = "Queued",
                        QueuedAt = now,
                        CreatedAt = now,
                        UpdatedAt = now
                    };
                    context.EmailMessages.Add(message);
                    target.Status = "Sending";
                    target.UpdatedAt = now;
                }

                campaign.Status = "Sending";
                campaign.UpdatedAt = now;
                await context.SaveChangesAsync(ct);
            }

            // 2. Process Queued email_messages
            var queuedMessages = await context.EmailMessages
                .Where(m => m.Status == "Queued")
                .OrderBy(m => m.QueuedAt)
                .Take(50) // Process up to 50 per cycle to avoid timeouts
                .ToListAsync(ct);

            foreach (var msg in queuedMessages)
            {
                if (ct.IsCancellationRequested) break;
                await marketingEmailService.SendAsync(msg.Id);

                // If campaign message, update counters.
                // SendAsync uses its own DbContext scope, so the outer context still
                // has msg tracked with the old Status. Reload from DB to get the real status.
                if (msg.CampaignId.HasValue)
                {
                    var campaign = await context.Campaigns.FindAsync(msg.CampaignId.Value);
                    if (campaign != null)
                    {
                        var latestStatus = await context.EmailMessages
                            .AsNoTracking()
                            .Where(m => m.Id == msg.Id)
                            .Select(m => m.Status)
                            .FirstOrDefaultAsync(ct);

                        if (latestStatus == "Sent") campaign.SentCount++;
                        else if (latestStatus == "Failed") campaign.FailedCount++;
                        campaign.UpdatedAt = now;
                        await context.SaveChangesAsync(ct);
                    }
                }
            }

            // 3. Mark Sending campaigns as Sent when all messages are processed
            var sendingCampaigns = await context.Campaigns
                .Where(c => c.Status == "Sending" && c.DeletedAt == null)
                .ToListAsync(ct);

            foreach (var campaign in sendingCampaigns)
            {
                var hasQueued = await context.EmailMessages
                    .AnyAsync(m => m.CampaignId == campaign.Id && (m.Status == "Queued" || m.Status == "Sending"), ct);

                if (!hasQueued)
                {
                    campaign.Status = "Sent";
                    campaign.SentAt = now;
                    campaign.UpdatedAt = now;
                }
            }

            await context.SaveChangesAsync(ct);
        }
    }
}
