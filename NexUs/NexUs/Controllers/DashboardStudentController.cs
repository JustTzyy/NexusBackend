using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NexUs.Data;
using NexUs.Extensions;
using NexUs.Models.DTO.Common;
using NexUs.Models.DTO.Dashboard;

namespace NexUs.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class DashboardStudentController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public DashboardStudentController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet("summary")]
        public async Task<ActionResult<ApiResponse<StudentDashboardDto>>> GetDashboardSummary(
            [FromQuery] DateTime? fromDate = null,
            [FromQuery] DateTime? toDate = null)
        {
            try
            {
                var studentId = HttpContext.GetCurrentUserId();
                if (studentId == null)
                    return Unauthorized(ApiResponse<StudentDashboardDto>.ErrorResponse("User not authenticated"));

                var hasDateFilter = fromDate.HasValue || toDate.HasValue;
                var rangeStart = fromDate?.Date ?? DateTime.UtcNow.Date.AddDays(-29);
                var rangeEnd = (toDate?.Date ?? DateTime.UtcNow.Date).AddDays(1).AddTicks(-1);

                var baseQuery = _context.TutoringRequests
                    .Where(t => t.StudentId == studentId.Value && t.DeletedAt == null);

                if (hasDateFilter)
                    baseQuery = baseQuery.Where(t => t.CreatedAt >= rangeStart && t.CreatedAt <= rangeEnd);

                // Counts by status
                var totalCount = await baseQuery.CountAsync();

                var pendingCount = await baseQuery
                    .Where(t => t.Status == "Pending Teacher Interest")
                    .CountAsync();

                var inProgressCount = await baseQuery
                    .Where(t => t.Status == "Waiting for Admin Approval"
                        || t.Status == "Teacher Assigned"
                        || t.Status == "Waiting for Teacher Approval")
                    .CountAsync();

                var confirmedCount = await baseQuery
                    .Where(t => t.Status == "Confirmed")
                    .CountAsync();

                var cancelledCount = await baseQuery
                    .Where(t => t.Status == "Cancelled by Student" || t.Status == "Cancelled by Admin")
                    .CountAsync();

                // Recent requests (last 5)
                var recentRequests = await _context.TutoringRequests
                    .Include(t => t.Student)
                    .Include(t => t.Building)
                    .Include(t => t.Department)
                    .Include(t => t.Subject)
                    .Where(t => t.StudentId == studentId.Value && t.DeletedAt == null)
                    .OrderByDescending(t => t.CreatedAt)
                    .Take(5)
                    .Select(t => new DashboardRequestItemDto
                    {
                        Id = t.Id,
                        SubjectName = t.Subject.Name,
                        BuildingName = t.Building.Name,
                        DepartmentName = t.Department.Name,
                        StudentName = $"{t.Student.FirstName} {t.Student.LastName}",
                        Priority = t.Priority,
                        Status = t.Status,
                        CreatedAt = t.CreatedAt
                    })
                    .ToListAsync();

                // Upcoming confirmed sessions
                var upcomingSessions = await _context.TutoringRequests
                    .Include(t => t.Student)
                    .Include(t => t.Building)
                    .Include(t => t.Subject)
                    .Include(t => t.Room)
                    .Include(t => t.AvailableDay)
                    .Include(t => t.AvailableTimeSlot)
                    .Include(t => t.AssignedTeacher)
                    .Where(t => t.StudentId == studentId.Value
                        && t.Status == "Confirmed"
                        && t.DeletedAt == null)
                    .OrderByDescending(t => t.ConfirmedAt)
                    .Take(5)
                    .Select(t => new DashboardSessionItemDto
                    {
                        Id = t.Id,
                        SubjectName = t.Subject.Name,
                        StudentName = $"{t.Student.FirstName} {t.Student.LastName}",
                        BuildingName = t.Building.Name,
                        RoomName = t.Room != null ? t.Room.Name : null,
                        DayName = t.AvailableDay != null ? t.AvailableDay.DayName : null,
                        TimeSlotLabel = t.AvailableTimeSlot != null ? t.AvailableTimeSlot.Label : null,
                        AssignedTeacherName = t.AssignedTeacher != null
                            ? $"{t.AssignedTeacher.FirstName} {t.AssignedTeacher.LastName}" : null,
                        ConfirmedAt = t.ConfirmedAt
                    })
                    .ToListAsync();

                var summary = new StudentDashboardDto
                {
                    TotalRequestsCount = totalCount,
                    PendingCount = pendingCount,
                    InProgressCount = inProgressCount,
                    ConfirmedCount = confirmedCount,
                    CancelledCount = cancelledCount,
                    RecentRequests = recentRequests,
                    UpcomingSessions = upcomingSessions
                };

                return Ok(ApiResponse<StudentDashboardDto>.SuccessResponse(summary, "Student dashboard summary retrieved successfully"));
            }
            catch (Exception)
            {
                return StatusCode(500, ApiResponse<StudentDashboardDto>.ErrorResponse(
                    "An error occurred while retrieving dashboard summary"));
            }
        }
    }
}
