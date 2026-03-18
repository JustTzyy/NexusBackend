using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NexUs.Data;
using NexUs.Models.DTO.Common;
using NexUs.Models.DTO.Dashboard;
using NexUs.Models.Entities;
using NexUs.Services.Interfaces;

namespace NexUs.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class DashboardAdminController : ControllerBase
    {
        private readonly IUserService _userService;
        private readonly IBuildingService _buildingService;
        private readonly ITeacherAssignmentService _teacherAssignmentService;
        private readonly ApplicationDbContext _context;

        public DashboardAdminController(
            IUserService userService,
            IBuildingService buildingService,
            ITeacherAssignmentService teacherAssignmentService,
            ApplicationDbContext context)
        {
            _userService = userService;
            _buildingService = buildingService;
            _teacherAssignmentService = teacherAssignmentService;
            _context = context;
        }

        /// <summary>
        /// Get dashboard summary data for Admin
        /// </summary>
        [HttpGet("summary")]
        [Authorize(Roles = "Admin, Super Admin")]
        public async Task<ActionResult<ApiResponse<DashboardSummaryDto>>> GetDashboardSummary(
            [FromQuery] DateTime? fromDate = null,
            [FromQuery] DateTime? toDate = null)
        {
            try
            {
                var rangeStart = fromDate?.Date ?? DateTime.UtcNow.Date.AddDays(-29);
                var rangeEnd = (toDate?.Date ?? DateTime.UtcNow.Date).AddDays(1).AddTicks(-1);

                var minPage = new PaginationDto { PageNumber = 1, PageSize = 1 };

                // 1. User stats
                var usersResponse = await _userService.GetAllUsersAsync(minPage);
                int totalUsers = usersResponse.TotalCount;

                var archivedResponse = await _userService.GetArchivedUsersAsync(minPage);
                int activeUsers = totalUsers - archivedResponse.TotalCount;

                // 2. Recent users
                var recentUsersResponse = await _userService.GetAllUsersAsync(new PaginationDto
                {
                    PageNumber = 1,
                    PageSize = 4,
                    SortBy = "CreatedAt",
                    SortDescending = true
                });

                var recentUsers = recentUsersResponse.Items.Select(u => new RecentUserDto
                {
                    Id = u.Id,
                    Name = u.FullName,
                    Email = u.Email,
                    Role = u.RoleName ?? "No Role",
                    Status = "Active",
                    JoinedDate = GetRelativeDate(u.CreatedAt)
                }).ToList();

                // 3. User registration trends (30 days)
                var registrationTrends = await GetRegistrationTrends(rangeStart, rangeEnd);

                // 4. Tutoring setup counts (Buildings + Teacher Assignments only)
                var buildingsCount = (await _buildingService.GetAllBuildingsAsync(minPage)).TotalCount;
                var teacherAssignmentsCount = (await _teacherAssignmentService.GetAllTeacherAssignmentsAsync(minPage)).TotalCount;

                // 5. Scheduling / tutoring request stats
                var requests = await _context.TutoringRequests
                    .Where(r => r.DeletedAt == null
                        && r.CreatedAt >= rangeStart
                        && r.CreatedAt <= rangeEnd)
                    .ToListAsync();

                var totalRequests = requests.Count;
                var confirmedSessions = requests.Count(r => r.Status == "Confirmed");
                var activeRequests = requests.Count(r =>
                    r.Status == "Pending Teacher Interest" ||
                    r.Status == "Waiting for Admin Approval" ||
                    r.Status == "Teacher Assigned" ||
                    r.Status == "Waiting for Teacher Approval" ||
                    r.Status == "Pending Student Interest");
                var cancelledRequests = requests.Count(r =>
                    r.Status == "Cancelled by Admin" || r.Status == "Cancelled by Student");

                var statusDistribution = requests
                    .GroupBy(r => r.Status)
                    .Select(g => new StatusCountDto { Status = g.Key, Count = g.Count() })
                    .OrderByDescending(x => x.Count)
                    .ToList();

                var adminRequestTrends = GetRequestTrends(requests, true, rangeStart, rangeEnd);
                var studentRequestTrends = GetRequestTrends(requests, false, rangeStart, rangeEnd);

                var summary = new DashboardSummaryDto
                {
                    TotalUsers = totalUsers,
                    ActiveUsers = activeUsers,
                    RecentUsers = recentUsers,
                    RegistrationTrends = registrationTrends,
                    TotalBuildings = buildingsCount,
                    TotalTeacherAssignments = teacherAssignmentsCount,
                    TotalRequests = totalRequests,
                    ConfirmedSessions = confirmedSessions,
                    ActiveRequests = activeRequests,
                    CancelledRequests = cancelledRequests,
                    StatusDistribution = statusDistribution,
                    AdminRequestTrends = adminRequestTrends,
                    StudentRequestTrends = studentRequestTrends,
                };

                return Ok(ApiResponse<DashboardSummaryDto>.SuccessResponse(summary, "Dashboard summary retrieved successfully"));
            }
            catch (Exception ex)
            {
                return StatusCode(500, ApiResponse<DashboardSummaryDto>.ErrorResponse("An error occurred while retrieving dashboard summary", new List<string> { ex.Message }));
            }
        }

        private string GetRelativeDate(DateTime date)
        {
            var diff = DateTime.UtcNow - date;
            if (diff.TotalDays < 1) return "Today";
            if (diff.TotalDays < 2) return "1 day ago";
            if (diff.TotalDays < 7) return $"{(int)diff.TotalDays} days ago";
            if (diff.TotalDays < 14) return "1 week ago";
            if (diff.TotalDays < 30) return $"{(int)(diff.TotalDays / 7)} weeks ago";
            return $"{(int)(diff.TotalDays / 30)} months ago";
        }

        private async Task<List<int>> GetRegistrationTrends(DateTime rangeStart, DateTime rangeEnd)
        {
            var trends = new List<int>();
            var current = rangeStart.Date;
            while (current <= rangeEnd.Date)
            {
                var next = current.AddDays(1);
                var count = await _userService.CountUsersCreatedBetweenAsync(current, next);
                trends.Add(count);
                current = next;
            }
            return trends;
        }

        private static List<int> GetRequestTrends(List<TutoringRequest> requests, bool isAdminCreated, DateTime rangeStart, DateTime rangeEnd)
        {
            var days = (int)(rangeEnd.Date - rangeStart.Date).TotalDays + 1;
            return Enumerable.Range(0, days)
                .Select(i =>
                {
                    var day = rangeStart.Date.AddDays(i);
                    return requests.Count(r => r.IsAdminCreated == isAdminCreated && r.CreatedAt.Date == day);
                })
                .ToList();
        }
    }
}
