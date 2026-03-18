using NexUs.Models.DTO.Common;
using NexUs.Models.DTO.Marketing;

namespace NexUs.Services.Interfaces
{
    public interface ISegmentService
    {
        Task<PagedResultDto<SegmentListDto>> GetAllAsync(PaginationDto pagination);
        Task<PagedResultDto<SegmentListDto>> GetArchivedAsync(PaginationDto pagination);
        Task<SegmentResponseDto?> GetByIdAsync(int id);
        Task<SegmentResponseDto> CreateAsync(CreateSegmentDto dto, int? currentUserId);
        Task<SegmentResponseDto?> UpdateAsync(int id, UpdateSegmentDto dto, int? currentUserId);
        Task<bool> DeleteAsync(int id, int? currentUserId);
        Task<bool> RestoreAsync(int id, int? currentUserId);
        Task<bool> PermanentDeleteAsync(int id);
        Task<SegmentPreviewDto> PreviewAsync(int segmentId);
        Task<List<(int? UserId, string Email, string FirstName, string LastName)>> EvaluateAsync(int segmentId);
        Task<List<string>> GetFieldValuesAsync(string field);
    }
}
