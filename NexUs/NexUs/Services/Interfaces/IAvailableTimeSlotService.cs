using NexUs.Models.DTO.Common;
using NexUs.Models.DTO.AvailableTimeSlots;

namespace NexUs.Services.Interfaces
{
    public interface IAvailableTimeSlotService
    {
        Task<PagedResultDto<AvailableTimeSlotListDto>> GetAllAvailableTimeSlotsAsync(PaginationDto pagination);
        Task<AvailableTimeSlotResponseDto?> GetAvailableTimeSlotByIdAsync(int id);
        Task<PagedResultDto<AvailableTimeSlotListDto>> GetArchivedAvailableTimeSlotsAsync(PaginationDto pagination);
        Task<AvailableTimeSlotResponseDto> CreateAvailableTimeSlotAsync(CreateAvailableTimeSlotDto dto, int? currentUserId);
        Task<AvailableTimeSlotResponseDto?> UpdateAvailableTimeSlotAsync(int id, UpdateAvailableTimeSlotDto dto, int? currentUserId);
        Task<bool> DeleteAvailableTimeSlotAsync(int id, int? currentUserId);
        Task<bool> RestoreAvailableTimeSlotAsync(int id, int? currentUserId);
        Task<bool> PermanentDeleteAvailableTimeSlotAsync(int id, int? currentUserId);
    }
}
