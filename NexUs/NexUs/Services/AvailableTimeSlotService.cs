using Microsoft.EntityFrameworkCore;
using NexUs.Data;
using NexUs.Models.DTO.Common;
using NexUs.Models.DTO.AvailableTimeSlots;
using NexUs.Models.Entities;
using NexUs.Services.Interfaces;

namespace NexUs.Services
{
    public class AvailableTimeSlotService : IAvailableTimeSlotService
    {
        private readonly ApplicationDbContext _context;
        private readonly IAuditService _auditService;

        public AvailableTimeSlotService(
            ApplicationDbContext context,
            IAuditService auditService)
        {
            _context = context;
            _auditService = auditService;
        }

        public async Task<PagedResultDto<AvailableTimeSlotListDto>> GetAllAvailableTimeSlotsAsync(PaginationDto pagination)
        {
            var query = _context.AvailableTimeSlots
                .Where(a => a.DeletedAt == null)
                .AsQueryable();

            if (!string.IsNullOrEmpty(pagination.SearchTerm))
            {
                var searchLower = pagination.SearchTerm.ToLower();
                query = query.Where(a =>
                    a.Label.ToLower().Contains(searchLower));
            }

            var totalCount = await query.CountAsync();

            query = (pagination.SortBy?.ToLower(), pagination.SortDescending) switch
            {
                ("label", true) => query.OrderByDescending(a => a.Label),
                ("label", false) => query.OrderBy(a => a.Label),
                ("starttime", true) => query.OrderByDescending(a => a.StartTime),
                ("starttime", false) => query.OrderBy(a => a.StartTime),
                ("createdat", true) => query.OrderByDescending(a => a.CreatedAt),
                ("createdat", false) => query.OrderBy(a => a.CreatedAt),
                ("updatedat", true) => query.OrderByDescending(a => a.UpdatedAt),
                ("updatedat", false) => query.OrderBy(a => a.UpdatedAt),
                _ => query.OrderBy(a => a.StartTime)
            };

            var slots = await query
                .Skip((pagination.PageNumber - 1) * pagination.PageSize)
                .Take(pagination.PageSize)
                .ToListAsync();

            var items = slots.Select(a => new AvailableTimeSlotListDto
            {
                Id = a.Id,
                Label = a.Label,
                StartTime = a.StartTime,
                EndTime = a.EndTime,
                IsActive = a.IsActive,
                CreatedAt = a.CreatedAt,
                UpdatedAt = a.UpdatedAt
            }).ToList();

            return new PagedResultDto<AvailableTimeSlotListDto>
            {
                Items = items,
                TotalCount = totalCount,
                PageNumber = pagination.PageNumber,
                PageSize = pagination.PageSize
            };
        }

        public async Task<AvailableTimeSlotResponseDto?> GetAvailableTimeSlotByIdAsync(int id)
        {
            var slot = await _context.AvailableTimeSlots
                .IgnoreQueryFilters()
                .Include(a => a.CreatedByUser)
                .Include(a => a.UpdatedByUser)
                .FirstOrDefaultAsync(a => a.Id == id);

            if (slot == null) return null;

            return new AvailableTimeSlotResponseDto
            {
                Id = slot.Id,
                Label = slot.Label,
                StartTime = slot.StartTime,
                EndTime = slot.EndTime,
                IsActive = slot.IsActive,
                CreatedAt = slot.CreatedAt,
                UpdatedAt = slot.UpdatedAt,
                DeletedAt = slot.DeletedAt,
                CreatedBy = slot.CreatedBy,
                UpdatedBy = slot.UpdatedBy,
                CreatedByName = slot.CreatedByUser != null
                    ? $"{slot.CreatedByUser.FirstName} {slot.CreatedByUser.LastName}".Trim()
                    : null,
                UpdatedByName = slot.UpdatedByUser != null
                    ? $"{slot.UpdatedByUser.FirstName} {slot.UpdatedByUser.LastName}".Trim()
                    : null
            };
        }

        public async Task<PagedResultDto<AvailableTimeSlotListDto>> GetArchivedAvailableTimeSlotsAsync(PaginationDto pagination)
        {
            var query = _context.AvailableTimeSlots
                .IgnoreQueryFilters()
                .Where(a => a.DeletedAt != null)
                .AsQueryable();

            if (!string.IsNullOrEmpty(pagination.SearchTerm))
            {
                var searchLower = pagination.SearchTerm.ToLower();
                query = query.Where(a =>
                    a.Label.ToLower().Contains(searchLower));
            }

            var totalCount = await query.CountAsync();

            var slots = await query
                .OrderByDescending(a => a.DeletedAt)
                .Skip((pagination.PageNumber - 1) * pagination.PageSize)
                .Take(pagination.PageSize)
                .ToListAsync();

            var items = slots.Select(a => new AvailableTimeSlotListDto
            {
                Id = a.Id,
                Label = a.Label,
                StartTime = a.StartTime,
                EndTime = a.EndTime,
                IsActive = a.IsActive,
                CreatedAt = a.CreatedAt,
                UpdatedAt = a.UpdatedAt,
                DeletedAt = a.DeletedAt
            }).ToList();

            return new PagedResultDto<AvailableTimeSlotListDto>
            {
                Items = items,
                TotalCount = totalCount,
                PageNumber = pagination.PageNumber,
                PageSize = pagination.PageSize
            };
        }

        public async Task<AvailableTimeSlotResponseDto> CreateAvailableTimeSlotAsync(CreateAvailableTimeSlotDto dto, int? currentUserId)
        {
            // Check for duplicate label
            var existingByLabel = await _context.AvailableTimeSlots
                .FirstOrDefaultAsync(a =>
                    a.Label.ToLower() == dto.Label.ToLower() &&
                    a.DeletedAt == null);

            if (existingByLabel != null)
            {
                throw new InvalidOperationException($"A time slot with the label '{dto.Label}' already exists.");
            }

            // Check for duplicate StartTime + EndTime combo
            var existingByTime = await _context.AvailableTimeSlots
                .FirstOrDefaultAsync(a =>
                    a.StartTime == dto.StartTime &&
                    a.EndTime == dto.EndTime &&
                    a.DeletedAt == null);

            if (existingByTime != null)
            {
                throw new InvalidOperationException($"A time slot with the time range '{dto.StartTime} - {dto.EndTime}' already exists.");
            }

            var slot = new AvailableTimeSlot
            {
                Label = dto.Label,
                StartTime = dto.StartTime,
                EndTime = dto.EndTime,
                IsActive = dto.IsActive,
                CreatedBy = currentUserId,
                UpdatedBy = currentUserId
            };

            _context.AvailableTimeSlots.Add(slot);
            await _context.SaveChangesAsync();

            var createDetails = $"Created time slot: {slot.Label} ({slot.StartTime} - {slot.EndTime}), IsActive: {slot.IsActive}";
            await _auditService.LogAsync("AvailableTimeSlots", "Create", createDetails, currentUserId);

            return (await GetAvailableTimeSlotByIdAsync(slot.Id))!;
        }

        public async Task<AvailableTimeSlotResponseDto?> UpdateAvailableTimeSlotAsync(int id, UpdateAvailableTimeSlotDto dto, int? currentUserId)
        {
            var slot = await _context.AvailableTimeSlots
                .FirstOrDefaultAsync(a => a.Id == id && a.DeletedAt == null);

            if (slot == null) return null;

            var changes = new List<string>();
            var originalLabel = slot.Label;

            if (!string.IsNullOrEmpty(dto.Label) && dto.Label.ToLower() != slot.Label.ToLower())
            {
                var existingByLabel = await _context.AvailableTimeSlots
                    .FirstOrDefaultAsync(a =>
                        a.Label.ToLower() == dto.Label.ToLower() &&
                        a.Id != id &&
                        a.DeletedAt == null);

                if (existingByLabel != null)
                {
                    throw new InvalidOperationException($"A time slot with the label '{dto.Label}' already exists.");
                }

                changes.Add($"Label: {slot.Label} → {dto.Label}");
                slot.Label = dto.Label;
            }

            if (!string.IsNullOrEmpty(dto.StartTime) && dto.StartTime != slot.StartTime)
            {
                changes.Add($"StartTime: {slot.StartTime} → {dto.StartTime}");
                slot.StartTime = dto.StartTime;
            }

            if (!string.IsNullOrEmpty(dto.EndTime) && dto.EndTime != slot.EndTime)
            {
                changes.Add($"EndTime: {slot.EndTime} → {dto.EndTime}");
                slot.EndTime = dto.EndTime;
            }

            if (dto.IsActive.HasValue && dto.IsActive.Value != slot.IsActive)
            {
                changes.Add($"IsActive: {slot.IsActive} → {dto.IsActive.Value}");
                slot.IsActive = dto.IsActive.Value;
            }

            slot.UpdatedBy = currentUserId;
            await _context.SaveChangesAsync();

            var updateDetails = changes.Any()
                ? $"Updated time slot: {originalLabel} -> {string.Join(", ", changes)}"
                : $"Updated time slot: {originalLabel} (no changes detected)";
            await _auditService.LogAsync("AvailableTimeSlots", "Update", updateDetails, currentUserId);

            return await GetAvailableTimeSlotByIdAsync(slot.Id);
        }

        public async Task<bool> DeleteAvailableTimeSlotAsync(int id, int? currentUserId)
        {
            var slot = await _context.AvailableTimeSlots
                .FirstOrDefaultAsync(a => a.Id == id && a.DeletedAt == null);

            if (slot == null) return false;

            slot.IsActive = false;
            slot.DeletedAt = DateTime.UtcNow;
            slot.UpdatedBy = currentUserId;

            await _context.SaveChangesAsync();

            var deleteDetails = $"Soft deleted time slot: {slot.Label}";
            await _auditService.LogAsync("AvailableTimeSlots", "Delete", deleteDetails, currentUserId);

            return true;
        }

        public async Task<bool> RestoreAvailableTimeSlotAsync(int id, int? currentUserId)
        {
            var slot = await _context.AvailableTimeSlots.IgnoreQueryFilters()
                .FirstOrDefaultAsync(a => a.Id == id && a.DeletedAt != null);

            if (slot == null) return false;

            slot.IsActive = true;
            slot.DeletedAt = null;
            slot.UpdatedBy = currentUserId;

            await _context.SaveChangesAsync();

            var restoreDetails = $"Restored time slot: {slot.Label}";
            await _auditService.LogAsync("AvailableTimeSlots", "Restore", restoreDetails, currentUserId);

            return true;
        }

        public async Task<bool> PermanentDeleteAvailableTimeSlotAsync(int id, int? currentUserId)
        {
            var slot = await _context.AvailableTimeSlots.IgnoreQueryFilters()
                .FirstOrDefaultAsync(a => a.Id == id && a.DeletedAt != null);

            if (slot == null) return false;

            var slotLabel = slot.Label;

            _context.AvailableTimeSlots.Remove(slot);
            await _context.SaveChangesAsync();

            var permanentDeleteDetails = $"Permanently deleted time slot: {slotLabel}";
            await _auditService.LogAsync("AvailableTimeSlots", "PermanentDelete", permanentDeleteDetails, currentUserId);

            return true;
        }
    }
}
