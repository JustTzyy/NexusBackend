using Microsoft.EntityFrameworkCore;
using NexUs.Data;
using NexUs.Models.DTO.ActivityLogs;
using NexUs.Models.DTO.AuditLogs;
using NexUs.Models.DTO.Common;
using NexUs.Models.Entities;
using NexUs.Services.Interfaces;
using NexUs.Utilities;

namespace NexUs.Services
{
    public class AuditService : IAuditService
    {
        private readonly ApplicationDbContext _context;

        public AuditService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task LogAsync(string module, string action, string? details, int? userId)
        {
            var auditLog = new AuditLog
            {
                Module = module,
                Action = action,
                Details = details,
                UserId = userId,
                CreatedAt = DateTimeHelper.PhilippineNow
            };

            _context.AuditLogs.Add(auditLog);
            await _context.SaveChangesAsync();
        }

        public async Task<PagedResultDto<AuditLogListDto>> GetAllLogsAsync(AuditLogPaginationDto pagination)
        {
            var excludedRoles = new[] { "Lead", "Customer" };

            var query = _context.AuditLogs
                .Include(a => a.User)
                    .ThenInclude(u => u!.UserRoles)
                        .ThenInclude(ur => ur.Role)
                .Where(a => a.User == null || !a.User.UserRoles.Any(ur => excludedRoles.Contains(ur.Role.Name)))
                .AsQueryable();

            // Search filter
            if (!string.IsNullOrWhiteSpace(pagination.SearchTerm))
            {
                var searchTerm = pagination.SearchTerm.ToLower();
                query = query.Where(a =>
                    a.Module.ToLower().Contains(searchTerm) ||
                    a.Action.ToLower().Contains(searchTerm) ||
                    (a.Details != null && a.Details.ToLower().Contains(searchTerm)) ||
                    (a.User != null && (a.User.FirstName + " " + a.User.LastName).ToLower().Contains(searchTerm))
                );
            }

            // Module filter
            if (!string.IsNullOrWhiteSpace(pagination.Module))
            {
                query = query.Where(a => a.Module.ToLower() == pagination.Module.ToLower());
            }

            // Date range filter
            if (pagination.FromDate.HasValue)
            {
                query = query.Where(a => a.CreatedAt >= pagination.FromDate.Value);
            }
            if (pagination.ToDate.HasValue)
            {
                var toDateEnd = pagination.ToDate.Value.Date.AddDays(1);
                query = query.Where(a => a.CreatedAt < toDateEnd);
            }

            // Sort by CreatedAt descending (newest first)
            query = query.OrderByDescending(a => a.CreatedAt);

            var totalCount = await query.CountAsync();

            var items = await query
                .Skip((pagination.PageNumber - 1) * pagination.PageSize)
                .Take(pagination.PageSize)
                .Select(a => new AuditLogListDto
                {
                    Id = a.Id,
                    User = a.User != null
                        ? (a.User.FirstName + " " + a.User.LastName).Trim()
                        : "System",
                    Module = a.Module,
                    Action = a.Action,
                    Details = a.Details ?? "",
                    CreatedAt = a.CreatedAt
                })
                .ToListAsync();

            return new PagedResultDto<AuditLogListDto>
            {
                Items = items,
                TotalCount = totalCount,
                PageNumber = pagination.PageNumber,
                PageSize = pagination.PageSize
            };
        }

        public async Task<AuditLogDetailDto?> GetLogByIdAsync(int id)
        {
            var log = await _context.AuditLogs
                .Include(a => a.User)
                .FirstOrDefaultAsync(a => a.Id == id);

            if (log == null) return null;

            return new AuditLogDetailDto
            {
                Id = log.Id,
                User = log.User != null
                    ? (log.User.FirstName + " " + log.User.LastName).Trim()
                    : "System",
                Module = log.Module,
                Action = log.Action,
                Details = log.Details ?? "",
                CreatedAt = log.CreatedAt,
                UserId = log.UserId
            };
        }

        public async Task<PagedResultDto<ActivityLogListDto>> GetUserLogsAsync(int userId, ActivityLogPaginationDto pagination)
        {
            var query = _context.AuditLogs
                .Where(a => a.UserId == userId)
                .AsQueryable();

            // Search filter
            if (!string.IsNullOrWhiteSpace(pagination.SearchTerm))
            {
                var searchTerm = pagination.SearchTerm.ToLower();
                query = query.Where(a =>
                    a.Module.ToLower().Contains(searchTerm) ||
                    a.Action.ToLower().Contains(searchTerm) ||
                    (a.Details != null && a.Details.ToLower().Contains(searchTerm))
                );
            }

            // Module filter
            if (!string.IsNullOrWhiteSpace(pagination.Module))
            {
                query = query.Where(a => a.Module.ToLower() == pagination.Module.ToLower());
            }

            // Date range filter
            if (pagination.FromDate.HasValue)
            {
                query = query.Where(a => a.CreatedAt >= pagination.FromDate.Value);
            }
            if (pagination.ToDate.HasValue)
            {
                var toDateEnd = pagination.ToDate.Value.Date.AddDays(1);
                query = query.Where(a => a.CreatedAt < toDateEnd);
            }

            // Sort by CreatedAt descending (newest first)
            query = query.OrderByDescending(a => a.CreatedAt);

            var totalCount = await query.CountAsync();

            var items = await query
                .Skip((pagination.PageNumber - 1) * pagination.PageSize)
                .Take(pagination.PageSize)
                .Select(a => new ActivityLogListDto
                {
                    Id = a.Id,
                    Module = a.Module,
                    Action = a.Action,
                    Details = a.Details ?? "",
                    CreatedAt = a.CreatedAt
                })
                .ToListAsync();

            return new PagedResultDto<ActivityLogListDto>
            {
                Items = items,
                TotalCount = totalCount,
                PageNumber = pagination.PageNumber,
                PageSize = pagination.PageSize
            };
        }

        public async Task<ActivityLogDetailDto?> GetUserLogByIdAsync(int userId, int logId)
        {
            var log = await _context.AuditLogs
                .FirstOrDefaultAsync(a => a.Id == logId && a.UserId == userId);

            if (log == null) return null;

            return new ActivityLogDetailDto
            {
                Id = log.Id,
                Module = log.Module,
                Action = log.Action,
                Details = log.Details ?? "",
                CreatedAt = log.CreatedAt
            };
        }

        public async Task<PagedResultDto<ActivityLogListDto>> GetUserAuthLogsAsync(int userId, ActivityLogPaginationDto pagination)
        {
            var authActions = new[] { "Login", "Logout" };

            var query = _context.AuditLogs
                .Where(a => a.UserId == userId && authActions.Contains(a.Action))
                .AsQueryable();

            // Search filter
            if (!string.IsNullOrWhiteSpace(pagination.SearchTerm))
            {
                var searchTerm = pagination.SearchTerm.ToLower();
                query = query.Where(a =>
                    a.Action.ToLower().Contains(searchTerm) ||
                    (a.Details != null && a.Details.ToLower().Contains(searchTerm))
                );
            }

            // Date range filter
            if (pagination.FromDate.HasValue)
            {
                query = query.Where(a => a.CreatedAt >= pagination.FromDate.Value);
            }
            if (pagination.ToDate.HasValue)
            {
                var toDateEnd = pagination.ToDate.Value.Date.AddDays(1);
                query = query.Where(a => a.CreatedAt < toDateEnd);
            }

            // Sort by CreatedAt descending (newest first)
            query = query.OrderByDescending(a => a.CreatedAt);

            var totalCount = await query.CountAsync();

            var items = await query
                .Skip((pagination.PageNumber - 1) * pagination.PageSize)
                .Take(pagination.PageSize)
                .Select(a => new ActivityLogListDto
                {
                    Id = a.Id,
                    Module = a.Module,
                    Action = a.Action,
                    Details = a.Details ?? "",
                    CreatedAt = a.CreatedAt
                })
                .ToListAsync();

            return new PagedResultDto<ActivityLogListDto>
            {
                Items = items,
                TotalCount = totalCount,
                PageNumber = pagination.PageNumber,
                PageSize = pagination.PageSize
            };
        }

        public async Task<ActivityLogDetailDto?> GetUserAuthLogByIdAsync(int userId, int logId)
        {
            var authActions = new[] { "Login", "Logout" };

            var log = await _context.AuditLogs
                .FirstOrDefaultAsync(a => a.Id == logId && a.UserId == userId && authActions.Contains(a.Action));

            if (log == null) return null;

            return new ActivityLogDetailDto
            {
                Id = log.Id,
                Module = log.Module,
                Action = log.Action,
                Details = log.Details ?? "",
                CreatedAt = log.CreatedAt
            };
        }
    }
}
