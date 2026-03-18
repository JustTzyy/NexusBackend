using NexUs.Models.DTO.Buildings;
using NexUs.Models.DTO.Common;

namespace NexUs.Services.Interfaces
{
    public interface IBuildingService
    {
        Task<PagedResultDto<BuildingListDto>> GetAllBuildingsAsync(PaginationDto pagination);
        Task<BuildingListDto?> GetMyBuildingAsync(int userId);
        Task<BuildingListDto?> GetRecommendedBuildingAsync(string cityCode, string provinceCode, string regionCode, int? preferredBuildingId = null);
        Task<BuildingResponseDto?> GetBuildingByIdAsync(int id);
        Task<PagedResultDto<BuildingListDto>> GetArchivedBuildingsAsync(PaginationDto pagination);
        Task<List<AvailableManagerDto>> GetAvailableManagersAsync(int? excludeBuildingId);
        Task<BuildingResponseDto> CreateBuildingAsync(CreateBuildingDto dto, int? currentUserId);
        Task<BuildingResponseDto?> UpdateBuildingAsync(int id, UpdateBuildingDto dto, int? currentUserId);
        Task<bool> DeleteBuildingAsync(int id, int? currentUserId);
        Task<bool> RestoreBuildingAsync(int id, int? currentUserId);
        Task<bool> PermanentDeleteBuildingAsync(int id, int? currentUserId);
    }
}
