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
    public class DashboardSuperAdminController : ControllerBase
    {
        private readonly IUserService _userService;
        private readonly IRoleService _roleService;
        private readonly IPermissionService _permissionService;
        private readonly ApplicationDbContext _context;
        private readonly IDepartmentService _departmentService;
        private readonly ISubjectService _subjectService;
        private readonly IBuildingService _buildingService;
        private readonly IRoomService _roomService;
        private readonly IAvailableDayService _availableDayService;
        private readonly IAvailableTimeSlotService _availableTimeSlotService;
        private readonly ITeacherAssignmentService _teacherAssignmentService;

        public DashboardSuperAdminController(
            IUserService userService,
            IRoleService roleService,
            IPermissionService permissionService,
            ApplicationDbContext context,
            IDepartmentService departmentService,
            ISubjectService subjectService,
            IBuildingService buildingService,
            IRoomService roomService,
            IAvailableDayService availableDayService,
            IAvailableTimeSlotService availableTimeSlotService,
            ITeacherAssignmentService teacherAssignmentService)
        {
            _userService = userService;
            _roleService = roleService;
            _permissionService = permissionService;
            _context = context;
            _departmentService = departmentService;
            _subjectService = subjectService;
            _buildingService = buildingService;
            _roomService = roomService;
            _availableDayService = availableDayService;
            _availableTimeSlotService = availableTimeSlotService;
            _teacherAssignmentService = teacherAssignmentService;
        }

        /// <summary>
        /// Get dashboard summary data for Super Admin
        /// </summary>
        [HttpGet("summary")]
        public async Task<ActionResult<ApiResponse<DashboardSummaryDto>>> GetDashboardSummary(
            [FromQuery] DateTime? fromDate = null,
            [FromQuery] DateTime? toDate = null)
        {
            try
            {
                // Normalize date range
                var hasDateFilter = fromDate.HasValue || toDate.HasValue;
                var rangeStart = fromDate?.Date ?? DateTime.UtcNow.Date.AddDays(-29);
                var rangeEnd = (toDate?.Date ?? DateTime.UtcNow.Date).AddDays(1).AddTicks(-1); // End of day

                // Base user query filtered by date range
                var usersQuery = _context.Users.Where(u => u.DeletedAt == null);
                var usersInRange = hasDateFilter
                    ? usersQuery.Where(u => u.CreatedAt >= rangeStart && u.CreatedAt <= rangeEnd)
                    : usersQuery;

                // 1-2. User counts
                int totalUsers = await usersInRange.CountAsync();
                int archivedCount = hasDateFilter
                    ? await _context.Users.Where(u => u.DeletedAt != null && u.CreatedAt >= rangeStart && u.CreatedAt <= rangeEnd).CountAsync()
                    : (await _userService.GetArchivedUsersAsync(new PaginationDto { PageNumber = 1, PageSize = 1 })).TotalCount;
                int activeUsers = totalUsers - archivedCount;

                // 3. Get total roles
                var rolesResponse = await _roleService.GetAllRolesAsync(new PaginationDto { PageNumber = 1, PageSize = 1 });
                int totalRoles = rolesResponse.TotalCount;

                // 4. Get total permissions
                var permissionsResponse = await _permissionService.GetAllPermissionsAsync(new PaginationDto { PageNumber = 1, PageSize = 1 });
                int totalPermissions = permissionsResponse.TotalCount;

                // 5. Recent users within range
                var recentUsers = await usersInRange
                    .Include(u => u.UserRoles).ThenInclude(ur => ur.Role)
                    .OrderByDescending(u => u.CreatedAt)
                    .Take(4)
                    .Select(u => new RecentUserDto
                    {
                        Id = u.Id,
                        Name = $"{u.FirstName} {u.LastName}".Trim(),
                        Email = u.Email,
                        Role = u.UserRoles.Select(ur => ur.Role.Name).FirstOrDefault() ?? "No Role",
                        Status = "Active",
                        JoinedDate = u.CreatedAt.ToString("MMM dd, yyyy")
                    })
                    .ToListAsync();

                // 6. Role distribution within range
                var roleDistribution = await usersInRange
                    .Include(u => u.UserRoles).ThenInclude(ur => ur.Role)
                    .ToListAsync();
                var roleDistList = roleDistribution
                    .GroupBy(u => u.UserRoles.Select(ur => ur.Role?.Name).FirstOrDefault() ?? "No Role")
                    .Select(g => new RoleDistributionDto
                    {
                        Role = g.Key,
                        Count = g.Count(),
                        Percentage = totalUsers > 0 ? (int)Math.Round((g.Count() / (double)totalUsers) * 100) : 0
                    })
                    .OrderByDescending(r => r.Count)
                    .ToList();

                // 7. Registration trends within range
                var registrationTrends = await GetRegistrationTrends(rangeStart, rangeEnd);

                // 8. Tutoring setup counts
                var minPage = new PaginationDto { PageNumber = 1, PageSize = 1 };
                var departmentsCount = (await _departmentService.GetAllDepartmentsAsync(minPage)).TotalCount;
                var subjectsCount = (await _subjectService.GetAllSubjectsAsync(minPage)).TotalCount;
                var buildingsCount = (await _buildingService.GetAllBuildingsAsync(minPage)).TotalCount;
                var roomsCount = (await _roomService.GetAllRoomsAsync(minPage)).TotalCount;
                var availableDaysCount = (await _availableDayService.GetAllAvailableDaysAsync(minPage)).TotalCount;
                var timeSlotsCount = (await _availableTimeSlotService.GetAllAvailableTimeSlotsAsync(minPage)).TotalCount;
                var teacherAssignmentsCount = (await _teacherAssignmentService.GetAllTeacherAssignmentsAsync(minPage)).TotalCount;

                // 8b. Tutoring setup breakdowns
                var subjectsPerDepartment = await _context.Subjects
                    .Where(s => s.DeletedAt == null)
                    .GroupBy(s => s.Department.Name)
                    .Select(g => new NameCountDto { Name = g.Key, Count = g.Count() })
                    .OrderByDescending(x => x.Count)
                    .ToListAsync();

                var roomsPerBuilding = await _context.Rooms
                    .Where(r => r.DeletedAt == null)
                    .GroupBy(r => r.Building.Name)
                    .Select(g => new NameCountDto { Name = g.Key, Count = g.Count() })
                    .OrderByDescending(x => x.Count)
                    .ToListAsync();

                var assignmentsPerDepartment = await _context.TeacherAssignments
                    .Where(a => a.DeletedAt == null)
                    .GroupBy(a => a.Department.Name)
                    .Select(g => new NameCountDto { Name = g.Key, Count = g.Count() })
                    .OrderByDescending(x => x.Count)
                    .ToListAsync();

                // 9. Tutoring request stats (filtered by date range)
                var requestsQuery = _context.TutoringRequests.Where(r => r.DeletedAt == null);
                if (hasDateFilter)
                    requestsQuery = requestsQuery.Where(r => r.CreatedAt >= rangeStart && r.CreatedAt <= rangeEnd);
                var requests = await requestsQuery.ToListAsync();

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

                var priorityDistribution = requests
                    .GroupBy(r => r.Priority)
                    .Select(g => new PriorityCountDto { Priority = g.Key, Count = g.Count() })
                    .ToList();

                var adminRequestTrends = GetRequestTrends(requests, true, rangeStart, rangeEnd);
                var studentRequestTrends = GetRequestTrends(requests, false, rangeStart, rangeEnd);

                var summary = new DashboardSummaryDto
                {
                    TotalUsers = totalUsers,
                    ActiveUsers = activeUsers,
                    TotalRoles = totalRoles,
                    TotalPermissions = totalPermissions,
                    RecentUsers = recentUsers,
                    RoleDistribution = roleDistList,
                    RegistrationTrends = registrationTrends,
                    TotalDepartments = departmentsCount,
                    TotalSubjects = subjectsCount,
                    TotalBuildings = buildingsCount,
                    TotalRooms = roomsCount,
                    TotalAvailableDays = availableDaysCount,
                    TotalTimeSlots = timeSlotsCount,
                    TotalTeacherAssignments = teacherAssignmentsCount,
                    SubjectsPerDepartment = subjectsPerDepartment,
                    RoomsPerBuilding = roomsPerBuilding,
                    AssignmentsPerDepartment = assignmentsPerDepartment,
                    TotalRequests = totalRequests,
                    ConfirmedSessions = confirmedSessions,
                    ActiveRequests = activeRequests,
                    CancelledRequests = cancelledRequests,
                    StatusDistribution = statusDistribution,
                    PriorityDistribution = priorityDistribution,
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
            var startDate = rangeStart.Date;
            var endDate = rangeEnd.Date;
            var totalDays = (int)(endDate - startDate).TotalDays + 1;

            var counts = await _context.Users
                .Where(u => u.DeletedAt == null && u.CreatedAt >= startDate && u.CreatedAt < endDate.AddDays(1))
                .GroupBy(u => u.CreatedAt.Date)
                .Select(g => new { Date = g.Key, Count = g.Count() })
                .ToDictionaryAsync(x => x.Date, x => x.Count);

            var trends = new List<int>();
            for (int i = 0; i < totalDays; i++)
            {
                var day = startDate.AddDays(i);
                trends.Add(counts.TryGetValue(day, out var c) ? c : 0);
            }
            return trends;
        }

        private static List<int> GetRequestTrends(List<TutoringRequest> requests, bool isAdminCreated, DateTime rangeStart, DateTime rangeEnd)
        {
            var startDate = rangeStart.Date;
            var endDate = rangeEnd.Date;
            var totalDays = (int)(endDate - startDate).TotalDays + 1;

            return Enumerable.Range(0, totalDays)
                .Select(i =>
                {
                    var day = startDate.AddDays(i);
                    return requests.Count(r => r.IsAdminCreated == isAdminCreated && r.CreatedAt.Date == day);
                })
                .ToList();
        }
    }
}
