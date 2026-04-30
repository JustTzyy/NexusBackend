using NexUs.Models.DTO.Common;
using NexUs.Models.DTO.Feedbacks;

namespace NexUs.Services.Interfaces
{
    public interface IFeedbackService
    {
        Task<PagedResultDto<FeedbackListDto>> GetAllAsync(PaginationDto pagination);
        Task<PagedResultDto<FeedbackListDto>> GetByCustomerAsync(int customerId, PaginationDto pagination);
        Task<FeedbackResponseDto?> GetByIdAsync(int id, int? requesterId = null, bool isAdmin = false);
        Task<FeedbackResponseDto> CreateAsync(CreateFeedbackDto dto, int customerId);
        Task<FeedbackResponseDto?> UpdateAsync(int id, UpdateFeedbackDto dto, int userId, bool isAdmin = false);
        Task<bool> DeleteAsync(int id, int userId, bool isAdmin = false);
        Task<bool> CanSubmitFeedbackAsync(int customerId, int sessionLogId);
    }
}
