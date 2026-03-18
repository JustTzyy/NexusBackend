using NexUs.Models.DTO.Common;
using NexUs.Models.DTO.Notifications;

namespace NexUs.Services.Interfaces
{
    public interface INotificationService
    {
        Task<PagedResultDto<NotificationListDto>> GetAllAsync(PaginationDto pagination, int? userId = null, string? type = null);
        Task<NotificationResponseDto?> GetByIdAsync(int id);
        Task<NotificationCountDto> GetUnreadCountAsync(int userId);
        Task<NotificationResponseDto> CreateAsync(CreateNotificationDto dto, int? createdBy = null);
        Task<bool> MarkAsReadAsync(int id);
        Task<int> MarkAllAsReadAsync(int userId);
        Task<bool> DeleteAsync(int id);
    }
}
