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
    public class DashboardBuildingManagerController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public DashboardBuildingManagerController(ApplicationDbContext context)
        {
            _context = context;
        }

        private static readonly string[] OccupiedStatuses =
            { "Confirmed", "Waiting for Teacher Approval" };

        private static readonly string[] DayOrder =
            { "Monday", "Tuesday", "Wednesday", "Thursday", "Friday", "Saturday", "Sunday" };

        [HttpGet("summary")]
        public async Task<ActionResult<ApiResponse<BuildingManagerDashboardDto>>> GetDashboardSummary(
            [FromQuery] DateTime? fromDate = null,
            [FromQuery] DateTime? toDate = null)
        {
            try
            {
                var rangeStart = fromDate?.Date ?? DateTime.UtcNow.Date.AddDays(-29);
                var rangeEnd = (toDate?.Date ?? DateTime.UtcNow.Date).AddDays(1).AddTicks(-1);

                var userId = HttpContext.GetCurrentUserId();
                if (userId == null)
                    return Unauthorized(ApiResponse<BuildingManagerDashboardDto>.ErrorResponse("User not authenticated"));

                // Find building managed by this user
                var building = await _context.Buildings
                    .Include(b => b.Address)
                    .Where(b => b.ManagedBy == userId.Value && b.DeletedAt == null)
                    .FirstOrDefaultAsync();

                if (building == null)
                {
                    return Ok(ApiResponse<BuildingManagerDashboardDto>.SuccessResponse(
                        new BuildingManagerDashboardDto { HasBuilding = false },
                        "No building assigned"));
                }

                // Get rooms for this building
                var rooms = await _context.Rooms
                    .Where(r => r.BuildingId == building.Id && r.DeletedAt == null)
                    .OrderBy(r => r.Name)
                    .ToListAsync();

                // Get sessions for this building (with schedule data)
                var sessions = await _context.TutoringRequests
                    .Include(t => t.Student)
                    .Include(t => t.Subject)
                    .Include(t => t.Room)
                    .Include(t => t.AvailableDay)
                    .Include(t => t.AvailableTimeSlot)
                    .Include(t => t.AssignedTeacher)
                    .Where(t => t.BuildingId == building.Id
                        && t.DeletedAt == null
                        && t.RoomId != null
                        && OccupiedStatuses.Contains(t.Status)
                        && t.CreatedAt >= rangeStart
                        && t.CreatedAt <= rangeEnd)
                    .ToListAsync();

                var todayName = DayOrder[((int)DateTime.Now.DayOfWeek + 6) % 7]; // Monday=0
                todayName = DateTime.Now.DayOfWeek switch
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

                // Build room DTOs with status
                var roomDtos = rooms.Select(room =>
                {
                    if (!room.IsActive)
                    {
                        return new BuildingManagerRoomDto
                        {
                            Id = room.Id,
                            Name = room.Name,
                            Capacity = room.Capacity,
                            IsActive = false,
                            Status = "Maintenance",
                            CurrentSession = null
                        };
                    }

                    var activeSession = sessions.FirstOrDefault(s => s.RoomId == room.Id);
                    return new BuildingManagerRoomDto
                    {
                        Id = room.Id,
                        Name = room.Name,
                        Capacity = room.Capacity,
                        IsActive = true,
                        Status = activeSession != null ? "Occupied" : "Available",
                        CurrentSession = activeSession != null ? MapSession(activeSession) : null
                    };
                }).ToList();

                // Today's sessions
                var todaySessions = sessions
                    .Where(s => s.AvailableDay?.DayName == todayName)
                    .OrderBy(s => s.AvailableTimeSlot?.Label ?? "")
                    .Select(MapSession)
                    .ToList();

                // Upcoming sessions (not today), sorted by day distance
                var todayIdx = Array.IndexOf(DayOrder, todayName);
                var upcomingSessions = sessions
                    .Where(s => s.AvailableDay?.DayName != null && s.AvailableDay.DayName != todayName)
                    .OrderBy(s =>
                    {
                        var idx = Array.IndexOf(DayOrder, s.AvailableDay!.DayName);
                        return idx >= todayIdx ? idx - todayIdx : idx + 7 - todayIdx;
                    })
                    .ThenBy(s => s.AvailableTimeSlot?.Label ?? "")
                    .Select(MapSession)
                    .ToList();

                var addressLine = building.Address != null
                    ? $"{building.Address.StreetBarangay}, {building.Address.CityMunicipality}, {building.Address.Province}"
                    : null;

                var dto = new BuildingManagerDashboardDto
                {
                    HasBuilding = true,
                    BuildingName = building.Name,
                    AddressLine = addressLine,
                    IsActive = building.IsActive,
                    TotalRooms = rooms.Count,
                    AvailableRooms = roomDtos.Count(r => r.Status == "Available"),
                    OccupiedRooms = roomDtos.Count(r => r.Status == "Occupied"),
                    MaintenanceRooms = roomDtos.Count(r => r.Status == "Maintenance"),
                    TodaySessionsCount = todaySessions.Count,
                    Rooms = roomDtos,
                    TodaySessions = todaySessions,
                    UpcomingSessions = upcomingSessions
                };

                return Ok(ApiResponse<BuildingManagerDashboardDto>.SuccessResponse(dto, "Dashboard data retrieved"));
            }
            catch (Exception ex)
            {
                return StatusCode(500, ApiResponse<BuildingManagerDashboardDto>.ErrorResponse(
                    "An error occurred", new List<string> { ex.Message }));
            }
        }

        private static DashboardSessionItemDto MapSession(NexUs.Models.Entities.TutoringRequest t) => new()
        {
            Id = t.Id,
            SubjectName = t.Subject?.Name ?? "",
            StudentName = t.Student != null ? $"{t.Student.FirstName} {t.Student.LastName}" : "",
            BuildingName = "",
            RoomName = t.Room?.Name,
            DayName = t.AvailableDay?.DayName,
            TimeSlotLabel = t.AvailableTimeSlot?.Label,
            AssignedTeacherName = t.AssignedTeacher != null ? $"{t.AssignedTeacher.FirstName} {t.AssignedTeacher.LastName}" : null,
            ConfirmedAt = t.ConfirmedAt
        };
    }
}
