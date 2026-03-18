using Microsoft.EntityFrameworkCore;
using NexUs.Data;
using NexUs.Models.DTO.Notifications;
using NexUs.Models.Entities;
using NexUs.Services.Interfaces;
using NexUs.Utilities;

namespace NexUs.Services
{
    /// <summary>
    /// Background service that automatically marks sessions as "Absent" when the building manager
    /// does not log them by the end of the day. Runs every hour and checks at 11 PM Philippine time.
    /// </summary>
    public class SessionAutoAbsentBackgroundService : BackgroundService
    {
        private readonly IServiceScopeFactory _scopeFactory;
        private readonly ILogger<SessionAutoAbsentBackgroundService> _logger;
        private static readonly TimeSpan CheckInterval = TimeSpan.FromHours(1);

        public SessionAutoAbsentBackgroundService(
            IServiceScopeFactory scopeFactory,
            ILogger<SessionAutoAbsentBackgroundService> logger)
        {
            _scopeFactory = scopeFactory;
            _logger = logger;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            _logger.LogInformation("Session auto-absent background service started.");
            await Task.Delay(TimeSpan.FromSeconds(45), stoppingToken);

            while (!stoppingToken.IsCancellationRequested)
            {
                try
                {
                    var phNow = DateTimeHelper.PhilippineNow;

                    // Run at 11 PM Philippine time
                    if (phNow.Hour == 23)
                    {
                        await ProcessUnloggedSessionsAsync(stoppingToken);
                    }
                }
                catch (Exception ex)
                {
                    _logger.LogError(ex, "Unhandled error in session auto-absent background service.");
                }

                await Task.Delay(CheckInterval, stoppingToken);
            }
        }

        private async Task ProcessUnloggedSessionsAsync(CancellationToken ct)
        {
            using var scope = _scopeFactory.CreateScope();
            var context = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();
            var notificationService = scope.ServiceProvider.GetRequiredService<INotificationService>();

            var phNow = DateTimeHelper.PhilippineNow;
            var todayName = phNow.DayOfWeek switch
            {
                DayOfWeek.Sunday => "Sunday",
                DayOfWeek.Monday => "Monday",
                DayOfWeek.Tuesday => "Tuesday",
                DayOfWeek.Wednesday => "Wednesday",
                DayOfWeek.Thursday => "Thursday",
                DayOfWeek.Friday => "Friday",
                DayOfWeek.Saturday => "Saturday",
                _ => "Monday"
            };
            var todayDate = phNow.Date;

            // Find all confirmed sessions scheduled for today's day of week
            var todaySessions = await context.TutoringRequests
                .Include(t => t.AvailableDay)
                .Include(t => t.AvailableTimeSlot)
                .Include(t => t.Subject)
                .Include(t => t.AssignedTeacher)
                .Include(t => t.Student)
                .Include(t => t.Building)
                .Include(t => t.Room)
                .Where(t => t.Status == "Confirmed"
                    && t.DeletedAt == null
                    && t.AvailableDay != null
                    && t.AvailableDay.DayName == todayName)
                .ToListAsync(ct);

            if (!todaySessions.Any())
            {
                _logger.LogInformation("No confirmed sessions found for {Day}. Nothing to auto-absent.", todayName);
                return;
            }

            // Get all session logs for today to check which ones are already logged
            var sessionIds = todaySessions.Select(s => s.Id).ToList();
            var existingLogs = (await context.SessionLogs
                .Where(sl => sessionIds.Contains(sl.TutoringRequestId)
                    && sl.SessionDate.Date == todayDate
                    && sl.DeletedAt == null)
                .Select(sl => sl.TutoringRequestId)
                .ToListAsync(ct)).ToHashSet();

            var unloggedSessions = todaySessions.Where(s => !existingLogs.Contains(s.Id)).ToList();

            if (!unloggedSessions.Any())
            {
                _logger.LogInformation("All sessions for {Day} have been logged. No auto-absent needed.", todayName);
                return;
            }

            _logger.LogInformation("Found {Count} unlogged sessions for {Day}. Creating auto-absent logs.",
                unloggedSessions.Count, todayName);

            foreach (var session in unloggedSessions)
            {
                if (ct.IsCancellationRequested) break;

                var subjectName = session.Subject?.Name ?? "Session";
                var teacherName = session.AssignedTeacher != null
                    ? $"{session.AssignedTeacher.FirstName} {session.AssignedTeacher.LastName}".Trim()
                    : "Teacher";
                var studentName = session.Student != null
                    ? $"{session.Student.FirstName} {session.Student.LastName}".Trim()
                    : "Student";
                var timeSlot = session.AvailableTimeSlot?.Label ?? "";
                var buildingName = session.Building?.Name ?? "";
                var roomName = session.Room?.Name ?? "";

                // Create auto-absent session log
                var log = new SessionLog
                {
                    TutoringRequestId = session.Id,
                    SessionDate = todayDate,
                    Outcome = "Absent",
                    AbsentParty = "Both",
                    Notes = $"Auto-marked as absent. Session was not logged by the building manager by end of day ({todayName}, {todayDate:MMM d, yyyy}).",
                };

                context.SessionLogs.Add(log);

                // Notify the teacher
                if (session.AssignedTeacherId.HasValue)
                {
                    try
                    {
                        await notificationService.CreateAsync(new CreateNotificationDto
                        {
                            RecipientUserId = session.AssignedTeacherId.Value,
                            Title = "Session Marked as Absent",
                            Message = $"Your {subjectName} session on {todayName} ({timeSlot}) was not logged and has been automatically marked as absent.",
                            Type = "Scheduling",
                            Priority = "High",
                            ReferenceId = session.Id,
                            ReferenceType = "TutoringRequest"
                        });
                    }
                    catch { /* silent */ }
                }

                // Notify the student
                if (session.StudentId.HasValue)
                {
                    try
                    {
                        await notificationService.CreateAsync(new CreateNotificationDto
                        {
                            RecipientUserId = session.StudentId.Value,
                            Title = "Session Marked as Absent",
                            Message = $"Your {subjectName} session on {todayName} ({timeSlot}) was not logged and has been automatically marked as absent.",
                            Type = "Scheduling",
                            Priority = "High",
                            ReferenceId = session.Id,
                            ReferenceType = "TutoringRequest"
                        });
                    }
                    catch { /* silent */ }
                }

                // Notify admins
                try
                {
                    await notificationService.CreateAsync(new CreateNotificationDto
                    {
                        RecipientRole = "Admin",
                        Title = "Session Auto-Absent",
                        Message = $"{subjectName} session ({teacherName} & {studentName}) at {buildingName} - {roomName} on {todayName} ({timeSlot}) was not logged and auto-marked as absent.",
                        Type = "Scheduling",
                        Priority = "Normal",
                        ReferenceId = session.Id,
                        ReferenceType = "TutoringRequest"
                    });
                }
                catch { /* silent */ }

                // Notify Super Admin
                try
                {
                    await notificationService.CreateAsync(new CreateNotificationDto
                    {
                        RecipientRole = "Super Admin",
                        Title = "Session Auto-Absent",
                        Message = $"{subjectName} session ({teacherName} & {studentName}) at {buildingName} - {roomName} on {todayName} ({timeSlot}) was not logged and auto-marked as absent.",
                        Type = "Scheduling",
                        Priority = "Normal",
                        ReferenceId = session.Id,
                        ReferenceType = "TutoringRequest"
                    });
                }
                catch { /* silent */ }

                _logger.LogInformation(
                    "Auto-absent log created for session {SessionId} ({Subject}, {Teacher} & {Student}) on {Day}.",
                    session.Id, subjectName, teacherName, studentName, todayName);
            }

            await context.SaveChangesAsync(ct);
            _logger.LogInformation("Saved {Count} auto-absent session logs for {Day}.", unloggedSessions.Count, todayName);
        }
    }
}
