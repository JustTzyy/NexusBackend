using NexUs.Models.DTO.Common;
using NexUs.Models.DTO.Marketing;

namespace NexUs.Services.Interfaces
{
    public interface ICustomerService
    {
        Task<PagedResultDto<CustomerListDto>> GetAllAsync(PaginationDto pagination);
        Task<CustomerResponseDto?> GetByIdAsync(int id);
        Task<CustomerResponseDto?> CreateFromConversionAsync(int userId, int? leadId, int? tutoringRequestId, int? currentUserId = null);
    }
}
