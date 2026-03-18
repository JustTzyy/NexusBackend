using NexUs.Models.DTO.Common;
using NexUs.Models.DTO.Marketing;

namespace NexUs.Services.Interfaces
{
    public interface ILeadService
    {
        Task<PagedResultDto<LeadListDto>> GetAllAsync(PaginationDto pagination, string? statusFilter = null);
        Task<PagedResultDto<LeadListDto>> GetArchivedAsync(PaginationDto pagination);
        Task<LeadResponseDto?> GetByIdAsync(int id);
        Task<LeadResponseDto> CreateAsync(CreateLeadDto dto, int? currentUserId);
        Task<LeadResponseDto?> UpdateAsync(int id, UpdateLeadDto dto, int? currentUserId);
        Task<bool> DeleteAsync(int id, int? currentUserId);
        Task<bool> RestoreAsync(int id, int? currentUserId);
        Task<bool> PermanentDeleteAsync(int id);
        Task<LeadResponseDto?> CreateFromUserAsync(int userId, string email, string firstName, string lastName, string source = "Registration");
        Task<bool> MarkConvertedAsync(int userId);
    }
}
