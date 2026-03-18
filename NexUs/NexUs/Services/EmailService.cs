using NexUs.Services.Interfaces;
using NexUs.Data;
using NexUs.Models.Entities;
using NexUs.Utilities;
using MailKit.Net.Smtp;
using MimeKit;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using MailKit.Security;

namespace NexUs.Services
{
    public class EmailService : IEmailService
    {
        private readonly IConfiguration _configuration;
        private readonly ILogger<EmailService> _logger;
        private readonly string _templatePath;
        private readonly ApplicationDbContext _context;

        public EmailService(IConfiguration configuration, ILogger<EmailService> logger, IWebHostEnvironment env, ApplicationDbContext context)
        {
            _configuration = configuration;
            _logger = logger;
            _templatePath = Path.Combine(env.ContentRootPath, "Templates", "Email", "WelcomeEmailTemplate.html");
            _context = context;
        }

        // Saves a record to EmailMessages so every sent email appears in email logs
        private async Task LogEmailAsync(string recipientEmail, string recipientName, string subject, int emailTemplateId, string templateFileName, string status, string? errorMessage = null)
        {
            var now = DateTimeHelper.PhilippineNow;
            _context.EmailMessages.Add(new EmailMessage
            {
                RecipientEmail = recipientEmail,
                RecipientName = recipientName,
                Subject = subject,
                Body = $"[Template:{templateFileName}]",
                EmailTemplateId = emailTemplateId,
                Status = status,
                SentAt = status == "Sent" ? now : null,
                FailedAt = status == "Failed" ? now : null,
                ErrorMessage = errorMessage,
                CreatedAt = now,
                UpdatedAt = now
            });
            await _context.SaveChangesAsync();
        }

        public async Task<bool> SendWelcomeEmailAsync(string userEmail, string userName, string defaultPassword, List<string> roles)
        {
            try
            {
                // Read email settings from configuration
                var provider = _configuration["EmailSettings:Provider"];
                var smtpHost = _configuration["EmailSettings:SmtpHost"];
                var smtpPort = int.Parse(_configuration["EmailSettings:SmtpPort"] ?? "587");
                var senderEmail = _configuration["EmailSettings:SenderEmail"];
                var senderName = _configuration["EmailSettings:SenderName"];
                var senderPassword = _configuration["EmailSettings:SenderPassword"];
                var enableSsl = bool.Parse(_configuration["EmailSettings:EnableSsl"] ?? "true");

                var loginUrl = _configuration["ApplicationSettings:LoginUrl"];
                var companyName = _configuration["ApplicationSettings:CompanyName"];

                // Validate configuration
                if (string.IsNullOrEmpty(smtpHost) || string.IsNullOrEmpty(senderEmail) || string.IsNullOrEmpty(senderPassword))
                {
                    _logger.LogError("Email configuration is incomplete. Please check appsettings.json");
                    return false;
                }

                // Read email template
                if (!File.Exists(_templatePath))
                {
                    _logger.LogError($"Email template not found at: {_templatePath}");
                    return false;
                }

                string emailTemplate = await File.ReadAllTextAsync(_templatePath);

                // Replace placeholders
                var emailBody = emailTemplate
                    .Replace("{{UserName}}", userName)
                    .Replace("{{Email}}", userEmail)
                    .Replace("{{DefaultPassword}}", defaultPassword)
                    .Replace("{{Roles}}", string.Join(", ", roles))
                    .Replace("{{LoginUrl}}", loginUrl)
                    .Replace("{{CompanyName}}", companyName)
                    .Replace("{{Year}}", DateTime.UtcNow.Year.ToString());

                // Create email message
                var message = new MimeMessage();
                message.From.Add(new MailboxAddress(senderName, senderEmail));
                message.To.Add(new MailboxAddress(userName, userEmail));
                message.Subject = $"Welcome to {companyName} - Your Account Details";

                var bodyBuilder = new BodyBuilder
                {
                    HtmlBody = emailBody
                };
                message.Body = bodyBuilder.ToMessageBody();

                // Send email via SMTP
                using (var client = new SmtpClient())
                {
                    // Retry logic for transient failures
                    int maxRetries = 3;
                    for (int i = 0; i < maxRetries; i++)
                    {
                        try
                        {
                            // Use StartTls for port 587, SslOnConnect for port 465, or Auto for others
                            var socketOptions = smtpPort == 587 ? SecureSocketOptions.StartTls : 
                                              smtpPort == 465 ? SecureSocketOptions.SslOnConnect : 
                                              SecureSocketOptions.Auto;

                            await client.ConnectAsync(smtpHost, smtpPort, socketOptions);
                            await client.AuthenticateAsync(senderEmail, senderPassword);
                            await client.SendAsync(message);
                            await client.DisconnectAsync(true);

                            _logger.LogInformation($"Welcome email sent successfully to {userEmail}");
                            await LogEmailAsync(userEmail, userName, $"Welcome to {companyName} - Your Account Details", 11, "WelcomeEmailTemplate.html", "Sent");
                            return true;
                        }
                        catch (Exception ex) when (i < maxRetries - 1)
                        {
                            _logger.LogWarning($"Email send attempt {i + 1} failed: {ex.Message}. Retrying...");
                            await Task.Delay(1000 * (i + 1)); // Exponential backoff
                        }
                    }
                }

                return false;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Failed to send welcome email to {userEmail}");
                await LogEmailAsync(userEmail, userName, $"Welcome to {_configuration["ApplicationSettings:CompanyName"]} - Your Account Details", 11, "WelcomeEmailTemplate.html", "Failed", ex.Message);
                return false;
            }
        }

        public async Task<bool> SendPasswordResetEmailAsync(string userEmail, string userName, string resetLink)
        {
            try
            {
                var smtpHost = _configuration["EmailSettings:SmtpHost"];
                var smtpPort = int.Parse(_configuration["EmailSettings:SmtpPort"] ?? "587");
                var senderEmail = _configuration["EmailSettings:SenderEmail"];
                var senderName = _configuration["EmailSettings:SenderName"];
                var senderPassword = _configuration["EmailSettings:SenderPassword"];
                var companyName = _configuration["ApplicationSettings:CompanyName"];

                if (string.IsNullOrEmpty(smtpHost) || string.IsNullOrEmpty(senderEmail) || string.IsNullOrEmpty(senderPassword))
                {
                    _logger.LogError("Email configuration is incomplete for password reset email");
                    return false;
                }

                // Read password reset template
                var resetTemplatePath = Path.Combine(Path.GetDirectoryName(_templatePath)!, "PasswordResetEmailTemplate.html");
                if (!File.Exists(resetTemplatePath))
                {
                    _logger.LogError($"Password reset email template not found at: {resetTemplatePath}");
                    return false;
                }

                string emailTemplate = await File.ReadAllTextAsync(resetTemplatePath);

                var emailBody = emailTemplate
                    .Replace("{{UserName}}", userName)
                    .Replace("{{ResetLink}}", resetLink)
                    .Replace("{{CompanyName}}", companyName)
                    .Replace("{{Year}}", DateTime.UtcNow.Year.ToString());

                var message = new MimeMessage();
                message.From.Add(new MailboxAddress(senderName, senderEmail));
                message.To.Add(new MailboxAddress(userName, userEmail));
                message.Subject = $"Reset Your Password - {companyName}";

                var bodyBuilder = new BodyBuilder { HtmlBody = emailBody };
                message.Body = bodyBuilder.ToMessageBody();

                using (var client = new SmtpClient())
                {
                    var socketOptions = smtpPort == 587 ? SecureSocketOptions.StartTls :
                                      smtpPort == 465 ? SecureSocketOptions.SslOnConnect :
                                      SecureSocketOptions.Auto;

                    await client.ConnectAsync(smtpHost, smtpPort, socketOptions);
                    await client.AuthenticateAsync(senderEmail, senderPassword);
                    await client.SendAsync(message);
                    await client.DisconnectAsync(true);

                    _logger.LogInformation($"Password reset email sent to {userEmail}");
                    await LogEmailAsync(userEmail, userName, $"Reset Your Password - {companyName}", 6, "PasswordResetEmailTemplate.html", "Sent");
                    return true;
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Failed to send password reset email to {userEmail}");
                await LogEmailAsync(userEmail, userName, $"Reset Your Password - {_configuration["ApplicationSettings:CompanyName"]}", 6, "PasswordResetEmailTemplate.html", "Failed", ex.Message);
                return false;
            }
        }

        public async Task<bool> SendOtpVerificationEmailAsync(string userEmail, string otpCode)
        {
            try
            {
                var smtpHost = _configuration["EmailSettings:SmtpHost"];
                var smtpPort = int.Parse(_configuration["EmailSettings:SmtpPort"] ?? "587");
                var senderEmail = _configuration["EmailSettings:SenderEmail"];
                var senderName = _configuration["EmailSettings:SenderName"];
                var senderPassword = _configuration["EmailSettings:SenderPassword"];
                var companyName = _configuration["ApplicationSettings:CompanyName"];

                if (string.IsNullOrEmpty(smtpHost) || string.IsNullOrEmpty(senderEmail) || string.IsNullOrEmpty(senderPassword))
                {
                    _logger.LogError("Email configuration is incomplete for OTP verification email");
                    return false;
                }

                var otpTemplatePath = Path.Combine(Path.GetDirectoryName(_templatePath)!, "OtpVerificationEmailTemplate.html");
                if (!File.Exists(otpTemplatePath))
                {
                    _logger.LogError($"OTP verification email template not found at: {otpTemplatePath}");
                    return false;
                }

                string emailTemplate = await File.ReadAllTextAsync(otpTemplatePath);

                var emailBody = emailTemplate
                    .Replace("{{UserEmail}}", userEmail)
                    .Replace("{{OtpCode}}", otpCode)
                    .Replace("{{CompanyName}}", companyName)
                    .Replace("{{Year}}", DateTime.UtcNow.Year.ToString());

                var message = new MimeMessage();
                message.From.Add(new MailboxAddress(senderName, senderEmail));
                message.To.Add(new MailboxAddress(userEmail, userEmail));
                message.Subject = $"Your Verification Code - {companyName}";

                var bodyBuilder = new BodyBuilder { HtmlBody = emailBody };
                message.Body = bodyBuilder.ToMessageBody();

                using (var client = new SmtpClient())
                {
                    var socketOptions = smtpPort == 587 ? SecureSocketOptions.StartTls :
                                      smtpPort == 465 ? SecureSocketOptions.SslOnConnect :
                                      SecureSocketOptions.Auto;

                    await client.ConnectAsync(smtpHost, smtpPort, socketOptions);
                    await client.AuthenticateAsync(senderEmail, senderPassword);
                    await client.SendAsync(message);
                    await client.DisconnectAsync(true);

                    _logger.LogInformation($"OTP verification email sent to {userEmail}");
                    await LogEmailAsync(userEmail, userEmail, $"Your Verification Code - {companyName}", 5, "OtpVerificationEmailTemplate.html", "Sent");
                    return true;
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Failed to send OTP verification email to {userEmail}");
                await LogEmailAsync(userEmail, userEmail, $"Your Verification Code - {_configuration["ApplicationSettings:CompanyName"]}", 5, "OtpVerificationEmailTemplate.html", "Failed", ex.Message);
                return false;
            }
        }

        public async Task<bool> SendWelcomeNewUserEmailAsync(string userEmail, string userName)
        {
            try
            {
                var smtpHost = _configuration["EmailSettings:SmtpHost"];
                var smtpPort = int.Parse(_configuration["EmailSettings:SmtpPort"] ?? "587");
                var senderEmail = _configuration["EmailSettings:SenderEmail"];
                var senderName = _configuration["EmailSettings:SenderName"];
                var senderPassword = _configuration["EmailSettings:SenderPassword"];
                var companyName = _configuration["ApplicationSettings:CompanyName"];
                var frontendUrl = _configuration["ApplicationSettings:FrontendUrl"] ?? "http://localhost:5174";

                if (string.IsNullOrEmpty(smtpHost) || string.IsNullOrEmpty(senderEmail) || string.IsNullOrEmpty(senderPassword))
                {
                    _logger.LogError("Email configuration is incomplete for welcome new user email");
                    return false;
                }

                var templatePath = Path.Combine(Path.GetDirectoryName(_templatePath)!, "WelcomeNewUserEmailTemplate.html");
                if (!File.Exists(templatePath))
                {
                    _logger.LogError($"Welcome new user email template not found at: {templatePath}");
                    return false;
                }

                string emailTemplate = await File.ReadAllTextAsync(templatePath);
                var emailBody = emailTemplate
                    .Replace("{{UserName}}", string.IsNullOrWhiteSpace(userName) ? userEmail : userName)
                    .Replace("{{CompanyName}}", companyName)
                    .Replace("{{SetupUrl}}", frontendUrl)
                    .Replace("{{Year}}", DateTime.UtcNow.Year.ToString());

                var message = new MimeMessage();
                message.From.Add(new MailboxAddress(senderName, senderEmail));
                message.To.Add(new MailboxAddress(userEmail, userEmail));
                message.Subject = $"Welcome to {companyName}!";

                message.Body = new BodyBuilder { HtmlBody = emailBody }.ToMessageBody();

                using var client = new SmtpClient();
                var socketOptions = smtpPort == 587 ? SecureSocketOptions.StartTls :
                                    smtpPort == 465 ? SecureSocketOptions.SslOnConnect :
                                    SecureSocketOptions.Auto;
                await client.ConnectAsync(smtpHost, smtpPort, socketOptions);
                await client.AuthenticateAsync(senderEmail, senderPassword);
                await client.SendAsync(message);
                await client.DisconnectAsync(true);

                _logger.LogInformation($"Welcome email sent to new user: {userEmail}");
                await LogEmailAsync(userEmail, userEmail, $"Welcome to {companyName}!", 12, "WelcomeNewUserEmailTemplate.html", "Sent");
                return true;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Failed to send welcome email to new user {userEmail}");
                await LogEmailAsync(userEmail, userEmail, $"Welcome to {_configuration["ApplicationSettings:CompanyName"]}!", 12, "WelcomeNewUserEmailTemplate.html", "Failed", ex.Message);
                return false;
            }
        }

        public async Task<bool> SendScheduleConfirmedEmailAsync(
            string recipientEmail, string recipientName,
            string teacherName, string studentName,
            string subjectName, string dayName, string timeSlot,
            DateTime startDate)
        {
            try
            {
                var smtpHost = _configuration["EmailSettings:SmtpHost"];
                var smtpPort = int.Parse(_configuration["EmailSettings:SmtpPort"] ?? "587");
                var senderEmail = _configuration["EmailSettings:SenderEmail"];
                var senderName = _configuration["EmailSettings:SenderName"];
                var senderPassword = _configuration["EmailSettings:SenderPassword"];
                var companyName = _configuration["ApplicationSettings:CompanyName"];

                if (string.IsNullOrEmpty(smtpHost) || string.IsNullOrEmpty(senderEmail) || string.IsNullOrEmpty(senderPassword))
                {
                    _logger.LogError("Email configuration is incomplete for schedule confirmation email");
                    return false;
                }

                var templatePath = Path.Combine(Path.GetDirectoryName(_templatePath)!, "ScheduleConfirmedEmailTemplate.html");
                if (!File.Exists(templatePath))
                {
                    _logger.LogError($"Schedule confirmed email template not found at: {templatePath}");
                    return false;
                }

                string emailTemplate = await File.ReadAllTextAsync(templatePath);
                var emailBody = emailTemplate
                    .Replace("{{RecipientName}}", recipientName)
                    .Replace("{{TeacherName}}", teacherName)
                    .Replace("{{StudentName}}", studentName)
                    .Replace("{{SubjectName}}", subjectName)
                    .Replace("{{DayName}}", dayName)
                    .Replace("{{TimeSlot}}", timeSlot)
                    .Replace("{{StartDate}}", startDate.ToString("dddd, MMMM d, yyyy"))
                    .Replace("{{CompanyName}}", companyName)
                    .Replace("{{Year}}", DateTime.UtcNow.Year.ToString());

                var message = new MimeMessage();
                message.From.Add(new MailboxAddress(senderName, senderEmail));
                message.To.Add(new MailboxAddress(recipientName, recipientEmail));
                message.Subject = $"Your Tutoring Session is Confirmed – {subjectName} starts {startDate:MMM d}";

                message.Body = new BodyBuilder { HtmlBody = emailBody }.ToMessageBody();

                using var client = new SmtpClient();
                var socketOptions = smtpPort == 587 ? SecureSocketOptions.StartTls :
                                    smtpPort == 465 ? SecureSocketOptions.SslOnConnect :
                                    SecureSocketOptions.Auto;
                await client.ConnectAsync(smtpHost, smtpPort, socketOptions);
                await client.AuthenticateAsync(senderEmail, senderPassword);
                await client.SendAsync(message);
                await client.DisconnectAsync(true);

                _logger.LogInformation($"Schedule confirmation email sent to {recipientEmail}");
                await LogEmailAsync(recipientEmail, recipientName, $"Your Tutoring Session is Confirmed – {subjectName} starts {startDate:MMM d}", 8, "ScheduleConfirmedEmailTemplate.html", "Sent");
                return true;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Failed to send schedule confirmation email to {recipientEmail}");
                await LogEmailAsync(recipientEmail, recipientName, $"Your Tutoring Session is Confirmed – {subjectName}", 8, "ScheduleConfirmedEmailTemplate.html", "Failed", ex.Message);
                return false;
            }
        }

        public async Task<bool> SendScheduleAssignedEmailAsync(
            string teacherEmail, string teacherName,
            string studentName, string subjectName,
            string roomName, string dayName, string timeSlot)
        {
            try
            {
                var smtpHost = _configuration["EmailSettings:SmtpHost"];
                var smtpPort = int.Parse(_configuration["EmailSettings:SmtpPort"] ?? "587");
                var senderEmail = _configuration["EmailSettings:SenderEmail"];
                var senderName = _configuration["EmailSettings:SenderName"];
                var senderPassword = _configuration["EmailSettings:SenderPassword"];
                var companyName = _configuration["ApplicationSettings:CompanyName"];

                if (string.IsNullOrEmpty(smtpHost) || string.IsNullOrEmpty(senderEmail) || string.IsNullOrEmpty(senderPassword))
                {
                    _logger.LogError("Email configuration is incomplete for schedule assigned email");
                    return false;
                }

                var templatePath = Path.Combine(Path.GetDirectoryName(_templatePath)!, "ScheduleAssignedEmailTemplate.html");
                if (!File.Exists(templatePath))
                {
                    _logger.LogError($"Schedule assigned email template not found at: {templatePath}");
                    return false;
                }

                string emailTemplate = await File.ReadAllTextAsync(templatePath);
                var emailBody = emailTemplate
                    .Replace("{{TeacherName}}", teacherName)
                    .Replace("{{StudentName}}", studentName)
                    .Replace("{{SubjectName}}", subjectName)
                    .Replace("{{RoomName}}", roomName)
                    .Replace("{{DayName}}", dayName)
                    .Replace("{{TimeSlot}}", timeSlot)
                    .Replace("{{CompanyName}}", companyName)
                    .Replace("{{Year}}", DateTime.UtcNow.Year.ToString());

                var message = new MimeMessage();
                message.From.Add(new MailboxAddress(senderName, senderEmail));
                message.To.Add(new MailboxAddress(teacherName, teacherEmail));
                message.Subject = $"[Action Required] You have been assigned to a {subjectName} session – {dayName} {timeSlot}";

                message.Body = new BodyBuilder { HtmlBody = emailBody }.ToMessageBody();

                using var client = new SmtpClient();
                var socketOptions = smtpPort == 587 ? SecureSocketOptions.StartTls :
                                    smtpPort == 465 ? SecureSocketOptions.SslOnConnect :
                                    SecureSocketOptions.Auto;
                await client.ConnectAsync(smtpHost, smtpPort, socketOptions);
                await client.AuthenticateAsync(senderEmail, senderPassword);
                await client.SendAsync(message);
                await client.DisconnectAsync(true);

                _logger.LogInformation($"Schedule assigned email sent to teacher {teacherEmail}");
                await LogEmailAsync(teacherEmail, teacherName, $"[Action Required] You have been assigned to a {subjectName} session – {dayName} {timeSlot}", 7, "ScheduleAssignedEmailTemplate.html", "Sent");
                return true;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Failed to send schedule assigned email to {teacherEmail}");
                await LogEmailAsync(teacherEmail, teacherName, $"[Action Required] You have been assigned to a {subjectName} session", 7, "ScheduleAssignedEmailTemplate.html", "Failed", ex.Message);
                return false;
            }
        }

        public async Task<bool> SendAdminCancelEmailAsync(
            string recipientEmail, string recipientName,
            string teacherName, string studentName,
            string subjectName, string buildingName,
            string cancellationReason, DateTime cancelledAt)
        {
            try
            {
                var smtpHost = _configuration["EmailSettings:SmtpHost"];
                var smtpPort = int.Parse(_configuration["EmailSettings:SmtpPort"] ?? "587");
                var senderEmail = _configuration["EmailSettings:SenderEmail"];
                var senderName = _configuration["EmailSettings:SenderName"];
                var senderPassword = _configuration["EmailSettings:SenderPassword"];
                var companyName = _configuration["ApplicationSettings:CompanyName"];

                if (string.IsNullOrEmpty(smtpHost) || string.IsNullOrEmpty(senderEmail) || string.IsNullOrEmpty(senderPassword))
                {
                    _logger.LogError("Email configuration is incomplete for admin cancel email");
                    return false;
                }

                var templatePath = Path.Combine(Path.GetDirectoryName(_templatePath)!, "AdminCancelEmailTemplate.html");
                if (!File.Exists(templatePath))
                {
                    _logger.LogError($"Admin cancel email template not found at: {templatePath}");
                    return false;
                }

                string emailTemplate = await File.ReadAllTextAsync(templatePath);
                var emailBody = emailTemplate
                    .Replace("{{RecipientName}}", recipientName)
                    .Replace("{{TeacherName}}", string.IsNullOrEmpty(teacherName) ? "Not yet assigned" : teacherName)
                    .Replace("{{StudentName}}", string.IsNullOrEmpty(studentName) ? "Not yet assigned" : studentName)
                    .Replace("{{SubjectName}}", subjectName)
                    .Replace("{{BuildingName}}", buildingName)
                    .Replace("{{CancellationReason}}", cancellationReason)
                    .Replace("{{CancelledAt}}", cancelledAt.ToLocalTime().ToString("MMMM dd, yyyy"))
                    .Replace("{{CompanyName}}", companyName)
                    .Replace("{{Year}}", DateTime.UtcNow.Year.ToString());

                var message = new MimeMessage();
                message.From.Add(new MailboxAddress(senderName, senderEmail));
                message.To.Add(new MailboxAddress(recipientName, recipientEmail));
                message.Subject = $"[Notice] Your tutoring session for {subjectName} has been cancelled";

                message.Body = new BodyBuilder { HtmlBody = emailBody }.ToMessageBody();

                using var client = new SmtpClient();
                var socketOptions = smtpPort == 587 ? SecureSocketOptions.StartTls :
                                    smtpPort == 465 ? SecureSocketOptions.SslOnConnect :
                                    SecureSocketOptions.Auto;
                await client.ConnectAsync(smtpHost, smtpPort, socketOptions);
                await client.AuthenticateAsync(senderEmail, senderPassword);
                await client.SendAsync(message);
                await client.DisconnectAsync(true);

                _logger.LogInformation($"Admin cancel email sent to {recipientEmail}");
                await LogEmailAsync(recipientEmail, recipientName, $"[Notice] Your tutoring session for {subjectName} has been cancelled", 10, "AdminCancelEmailTemplate.html", "Sent");
                return true;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Failed to send admin cancel email to {recipientEmail}");
                await LogEmailAsync(recipientEmail, recipientName, $"[Notice] Your tutoring session for {subjectName} has been cancelled", 10, "AdminCancelEmailTemplate.html", "Failed", ex.Message);
                return false;
            }
        }

        public async Task<bool> SendSessionReminderEmailAsync(
            string recipientEmail, string recipientName,
            string teacherName, string studentName,
            string subjectName, string dayName, string timeSlot,
            string roomName, string buildingName,
            DateTime sessionDate)
        {
            try
            {
                var smtpHost = _configuration["EmailSettings:SmtpHost"];
                var smtpPort = int.Parse(_configuration["EmailSettings:SmtpPort"] ?? "587");
                var senderEmail = _configuration["EmailSettings:SenderEmail"];
                var senderName = _configuration["EmailSettings:SenderName"];
                var senderPassword = _configuration["EmailSettings:SenderPassword"];
                var companyName = _configuration["ApplicationSettings:CompanyName"];

                if (string.IsNullOrEmpty(smtpHost) || string.IsNullOrEmpty(senderEmail) || string.IsNullOrEmpty(senderPassword))
                {
                    _logger.LogError("Email configuration is incomplete for session reminder email");
                    return false;
                }

                var templatePath = Path.Combine(Path.GetDirectoryName(_templatePath)!, "SessionReminderEmailTemplate.html");
                if (!File.Exists(templatePath))
                {
                    _logger.LogError($"Session reminder email template not found at: {templatePath}");
                    return false;
                }

                string emailTemplate = await File.ReadAllTextAsync(templatePath);
                var emailBody = emailTemplate
                    .Replace("{{RecipientName}}", recipientName)
                    .Replace("{{TeacherName}}", teacherName)
                    .Replace("{{StudentName}}", studentName)
                    .Replace("{{SubjectName}}", subjectName)
                    .Replace("{{DayName}}", dayName)
                    .Replace("{{TimeSlot}}", timeSlot)
                    .Replace("{{RoomName}}", string.IsNullOrEmpty(roomName) ? "TBD" : roomName)
                    .Replace("{{BuildingName}}", buildingName)
                    .Replace("{{SessionDate}}", sessionDate.ToString("dddd, MMMM d, yyyy"))
                    .Replace("{{CompanyName}}", companyName)
                    .Replace("{{Year}}", DateTime.UtcNow.Year.ToString());

                var message = new MimeMessage();
                message.From.Add(new MailboxAddress(senderName, senderEmail));
                message.To.Add(new MailboxAddress(recipientName, recipientEmail));
                message.Subject = $"Reminder: Your {subjectName} session is tomorrow – {sessionDate:MMM d}";

                message.Body = new BodyBuilder { HtmlBody = emailBody }.ToMessageBody();

                using var client = new SmtpClient();
                var socketOptions = smtpPort == 587 ? SecureSocketOptions.StartTls :
                                    smtpPort == 465 ? SecureSocketOptions.SslOnConnect :
                                    SecureSocketOptions.Auto;
                await client.ConnectAsync(smtpHost, smtpPort, socketOptions);
                await client.AuthenticateAsync(senderEmail, senderPassword);
                await client.SendAsync(message);
                await client.DisconnectAsync(true);

                _logger.LogInformation($"Session reminder email sent to {recipientEmail}");
                await LogEmailAsync(recipientEmail, recipientName, $"Reminder: Your {subjectName} session is tomorrow – {sessionDate:MMM d}", 9, "SessionReminderEmailTemplate.html", "Sent");
                return true;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Failed to send session reminder email to {recipientEmail}");
                await LogEmailAsync(recipientEmail, recipientName, $"Reminder: Your {subjectName} session is tomorrow", 9, "SessionReminderEmailTemplate.html", "Failed", ex.Message);
                return false;
            }
        }
    }
}
