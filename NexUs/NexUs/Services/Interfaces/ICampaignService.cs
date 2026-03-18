using NexUs.Models.DTO.Common;
using NexUs.Models.DTO.Marketing;

namespace NexUs.Services.Interfaces
{
    public interface ICampaignService
    {
        Task<PagedResultDto<CampaignListDto>> GetAllAsync(PaginationDto pagination, string? statusFilter = null);
        Task<PagedResultDto<CampaignListDto>> GetArchivedAsync(PaginationDto pagination);
        Task<CampaignResponseDto?> GetByIdAsync(int id);
        Task<CampaignResponseDto> CreateAsync(CreateCampaignDto dto, int? currentUserId);
        Task<CampaignResponseDto?> UpdateAsync(int id, UpdateCampaignDto dto, int? currentUserId);
        Task<bool> DeleteAsync(int id, int? currentUserId);
        Task<bool> RestoreAsync(int id, int? currentUserId);
        Task<bool> PermanentDeleteAsync(int id);
        Task<BuildTargetsResultDto> BuildTargetsAsync(int campaignId, int? currentUserId);
        Task<bool> SendAsync(int campaignId, int? currentUserId);
        Task<bool> ScheduleAsync(int campaignId, ScheduleCampaignDto dto, int? currentUserId);
        Task<bool> CancelAsync(int campaignId, int? currentUserId);
        Task<PagedResultDto<CampaignTargetListDto>> GetTargetsAsync(int campaignId, PaginationDto pagination);
    }
}
