using Microsoft.EntityFrameworkCore;
using NexUs.Data;
using NexUs.Services.Interfaces;

namespace NexUs.Services
{
    public class SessionReminderBackgroundService : BackgroundService
    {
        private readonly IServiceScopeFactory _scopeFactory;
        private readonly ILogger<SessionReminderBackgroundService> _logger;

        // Check every hour; the ReminderSentAt flag prevents duplicate sends
        private static readonly TimeSpan CheckInterval = TimeSpan.FromHours(1);

        private static readonly Dictionary<string, DayOfWeek> DayMap =
            new(StringComparer.OrdinalIgnoreCase)
            {
                ["Sunday"]    = DayOfWeek.Sunday,
                ["Monday"]    = DayOfWeek.Monday,
                ["Tuesday"]   = DayOfWeek.Tuesday,
                ["Wednesday"] = DayOfWeek.Wednesday,
                ["Thursday"]  = DayOfWeek.Thursday,
                ["Friday"]    = DayOfWeek.Friday,
                ["Saturday"]  = DayOfWeek.Saturday,
            };

        public SessionReminderBackgroundService(
            IServiceScopeFactory scopeFactory,
            ILogger<SessionReminderBackgroundService> logger)
        {
            _scopeFactory = scopeFactory;
            _logger = logger;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            _logger.LogInformation("Session reminder background service started.");

            // Give the app 30 seconds to fully initialise before the first check
            await Task.Delay(TimeSpan.FromSeconds(30), stoppingToken);

            while (!stoppingToken.IsCancellationRequested)
            {
                try
                {
                    await SendPendingRemindersAsync(stoppingToken);
                }
                catch (Exception ex)
                {
                    _logger.LogError(ex, "Unhandled error while processing session reminders.");
                }

                await Task.Delay(CheckInterval, stoppingToken);
            }
        }

        private async Task SendPendingRemindersAsync(CancellationToken ct)
        {
            using var scope       = _scopeFactory.CreateScope();
            var context           = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();
            var automationService = scope.ServiceProvider.GetRequiredService<IAutomationService>();
            var emailService      = scope.ServiceProvider.GetRequiredService<IEmailService>();

            // "Tomorrow" in UTC date
            var tomorrow = DateTime.UtcNow.AddDays(1).Date;

            var sessions = await context.TutoringRequests
                .Where(t => t.Status        == "Confirmed"
                         && t.DeletedAt     == null
                         && t.ReminderSentAt == null
                         && t.ConfirmedAt   != null
                         && t.AvailableDayId != null)
                .Include(t => t.AssignedTeacher)
                .Include(t => t.Student)
                .Include(t => t.Subject)
                .Include(t => t.AvailableDay)
                .Include(t => t.AvailableTimeSlot)
                .Include(t => t.Room)
                .Include(t => t.Building)
                .ToListAsync(ct);

            foreach (var session in sessions)
            {
                if (ct.IsCancellationRequested) break;

                var dayName = session.AvailableDay?.DayName;
                if (string.IsNullOrEmpty(dayName) || !DayMap.TryGetValue(dayName, out var targetDow))
                    continue;

                // First session date = next occurrence of dayName that is >= ConfirmedAt + 7 days
                var sessionDate = ComputeStartDate(session.ConfirmedAt!.Value, targetDow);
                if (sessionDate.Date != tomorrow) continue;

                var teacherName  = session.AssignedTeacher != null
                    ? $"{session.AssignedTeacher.FirstName} {session.AssignedTeacher.LastName}".Trim()
                    : "Teacher";
                var studentName  = session.Student != null
                    ? $"{session.Student.FirstName} {session.Student.LastName}".Trim()
                    : "Student";
                var subjectName  = session.Subject?.Name    ?? "Session";
                var timeSlot     = session.AvailableTimeSlot?.Label ?? "";
                var roomName     = session.Room?.Name       ?? "";
                var buildingName = session.Building?.Name   ?? "";

                // Remind the teacher — try automation, fall back to direct EmailService
                var teacherEmail = session.AssignedTeacher?.Email;
                if (!string.IsNullOrEmpty(teacherEmail))
                {
                    var teacherReminded = await automationService.TriggerAndSendImmediatelyAsync("SessionReminder", new Dictionary<string, object>
                    {
                        { "Email", teacherEmail },
                        { "FirstName", teacherName },
                        { "RecipientName", teacherName },
                        { "TeacherName", teacherName },
                        { "StudentName", studentName },
                        { "SubjectName", subjectName },
                        { "DayName", dayName },
                        { "TimeSlot", timeSlot },
                        { "RoomName", string.IsNullOrEmpty(roomName) ? "TBD" : roomName },
                        { "BuildingName", buildingName },
                        { "SessionDate", sessionDate.ToString("dddd, MMMM d, yyyy") }
                    });
                    if (!teacherReminded)
                        await emailService.SendSessionReminderEmailAsync(teacherEmail, teacherName, teacherName, studentName, subjectName, dayName, timeSlot, roomName, buildingName, sessionDate);
                }

                // Remind the student — try automation, fall back to direct EmailService
                var studentEmail = session.Student?.Email;
                if (!string.IsNullOrEmpty(studentEmail))
                {
                    var studentReminded = await automationService.TriggerAndSendImmediatelyAsync("SessionReminder", new Dictionary<string, object>
                    {
                        { "Email", studentEmail },
                        { "FirstName", studentName },
                        { "RecipientName", studentName },
                        { "TeacherName", teacherName },
                        { "StudentName", studentName },
                        { "SubjectName", subjectName },
                        { "DayName", dayName },
                        { "TimeSlot", timeSlot },
                        { "RoomName", string.IsNullOrEmpty(roomName) ? "TBD" : roomName },
                        { "BuildingName", buildingName },
                        { "SessionDate", sessionDate.ToString("dddd, MMMM d, yyyy") }
                    });
                    if (!studentReminded)
                        await emailService.SendSessionReminderEmailAsync(studentEmail, studentName, teacherName, studentName, subjectName, dayName, timeSlot, roomName, buildingName, sessionDate);
                }

                session.ReminderSentAt = DateTime.UtcNow;
                _logger.LogInformation(
                    "Reminder emails sent for session {SessionId} (scheduled {Date}).",
                    session.Id, sessionDate.ToString("yyyy-MM-dd"));
            }

            if (sessions.Any(s => s.ReminderSentAt.HasValue))
                await context.SaveChangesAsync(ct);
        }

        /// <summary>
        /// Returns the first occurrence of <paramref name="targetDow"/> that falls on or after
        /// <paramref name="confirmedAt"/> + 7 days (the "next-week start" rule).
        /// </summary>
        private static DateTime ComputeStartDate(DateTime confirmedAt, DayOfWeek targetDow)
        {
            var candidate = confirmedAt.AddDays(7).Date;
            while (candidate.DayOfWeek != targetDow)
                candidate = candidate.AddDays(1);
            return candidate;
        }
    }
}
