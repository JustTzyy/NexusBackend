using NexUs.Models.DTO.ActivityLogs;
using NexUs.Models.DTO.AuditLogs;
using NexUs.Models.DTO.Common;

namespace NexUs.Services.Interfaces
{
    public interface IAuditService
    {
        /// <summary>
        /// Logs an audit entry
        /// </summary>
        Task LogAsync(string module, string action, string? details, int? userId);

        /// <summary>
        /// Get all audit logs with pagination, search, and filters
        /// </summary>
        Task<PagedResultDto<AuditLogListDto>> GetAllLogsAsync(AuditLogPaginationDto pagination);

        /// <summary>
        /// Get a single audit log by ID
        /// </summary>
        Task<AuditLogDetailDto?> GetLogByIdAsync(int id);

        /// <summary>
        /// Get activity logs for a specific user with pagination and filters
        /// </summary>
        Task<PagedResultDto<ActivityLogListDto>> GetUserLogsAsync(int userId, ActivityLogPaginationDto pagination);

        /// <summary>
        /// Get a single activity log by ID for a specific user
        /// </summary>
        Task<ActivityLogDetailDto?> GetUserLogByIdAsync(int userId, int logId);

        /// <summary>
        /// Get authentication logs (login/logout) for a specific user with pagination and filters
        /// </summary>
        Task<PagedResultDto<ActivityLogListDto>> GetUserAuthLogsAsync(int userId, ActivityLogPaginationDto pagination);

        /// <summary>
        /// Get a single authentication log by ID for a specific user
        /// </summary>
        Task<ActivityLogDetailDto?> GetUserAuthLogByIdAsync(int userId, int logId);
    }
}
