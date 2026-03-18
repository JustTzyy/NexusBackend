using NexUs.Models.DTO.Common;
using NexUs.Models.DTO.SessionLogs;

namespace NexUs.Services.Interfaces
{
    public interface ISessionLogService
    {
        Task<List<SessionLogResponseDto>> GetByTutoringRequestAsync(int tutoringRequestId);
        Task<SessionLogResponseDto?> GetByIdAsync(int id);
        Task<PagedResultDto<SessionLogResponseDto>> GetAllAsync(PaginationDto pagination);
        Task<SessionLogResponseDto> CreateAsync(CreateSessionLogDto dto, int? userId);
        Task<SessionLogResponseDto?> UpdateAsync(int id, UpdateSessionLogDto dto, int? userId);
        Task<bool> DeleteAsync(int id, int? userId);
    }
}
