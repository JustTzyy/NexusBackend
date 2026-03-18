using NexUs.Models.DTO.Common;
using NexUs.Models.DTO.Rooms;

namespace NexUs.Services.Interfaces
{
    public interface IRoomService
    {
        Task<PagedResultDto<RoomListDto>> GetAllRoomsAsync(PaginationDto pagination);
        Task<RoomResponseDto?> GetRoomByIdAsync(int id);
        Task<PagedResultDto<RoomListDto>> GetArchivedRoomsAsync(PaginationDto pagination);
        Task<RoomResponseDto> CreateRoomAsync(CreateRoomDto dto, int? currentUserId);
        Task<RoomResponseDto?> UpdateRoomAsync(int id, UpdateRoomDto dto, int? currentUserId);
        Task<bool> DeleteRoomAsync(int id, int? currentUserId);
        Task<bool> RestoreRoomAsync(int id, int? currentUserId);
        Task<bool> PermanentDeleteRoomAsync(int id, int? currentUserId);
    }
}
