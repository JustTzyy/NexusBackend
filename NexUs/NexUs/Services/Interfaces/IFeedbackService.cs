using NexUs.Models.DTO.Common;
using NexUs.Models.DTO.Feedbacks;

namespace NexUs.Services.Interfaces
{
    public interface IFeedbackService
    {
        Task<PagedResultDto<FeedbackListDto>> GetAllAsync(PaginationDto pagination);
        Task<PagedResultDto<FeedbackListDto>> GetByCustomerAsync(int customerId, PaginationDto pagination);
        Task<FeedbackResponseDto?> GetByIdAsync(int id);
        Task<FeedbackResponseDto> CreateAsync(CreateFeedbackDto dto, int customerId);
        Task<FeedbackResponseDto?> UpdateAsync(int id, UpdateFeedbackDto dto, int userId);
        Task<bool> DeleteAsync(int id, int userId);
        Task<bool> CanSubmitFeedbackAsync(int customerId, int sessionLogId);
    }
}
