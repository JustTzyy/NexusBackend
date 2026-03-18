using NexUs.Models.DTO.Common;
using NexUs.Models.DTO.Subjects;

namespace NexUs.Services.Interfaces
{
    public interface ISubjectService
    {
        Task<PagedResultDto<SubjectListDto>> GetAllSubjectsAsync(PaginationDto pagination);
        Task<SubjectResponseDto?> GetSubjectByIdAsync(int id);
        Task<PagedResultDto<SubjectListDto>> GetArchivedSubjectsAsync(PaginationDto pagination);
        Task<SubjectResponseDto> CreateSubjectAsync(CreateSubjectDto dto, int? currentUserId);
        Task<SubjectResponseDto?> UpdateSubjectAsync(int id, UpdateSubjectDto dto, int? currentUserId);
        Task<bool> DeleteSubjectAsync(int id, int? currentUserId);
        Task<bool> RestoreSubjectAsync(int id, int? currentUserId);
        Task<bool> PermanentDeleteSubjectAsync(int id, int? currentUserId);
    }
}
