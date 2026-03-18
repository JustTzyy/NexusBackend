using NexUs.Models.DTO.Common;
using NexUs.Models.DTO.Marketing;

namespace NexUs.Services.Interfaces
{
    public interface IEmailMessageService
    {
        Task<PagedResultDto<EmailMessageListDto>> GetAllAsync(PaginationDto pagination, string? statusFilter = null, int? campaignId = null);
        Task<EmailMessageResponseDto?> GetByIdAsync(int id);
        Task<List<EmailEventDto>> GetEventsAsync(int emailMessageId);
    }
}
