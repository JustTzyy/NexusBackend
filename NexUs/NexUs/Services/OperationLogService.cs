using Microsoft.EntityFrameworkCore;
using NexUs.Data;
using NexUs.Models.DTO.Common;
using NexUs.Models.DTO.OperationLogs;
using NexUs.Models.Entities;
using NexUs.Services.Interfaces;
using NexUs.Utilities;

namespace NexUs.Services
{
    public class OperationLogService : IOperationLogService
    {
        private readonly ApplicationDbContext _context;

        public OperationLogService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task LogAuthActivityAsync(int? userId, string action, string status, string? ipAddress, string? device, string? location)
        {
            var log = new AuthActivityLog
            {
                UserId = userId,
                Action = action,
                Status = status,
                IpAddress = ipAddress,
                Device = device,
                Location = location,
                CreatedAt = DateTimeHelper.PhilippineNow
            };

            _context.AuthActivityLogs.Add(log);
            await _context.SaveChangesAsync();
        }

        public async Task<PagedResultDto<OperationLogListDto>> GetAllLogsAsync(OperationLogPaginationDto pagination)
        {
            var excludedRoles = new[] { "Lead", "Customer" };

            var query = _context.AuthActivityLogs
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
                    a.Action.ToLower().Contains(searchTerm) ||
                    a.Status.ToLower().Contains(searchTerm) ||
                    (a.Device != null && a.Device.ToLower().Contains(searchTerm)) ||
                    (a.IpAddress != null && a.IpAddress.Contains(searchTerm)) ||
                    (a.User != null && (a.User.FirstName + " " + a.User.LastName).ToLower().Contains(searchTerm))
                );
            }

            // Action filter
            if (!string.IsNullOrWhiteSpace(pagination.Action))
            {
                query = query.Where(a => a.Action.ToLower() == pagination.Action.ToLower());
            }

            // Status filter
            if (!string.IsNullOrWhiteSpace(pagination.Status))
            {
                query = query.Where(a => a.Status.ToLower() == pagination.Status.ToLower());
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
                .Select(a => new OperationLogListDto
                {
                    Id = a.Id,
                    User = a.User != null
                        ? (a.User.FirstName + " " + a.User.LastName).Trim()
                        : "Unknown",
                    Action = a.Action,
                    Status = a.Status,
                    IpAddress = a.IpAddress,
                    Device = a.Device,
                    CreatedAt = a.CreatedAt
                })
                .ToListAsync();

            return new PagedResultDto<OperationLogListDto>
            {
                Items = items,
                TotalCount = totalCount,
                PageNumber = pagination.PageNumber,
                PageSize = pagination.PageSize
            };
        }

        public async Task<OperationLogDetailDto?> GetLogByIdAsync(int id)
        {
            var log = await _context.AuthActivityLogs
                .Include(a => a.User)
                .FirstOrDefaultAsync(a => a.Id == id);

            if (log == null) return null;

            return new OperationLogDetailDto
            {
                Id = log.Id,
                User = log.User != null
                    ? (log.User.FirstName + " " + log.User.LastName).Trim()
                    : "Unknown",
                Action = log.Action,
                Status = log.Status,
                IpAddress = log.IpAddress,
                Device = log.Device,
                Location = log.Location,
                CreatedAt = log.CreatedAt,
                UserId = log.UserId
            };
        }

        public async Task<PagedResultDto<OperationLogListDto>> GetUserLogsAsync(int userId, OperationLogPaginationDto pagination)
        {
            var query = _context.AuthActivityLogs
                .Include(a => a.User)
                .Where(a => a.UserId == userId)
                .AsQueryable();

            if (!string.IsNullOrWhiteSpace(pagination.SearchTerm))
            {
                var searchTerm = pagination.SearchTerm.ToLower();
                query = query.Where(a =>
                    a.Action.ToLower().Contains(searchTerm) ||
                    a.Status.ToLower().Contains(searchTerm) ||
                    (a.Device != null && a.Device.ToLower().Contains(searchTerm)) ||
                    (a.IpAddress != null && a.IpAddress.Contains(searchTerm))
                );
            }

            if (!string.IsNullOrWhiteSpace(pagination.Action))
            {
                query = query.Where(a => a.Action.ToLower() == pagination.Action.ToLower());
            }

            if (!string.IsNullOrWhiteSpace(pagination.Status))
            {
                query = query.Where(a => a.Status.ToLower() == pagination.Status.ToLower());
            }

            if (pagination.FromDate.HasValue)
            {
                query = query.Where(a => a.CreatedAt >= pagination.FromDate.Value);
            }
            if (pagination.ToDate.HasValue)
            {
                var toDateEnd = pagination.ToDate.Value.Date.AddDays(1);
                query = query.Where(a => a.CreatedAt < toDateEnd);
            }

            query = query.OrderByDescending(a => a.CreatedAt);

            var totalCount = await query.CountAsync();

            var items = await query
                .Skip((pagination.PageNumber - 1) * pagination.PageSize)
                .Take(pagination.PageSize)
                .Select(a => new OperationLogListDto
                {
                    Id = a.Id,
                    User = a.User != null
                        ? (a.User.FirstName + " " + a.User.LastName).Trim()
                        : "Unknown",
                    Action = a.Action,
                    Status = a.Status,
                    IpAddress = a.IpAddress,
                    Device = a.Device,
                    CreatedAt = a.CreatedAt
                })
                .ToListAsync();

            return new PagedResultDto<OperationLogListDto>
            {
                Items = items,
                TotalCount = totalCount,
                PageNumber = pagination.PageNumber,
                PageSize = pagination.PageSize
            };
        }

        public async Task<OperationLogDetailDto?> GetUserLogByIdAsync(int userId, int id)
        {
            var log = await _context.AuthActivityLogs
                .Include(a => a.User)
                .FirstOrDefaultAsync(a => a.Id == id && a.UserId == userId);

            if (log == null) return null;

            return new OperationLogDetailDto
            {
                Id = log.Id,
                User = log.User != null
                    ? (log.User.FirstName + " " + log.User.LastName).Trim()
                    : "Unknown",
                Action = log.Action,
                Status = log.Status,
                IpAddress = log.IpAddress,
                Device = log.Device,
                Location = log.Location,
                CreatedAt = log.CreatedAt,
                UserId = log.UserId
            };
        }
    }
}
