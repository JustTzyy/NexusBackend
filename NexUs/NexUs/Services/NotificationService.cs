using Microsoft.EntityFrameworkCore;
using NexUs.Data;
using NexUs.Models.DTO.Common;
using NexUs.Models.DTO.Notifications;
using NexUs.Models.Entities;
using NexUs.Services.Interfaces;
using NexUs.Utilities;

namespace NexUs.Services
{
    public class NotificationService : INotificationService
    {
        private readonly ApplicationDbContext _context;

        public NotificationService(ApplicationDbContext context)
        {
            _context = context;
        }

        private static NotificationListDto ToListDto(Notification n) => new()
        {
            Id = n.Id,
            RecipientUserId = n.RecipientUserId,
            RecipientRole = n.RecipientRole,
            RecipientName = n.Recipient != null ? $"{n.Recipient.FirstName} {n.Recipient.LastName}".Trim() : null,
            Title = n.Title,
            Message = n.Message,
            Type = n.Type,
            Priority = n.Priority,
            Status = n.Status,
            ReadAt = n.ReadAt,
            ReferenceId = n.ReferenceId,
            ReferenceType = n.ReferenceType,
            CreatedAt = n.CreatedAt
        };

        private IQueryable<Notification> BaseQuery() => _context.Notifications
            .Include(n => n.Recipient)
            .Include(n => n.CreatedByUser);

        public async Task<PagedResultDto<NotificationListDto>> GetAllAsync(PaginationDto pagination, int? userId = null, string? type = null)
        {
            var query = BaseQuery().Where(n => n.DeletedAt == null);

            if (userId.HasValue)
            {
                // Get notifications targeted to this specific user OR to any of their roles
                var userRoles = await _context.UserRoles
                    .Where(ur => ur.UserId == userId.Value)
                    .Include(ur => ur.Role)
                    .Select(ur => ur.Role.Name)
                    .ToListAsync();

                query = query.Where(n =>
                    n.RecipientUserId == userId.Value ||
                    (n.RecipientRole != null && userRoles.Contains(n.RecipientRole)));
            }

            if (!string.IsNullOrEmpty(type) && type != "all")
                query = query.Where(n => n.Type == type);

            if (!string.IsNullOrEmpty(pagination.SearchTerm))
            {
                var term = pagination.SearchTerm.ToLower();
                query = query.Where(n => n.Title.ToLower().Contains(term) || n.Message.ToLower().Contains(term));
            }

            var totalCount = await query.CountAsync();
            var items = await query.OrderByDescending(n => n.CreatedAt)
                .Skip((pagination.PageNumber - 1) * pagination.PageSize)
                .Take(pagination.PageSize)
                .ToListAsync();

            return new PagedResultDto<NotificationListDto>
            {
                Items = items.Select(ToListDto).ToList(),
                TotalCount = totalCount,
                PageNumber = pagination.PageNumber,
                PageSize = pagination.PageSize
            };
        }

        public async Task<NotificationResponseDto?> GetByIdAsync(int id)
        {
            var n = await BaseQuery().FirstOrDefaultAsync(x => x.Id == id && x.DeletedAt == null);
            if (n == null) return null;

            return new NotificationResponseDto
            {
                Id = n.Id,
                RecipientUserId = n.RecipientUserId,
                RecipientRole = n.RecipientRole,
                RecipientName = n.Recipient != null ? $"{n.Recipient.FirstName} {n.Recipient.LastName}".Trim() : null,
                Title = n.Title,
                Message = n.Message,
                Type = n.Type,
                Priority = n.Priority,
                Status = n.Status,
                ReadAt = n.ReadAt,
                ReferenceId = n.ReferenceId,
                ReferenceType = n.ReferenceType,
                CreatedAt = n.CreatedAt,
                UpdatedAt = n.UpdatedAt,
                CreatedByName = n.CreatedByUser != null ? $"{n.CreatedByUser.FirstName} {n.CreatedByUser.LastName}".Trim() : null
            };
        }

        public async Task<NotificationCountDto> GetUnreadCountAsync(int userId)
        {
            var userRoles = await _context.UserRoles
                .Where(ur => ur.UserId == userId)
                .Include(ur => ur.Role)
                .Select(ur => ur.Role.Name)
                .ToListAsync();

            var query = _context.Notifications.Where(n =>
                n.DeletedAt == null &&
                (n.RecipientUserId == userId ||
                 (n.RecipientRole != null && userRoles.Contains(n.RecipientRole))));

            return new NotificationCountDto
            {
                UnreadCount = await query.CountAsync(n => n.Status == "Unread"),
                TotalCount = await query.CountAsync()
            };
        }

        public async Task<NotificationResponseDto> CreateAsync(CreateNotificationDto dto, int? createdBy = null)
        {
            var entity = new Notification
            {
                RecipientUserId = dto.RecipientUserId,
                RecipientRole = dto.RecipientRole,
                Title = dto.Title,
                Message = dto.Message,
                Type = dto.Type,
                Priority = dto.Priority,
                Status = "Unread",
                ReferenceId = dto.ReferenceId,
                ReferenceType = dto.ReferenceType,
                CreatedBy = createdBy,
                UpdatedBy = createdBy
            };

            _context.Notifications.Add(entity);
            await _context.SaveChangesAsync();
            return await GetByIdAsync(entity.Id) ?? throw new Exception("Failed to load notification.");
        }

        public async Task<bool> MarkAsReadAsync(int id)
        {
            var entity = await _context.Notifications.FindAsync(id);
            if (entity == null || entity.DeletedAt != null) return false;
            entity.Status = "Read";
            entity.ReadAt = DateTimeHelper.PhilippineNow;
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<int> MarkAllAsReadAsync(int userId)
        {
            var userRoles = await _context.UserRoles
                .Where(ur => ur.UserId == userId)
                .Include(ur => ur.Role)
                .Select(ur => ur.Role.Name)
                .ToListAsync();

            var unread = await _context.Notifications
                .Where(n => n.DeletedAt == null && n.Status == "Unread" &&
                    (n.RecipientUserId == userId ||
                     (n.RecipientRole != null && userRoles.Contains(n.RecipientRole))))
                .ToListAsync();

            var now = DateTimeHelper.PhilippineNow;
            foreach (var n in unread)
            {
                n.Status = "Read";
                n.ReadAt = now;
            }

            await _context.SaveChangesAsync();
            return unread.Count;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var entity = await _context.Notifications.FindAsync(id);
            if (entity == null || entity.DeletedAt != null) return false;
            entity.DeletedAt = DateTimeHelper.PhilippineNow;
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
