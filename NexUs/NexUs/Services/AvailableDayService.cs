using Microsoft.EntityFrameworkCore;
using NexUs.Data;
using NexUs.Models.DTO.Common;
using NexUs.Models.DTO.AvailableDays;
using NexUs.Models.Entities;
using NexUs.Services.Interfaces;

namespace NexUs.Services
{
    public class AvailableDayService : IAvailableDayService
    {
        private readonly ApplicationDbContext _context;
        private readonly IAuditService _auditService;

        public AvailableDayService(
            ApplicationDbContext context,
            IAuditService auditService)
        {
            _context = context;
            _auditService = auditService;
        }

        public async Task<PagedResultDto<AvailableDayListDto>> GetAllAvailableDaysAsync(PaginationDto pagination)
        {
            var query = _context.AvailableDays
                .Where(a => a.DeletedAt == null)
                .AsQueryable();

            if (!string.IsNullOrEmpty(pagination.SearchTerm))
            {
                var searchLower = pagination.SearchTerm.ToLower();
                query = query.Where(a =>
                    a.DayName.ToLower().Contains(searchLower));
            }

            var totalCount = await query.CountAsync();

            query = (pagination.SortBy?.ToLower(), pagination.SortDescending) switch
            {
                ("dayname", true) => query.OrderByDescending(a => a.DayName),
                ("dayname", false) => query.OrderBy(a => a.DayName),
                ("sortorder", true) => query.OrderByDescending(a => a.SortOrder),
                ("sortorder", false) => query.OrderBy(a => a.SortOrder),
                ("createdat", true) => query.OrderByDescending(a => a.CreatedAt),
                ("createdat", false) => query.OrderBy(a => a.CreatedAt),
                ("updatedat", true) => query.OrderByDescending(a => a.UpdatedAt),
                ("updatedat", false) => query.OrderBy(a => a.UpdatedAt),
                _ => query.OrderBy(a => a.SortOrder)
            };

            var days = await query
                .Skip((pagination.PageNumber - 1) * pagination.PageSize)
                .Take(pagination.PageSize)
                .ToListAsync();

            var items = days.Select(a => new AvailableDayListDto
            {
                Id = a.Id,
                DayName = a.DayName,
                SortOrder = a.SortOrder,
                IsActive = a.IsActive,
                CreatedAt = a.CreatedAt,
                UpdatedAt = a.UpdatedAt
            }).ToList();

            return new PagedResultDto<AvailableDayListDto>
            {
                Items = items,
                TotalCount = totalCount,
                PageNumber = pagination.PageNumber,
                PageSize = pagination.PageSize
            };
        }

        public async Task<AvailableDayResponseDto?> GetAvailableDayByIdAsync(int id)
        {
            var day = await _context.AvailableDays
                .IgnoreQueryFilters()
                .Include(a => a.CreatedByUser)
                .Include(a => a.UpdatedByUser)
                .FirstOrDefaultAsync(a => a.Id == id);

            if (day == null) return null;

            return new AvailableDayResponseDto
            {
                Id = day.Id,
                DayName = day.DayName,
                SortOrder = day.SortOrder,
                IsActive = day.IsActive,
                CreatedAt = day.CreatedAt,
                UpdatedAt = day.UpdatedAt,
                DeletedAt = day.DeletedAt,
                CreatedBy = day.CreatedBy,
                UpdatedBy = day.UpdatedBy,
                CreatedByName = day.CreatedByUser != null
                    ? $"{day.CreatedByUser.FirstName} {day.CreatedByUser.LastName}".Trim()
                    : null,
                UpdatedByName = day.UpdatedByUser != null
                    ? $"{day.UpdatedByUser.FirstName} {day.UpdatedByUser.LastName}".Trim()
                    : null
            };
        }

        public async Task<PagedResultDto<AvailableDayListDto>> GetArchivedAvailableDaysAsync(PaginationDto pagination)
        {
            var query = _context.AvailableDays
                .IgnoreQueryFilters()
                .Where(a => a.DeletedAt != null)
                .AsQueryable();

            if (!string.IsNullOrEmpty(pagination.SearchTerm))
            {
                var searchLower = pagination.SearchTerm.ToLower();
                query = query.Where(a =>
                    a.DayName.ToLower().Contains(searchLower));
            }

            var totalCount = await query.CountAsync();

            var days = await query
                .OrderByDescending(a => a.DeletedAt)
                .Skip((pagination.PageNumber - 1) * pagination.PageSize)
                .Take(pagination.PageSize)
                .ToListAsync();

            var items = days.Select(a => new AvailableDayListDto
            {
                Id = a.Id,
                DayName = a.DayName,
                SortOrder = a.SortOrder,
                IsActive = a.IsActive,
                CreatedAt = a.CreatedAt,
                UpdatedAt = a.UpdatedAt,
                DeletedAt = a.DeletedAt
            }).ToList();

            return new PagedResultDto<AvailableDayListDto>
            {
                Items = items,
                TotalCount = totalCount,
                PageNumber = pagination.PageNumber,
                PageSize = pagination.PageSize
            };
        }

        public async Task<AvailableDayResponseDto> CreateAvailableDayAsync(CreateAvailableDayDto dto, int? currentUserId)
        {
            var existingByName = await _context.AvailableDays
                .FirstOrDefaultAsync(a =>
                    a.DayName.ToLower() == dto.DayName.ToLower() &&
                    a.DeletedAt == null);

            if (existingByName != null)
            {
                throw new InvalidOperationException($"An available day with the name '{dto.DayName}' already exists.");
            }

            var day = new AvailableDay
            {
                DayName = dto.DayName,
                SortOrder = dto.SortOrder,
                IsActive = dto.IsActive,
                CreatedBy = currentUserId,
                UpdatedBy = currentUserId
            };

            _context.AvailableDays.Add(day);
            await _context.SaveChangesAsync();

            var createDetails = $"Created available day: {day.DayName}, SortOrder: {day.SortOrder}, IsActive: {day.IsActive}";
            await _auditService.LogAsync("AvailableDays", "Create", createDetails, currentUserId);

            return (await GetAvailableDayByIdAsync(day.Id))!;
        }

        public async Task<AvailableDayResponseDto?> UpdateAvailableDayAsync(int id, UpdateAvailableDayDto dto, int? currentUserId)
        {
            var day = await _context.AvailableDays
                .FirstOrDefaultAsync(a => a.Id == id && a.DeletedAt == null);

            if (day == null) return null;

            var changes = new List<string>();
            var originalName = day.DayName;

            if (!string.IsNullOrEmpty(dto.DayName) && dto.DayName.ToLower() != day.DayName.ToLower())
            {
                var existingByName = await _context.AvailableDays
                    .FirstOrDefaultAsync(a =>
                        a.DayName.ToLower() == dto.DayName.ToLower() &&
                        a.Id != id &&
                        a.DeletedAt == null);

                if (existingByName != null)
                {
                    throw new InvalidOperationException($"An available day with the name '{dto.DayName}' already exists.");
                }

                changes.Add($"DayName: {day.DayName} → {dto.DayName}");
                day.DayName = dto.DayName;
            }

            if (dto.SortOrder.HasValue && dto.SortOrder.Value != day.SortOrder)
            {
                changes.Add($"SortOrder: {day.SortOrder} → {dto.SortOrder.Value}");
                day.SortOrder = dto.SortOrder.Value;
            }

            if (dto.IsActive.HasValue && dto.IsActive.Value != day.IsActive)
            {
                changes.Add($"IsActive: {day.IsActive} → {dto.IsActive.Value}");
                day.IsActive = dto.IsActive.Value;
            }

            day.UpdatedBy = currentUserId;
            await _context.SaveChangesAsync();

            var updateDetails = changes.Any()
                ? $"Updated available day: {originalName} -> {string.Join(", ", changes)}"
                : $"Updated available day: {originalName} (no changes detected)";
            await _auditService.LogAsync("AvailableDays", "Update", updateDetails, currentUserId);

            return await GetAvailableDayByIdAsync(day.Id);
        }

        public async Task<bool> DeleteAvailableDayAsync(int id, int? currentUserId)
        {
            var day = await _context.AvailableDays
                .FirstOrDefaultAsync(a => a.Id == id && a.DeletedAt == null);

            if (day == null) return false;

            day.IsActive = false;
            day.DeletedAt = DateTime.UtcNow;
            day.UpdatedBy = currentUserId;

            await _context.SaveChangesAsync();

            var deleteDetails = $"Soft deleted available day: {day.DayName}";
            await _auditService.LogAsync("AvailableDays", "Delete", deleteDetails, currentUserId);

            return true;
        }

        public async Task<bool> RestoreAvailableDayAsync(int id, int? currentUserId)
        {
            var day = await _context.AvailableDays.IgnoreQueryFilters()
                .FirstOrDefaultAsync(a => a.Id == id && a.DeletedAt != null);

            if (day == null) return false;

            day.IsActive = true;
            day.DeletedAt = null;
            day.UpdatedBy = currentUserId;

            await _context.SaveChangesAsync();

            var restoreDetails = $"Restored available day: {day.DayName}";
            await _auditService.LogAsync("AvailableDays", "Restore", restoreDetails, currentUserId);

            return true;
        }

        public async Task<bool> PermanentDeleteAvailableDayAsync(int id, int? currentUserId)
        {
            var day = await _context.AvailableDays.IgnoreQueryFilters()
                .FirstOrDefaultAsync(a => a.Id == id && a.DeletedAt != null);

            if (day == null) return false;

            var dayName = day.DayName;

            _context.AvailableDays.Remove(day);
            await _context.SaveChangesAsync();

            var permanentDeleteDetails = $"Permanently deleted available day: {dayName}";
            await _auditService.LogAsync("AvailableDays", "PermanentDelete", permanentDeleteDetails, currentUserId);

            return true;
        }
    }
}
