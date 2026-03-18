using NexUs.Models.DTO.Common;
using NexUs.Models.DTO.AvailableDays;

namespace NexUs.Services.Interfaces
{
    public interface IAvailableDayService
    {
        Task<PagedResultDto<AvailableDayListDto>> GetAllAvailableDaysAsync(PaginationDto pagination);
        Task<AvailableDayResponseDto?> GetAvailableDayByIdAsync(int id);
        Task<PagedResultDto<AvailableDayListDto>> GetArchivedAvailableDaysAsync(PaginationDto pagination);
        Task<AvailableDayResponseDto> CreateAvailableDayAsync(CreateAvailableDayDto dto, int? currentUserId);
        Task<AvailableDayResponseDto?> UpdateAvailableDayAsync(int id, UpdateAvailableDayDto dto, int? currentUserId);
        Task<bool> DeleteAvailableDayAsync(int id, int? currentUserId);
        Task<bool> RestoreAvailableDayAsync(int id, int? currentUserId);
        Task<bool> PermanentDeleteAvailableDayAsync(int id, int? currentUserId);
    }
}
