using NexUs.Models.DTO.Common;
using NexUs.Models.DTO.OperationLogs;

namespace NexUs.Services.Interfaces
{
    public interface IOperationLogService
    {
        Task LogAuthActivityAsync(int? userId, string action, string status, string? ipAddress, string? device, string? location);
        Task<PagedResultDto<OperationLogListDto>> GetAllLogsAsync(OperationLogPaginationDto pagination);
        Task<OperationLogDetailDto?> GetLogByIdAsync(int id);
        Task<PagedResultDto<OperationLogListDto>> GetUserLogsAsync(int userId, OperationLogPaginationDto pagination);
        Task<OperationLogDetailDto?> GetUserLogByIdAsync(int userId, int id);
    }
}
