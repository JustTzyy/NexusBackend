using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NexUs.Attributes;
using NexUs.Data;
using NexUs.Extensions;
using NexUs.Models.DTO.Common;
using NexUs.Models.DTO.TeacherAvailabilities;
using NexUs.Models.Entities;
using NexUs.Services.Interfaces;

namespace NexUs.Controllers
{
    [Route("api/teacher-availability")]
    [ApiController]
    [Authorize]
    public class TeacherAvailabilityController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        private readonly IAuditService _auditService;

        public TeacherAvailabilityController(ApplicationDbContext context, IAuditService auditService)
        {
            _context = context;
            _auditService = auditService;
        }

        /// <summary>
        /// Get current teacher's own availability (no permission required)
        /// </summary>
        [HttpGet("me")]
        public async Task<ActionResult<ApiResponse<TeacherAvailabilityResultDto>>> GetMyAvailability()
        {
            try
            {
                var userId = HttpContext.GetCurrentUserId();
                if (userId == null)
                    return Unauthorized(ApiResponse<TeacherAvailabilityResultDto>.ErrorResponse("Unauthorized"));

                var rows = await _context.TeacherAvailabilities
                    .Where(a => a.TeacherId == userId.Value && a.DeletedAt == null)
                    .Select(a => new TeacherAvailabilitySlotDto
                    {
                        DayId = a.AvailableDayId,
                        TimeSlotId = a.AvailableTimeSlotId,
                    })
                    .ToListAsync();

                var result = new TeacherAvailabilityResultDto
                {
                    TeacherId = userId.Value,
                    AvailableDayIds = rows.Select(r => r.DayId).Distinct().ToList(),
                    Slots = rows,
                };

                return Ok(ApiResponse<TeacherAvailabilityResultDto>.SuccessResponse(result, "Availability retrieved successfully"));
            }
            catch (Exception)
            {
                return StatusCode(500, ApiResponse<TeacherAvailabilityResultDto>.ErrorResponse(
                    "An error occurred while retrieving availability"));
            }
        }

        /// <summary>
        /// Update current teacher's own availability (no permission required)
        /// </summary>
        [HttpPut("me")]
        public async Task<ActionResult<ApiResponse<TeacherAvailabilityResultDto>>> SetMyAvailability(
            [FromBody] UpdateTeacherAvailabilityDto dto)
        {
            var userId = HttpContext.GetCurrentUserId();
            if (userId == null)
                return Unauthorized(ApiResponse<TeacherAvailabilityResultDto>.ErrorResponse("Unauthorized"));

            return await SetAvailability(userId.Value, dto);
        }

        /// <summary>
        /// Get availability for a teacher (list of day+timeslot pairs they have enabled).
        /// </summary>
        [RequirePermission("ViewTeacherAssignments")]
        [HttpGet("{teacherId}")]
        public async Task<ActionResult<ApiResponse<TeacherAvailabilityResultDto>>> GetAvailability(int teacherId)
        {
            try
            {
                var rows = await _context.TeacherAvailabilities
                    .Where(a => a.TeacherId == teacherId && a.DeletedAt == null)
                    .Select(a => new TeacherAvailabilitySlotDto
                    {
                        DayId = a.AvailableDayId,
                        TimeSlotId = a.AvailableTimeSlotId,
                    })
                    .ToListAsync();

                var result = new TeacherAvailabilityResultDto
                {
                    TeacherId = teacherId,
                    AvailableDayIds = rows.Select(r => r.DayId).Distinct().ToList(),
                    Slots = rows,
                };

                return Ok(ApiResponse<TeacherAvailabilityResultDto>.SuccessResponse(result, "Availability retrieved successfully"));
            }
            catch (Exception)
            {
                return StatusCode(500, ApiResponse<TeacherAvailabilityResultDto>.ErrorResponse(
                    "An error occurred while retrieving availability"));
            }
        }

        /// <summary>
        /// Replace a teacher's entire availability with the posted list of day+timeslot pairs.
        /// Callable by the teacher themselves (own profile) or by an admin.
        /// </summary>
        [RequirePermission("UpdateTeacherAssignments")]
        [HttpPut("{teacherId}")]
        public async Task<ActionResult<ApiResponse<TeacherAvailabilityResultDto>>> SetAvailability(
            int teacherId,
            [FromBody] UpdateTeacherAvailabilityDto dto)
        {
            try
            {
                var currentUserId = HttpContext.GetCurrentUserId();

                // â”€â”€ Guard: check if any slot being removed has an active scheduled session â”€â”€
                var activeStatuses = new[] { "Confirmed", "Waiting for Teacher Approval", "Teacher Assigned" };

                // Build the set of slots the incoming request contains
                var incomingSet = dto.Slots
                    .Select(s => $"{s.DayId}-{s.TimeSlotId}")
                    .ToHashSet();

                // Slots that currently exist but are NOT in the incoming set â†’ being removed
                var currentSlots = await _context.TeacherAvailabilities
                    .Where(a => a.TeacherId == teacherId && a.DeletedAt == null)
                    .Select(a => new { a.AvailableDayId, a.AvailableTimeSlotId })
                    .ToListAsync();

                var removedSlots = currentSlots
                    .Where(s => !incomingSet.Contains($"{s.AvailableDayId}-{s.AvailableTimeSlotId}"))
                    .ToList();

                if (removedSlots.Any())
                {
                    // Check each removed slot for active sessions
                    var blockedDescriptions = new List<string>();

                    foreach (var removed in removedSlots)
                    {
                        var conflict = await _context.TutoringRequests
                            .Include(t => t.AvailableDay)
                            .Include(t => t.AvailableTimeSlot)
                            .Where(t => t.AssignedTeacherId == teacherId
                                     && t.AvailableDayId == removed.AvailableDayId
                                     && t.AvailableTimeSlotId == removed.AvailableTimeSlotId
                                     && activeStatuses.Contains(t.Status)
                                     && t.DeletedAt == null)
                            .Select(t => new
                            {
                                t.Id,
                                DayName = t.AvailableDay != null ? t.AvailableDay.DayName : "Unknown day",
                                TimeSlot = t.AvailableTimeSlot != null
                                    ? $"{t.AvailableTimeSlot.StartTime} â€“ {t.AvailableTimeSlot.EndTime}"
                                    : "Unknown time",
                                t.Status,
                            })
                            .FirstOrDefaultAsync();

                        if (conflict != null)
                            blockedDescriptions.Add(
                                $"{conflict.DayName} {conflict.TimeSlot} (Session #{conflict.Id}, Status: {conflict.Status})");
                    }

                    if (blockedDescriptions.Any())
                    {
                        var message = "Cannot remove availability for slot(s) that have active scheduled sessions. " +
                                      "Please withdraw or cancel the following sessions first: " +
                                      string.Join("; ", blockedDescriptions);

                        return Conflict(ApiResponse<TeacherAvailabilityResultDto>.ErrorResponse(
                            message, blockedDescriptions));
                    }
                }

                // â”€â”€ Proceed with the update â”€â”€

                // Remove all existing rows for this teacher
                var existing = await _context.TeacherAvailabilities
                    .Where(a => a.TeacherId == teacherId)
                    .ToListAsync();

                _context.TeacherAvailabilities.RemoveRange(existing);

                // Insert new rows
                var newRows = dto.Slots
                    .DistinctBy(s => $"{s.DayId}-{s.TimeSlotId}")
                    .Select(s => new TeacherAvailability
                    {
                        TeacherId = teacherId,
                        AvailableDayId = s.DayId,
                        AvailableTimeSlotId = s.TimeSlotId,
                        CreatedBy = currentUserId,
                        UpdatedBy = currentUserId,
                    });

                await _context.TeacherAvailabilities.AddRangeAsync(newRows);
                await _context.SaveChangesAsync();

                // Return updated availability
                var saved = await _context.TeacherAvailabilities
                    .Where(a => a.TeacherId == teacherId && a.DeletedAt == null)
                    .Select(a => new TeacherAvailabilitySlotDto
                    {
                        DayId = a.AvailableDayId,
                        TimeSlotId = a.AvailableTimeSlotId,
                    })
                    .ToListAsync();

                var result = new TeacherAvailabilityResultDto
                {
                    TeacherId = teacherId,
                    AvailableDayIds = saved.Select(r => r.DayId).Distinct().ToList(),
                    Slots = saved,
                };

                // Audit: notify admins that availability was updated
                var teacher = await _context.Users
                    .Where(u => u.Id == teacherId)
                    .Select(u => new { u.FirstName, u.LastName })
                    .FirstOrDefaultAsync();

                var changedBy = currentUserId == teacherId ? "the teacher themselves" : $"admin (userId: {currentUserId})";
                var teacherName = teacher != null ? $"{teacher.FirstName} {teacher.LastName}" : $"TeacherId {teacherId}";
                var slotCount = saved.Count;

                await _auditService.LogAsync(
                    module: "Teacher Availability",
                    action: "Updated",
                    details: $"Availability for teacher '{teacherName}' was updated by {changedBy}. Total slots set: {slotCount}.",
                    userId: currentUserId
                );

                return Ok(ApiResponse<TeacherAvailabilityResultDto>.SuccessResponse(result, "Availability updated successfully"));
            }
            catch (Exception)
            {
                return StatusCode(500, ApiResponse<TeacherAvailabilityResultDto>.ErrorResponse(
                    "An error occurred while updating availability"));
            }
        }
    }
}
