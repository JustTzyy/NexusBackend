using NexUs.Models.DTO.Common;
using NexUs.Models.DTO.Marketing;

namespace NexUs.Services.Interfaces
{
    public interface ISuppressionService
    {
        Task<PagedResultDto<SuppressionListDto>> GetAllAsync(PaginationDto pagination);
        Task<SuppressionListDto?> GetByIdAsync(int id);
        Task<bool> IsSuppressedAsync(string email);
        Task EnsureSuppressedAsync(string email, string reason, string source, string? notes = null, int? currentUserId = null);
        Task<SuppressionListDto> CreateAsync(CreateSuppressionDto dto, int? currentUserId);
        Task<bool> DeleteAsync(int id);
    }
}
