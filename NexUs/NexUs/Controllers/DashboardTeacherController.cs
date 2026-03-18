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
    public class DashboardTeacherController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public DashboardTeacherController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet("summary")]
        public async Task<ActionResult<ApiResponse<TeacherDashboardDto>>> GetDashboardSummary(
            [FromQuery] DateTime? fromDate = null,
            [FromQuery] DateTime? toDate = null)
        {
            try
            {
                var rangeStart = fromDate?.Date ?? DateTime.UtcNow.Date.AddDays(-29);
                var rangeEnd = (toDate?.Date ?? DateTime.UtcNow.Date).AddDays(1).AddTicks(-1);

                var teacherId = HttpContext.GetCurrentUserId();
                if (teacherId == null)
                    return Unauthorized(ApiResponse<TeacherDashboardDto>.ErrorResponse("User not authenticated"));

                // Get teacher's building/department assignments
                var assignments = await _context.TeacherAssignments
                    .Where(a => a.TeacherId == teacherId.Value && a.DeletedAt == null)
                    .Select(a => new { a.BuildingId, a.DepartmentId })
                    .ToListAsync();

                var buildingIds = assignments.Select(a => a.BuildingId).Distinct().ToList();
                var departmentIds = assignments.Select(a => a.DepartmentId).Distinct().ToList();

                // Available requests count
                var availableCount = await _context.TutoringRequests
                    .Where(t => t.Status == "Pending Teacher Interest"
                        && t.DeletedAt == null
                        && t.CreatedAt >= rangeStart
                        && t.CreatedAt <= rangeEnd
                        && buildingIds.Contains(t.BuildingId)
                        && departmentIds.Contains(t.DepartmentId))
                    .CountAsync();

                // Expressed interest count
                var expressedCount = await _context.TutoringRequests
                    .Where(t => t.TeacherInterests.Any(ti => ti.TeacherId == teacherId.Value)
                        && t.DeletedAt == null
                        && t.CreatedAt >= rangeStart
                        && t.CreatedAt <= rangeEnd)
                    .CountAsync();

                // Pending approval count (assigned to this teacher, awaiting confirmation)
                var pendingApprovalCount = await _context.TutoringRequests
                    .Where(t => t.Status == "Waiting for Teacher Approval"
                        && t.AssignedTeacherId == teacherId.Value
                        && t.DeletedAt == null
                        && t.CreatedAt >= rangeStart
                        && t.CreatedAt <= rangeEnd)
                    .CountAsync();

                // Confirmed sessions count
                var confirmedCount = await _context.TutoringRequests
                    .Where(t => t.Status == "Confirmed"
                        && t.AssignedTeacherId == teacherId.Value
                        && t.DeletedAt == null
                        && t.CreatedAt >= rangeStart
                        && t.CreatedAt <= rangeEnd)
                    .CountAsync();

                // Recent available requests (last 5)
                var recentAvailable = await _context.TutoringRequests
                    .Include(t => t.Student)
                    .Include(t => t.Building)
                    .Include(t => t.Department)
                    .Include(t => t.Subject)
                    .Where(t => t.Status == "Pending Teacher Interest"
                        && t.DeletedAt == null
                        && buildingIds.Contains(t.BuildingId)
                        && departmentIds.Contains(t.DepartmentId))
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

                // Upcoming confirmed sessions (last 5)
                var upcomingSessions = await _context.TutoringRequests
                    .Include(t => t.Student)
                    .Include(t => t.Building)
                    .Include(t => t.Subject)
                    .Include(t => t.Room)
                    .Include(t => t.AvailableDay)
                    .Include(t => t.AvailableTimeSlot)
                    .Where(t => (t.Status == "Confirmed" || t.Status == "Waiting for Teacher Approval")
                        && t.AssignedTeacherId == teacherId.Value
                        && t.DeletedAt == null)
                    .OrderByDescending(t => t.ConfirmedAt ?? t.ScheduledAt)
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
                        ConfirmedAt = t.ConfirmedAt
                    })
                    .ToListAsync();

                var summary = new TeacherDashboardDto
                {
                    HasAssignment = assignments.Count > 0,
                    AvailableRequestsCount = availableCount,
                    ExpressedInterestCount = expressedCount,
                    PendingApprovalCount = pendingApprovalCount,
                    ConfirmedSessionsCount = confirmedCount,
                    RecentAvailable = recentAvailable,
                    UpcomingSessions = upcomingSessions
                };

                return Ok(ApiResponse<TeacherDashboardDto>.SuccessResponse(summary, "Teacher dashboard summary retrieved successfully"));
            }
            catch (Exception ex)
            {
                return StatusCode(500, ApiResponse<TeacherDashboardDto>.ErrorResponse(
                    "An error occurred while retrieving dashboard summary", new List<string> { ex.Message }));
            }
        }
    }
}
