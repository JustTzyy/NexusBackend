using NexUs.Models.DTO.Common;
using NexUs.Models.DTO.StudentAssignments;

namespace NexUs.Services.Interfaces
{
    public interface IStudentAssignmentService
    {
        Task<PagedResultDto<StudentAssignmentListDto>> GetAllAsync(PaginationDto pagination);
        Task<PagedResultDto<StudentAssignmentListDto>> GetArchivedAsync(PaginationDto pagination);
        Task<StudentAssignmentResponseDto?> GetByIdAsync(int id);
        Task<StudentAssignmentResponseDto?> GetByStudentIdAsync(int studentId);
        Task<StudentAssignmentResponseDto> UpsertByStudentIdAsync(int studentId, UpdateStudentAssignmentDto dto, int? currentUserId);
        Task<StudentAssignmentResponseDto?> UpdateAsync(int id, UpdateStudentAssignmentDto dto, int? currentUserId);
        Task<bool> DeleteAsync(int id, int? currentUserId);
        Task<bool> RestoreAsync(int id, int? currentUserId);
        Task<bool> PermanentDeleteAsync(int id, int? currentUserId);
    }
}
