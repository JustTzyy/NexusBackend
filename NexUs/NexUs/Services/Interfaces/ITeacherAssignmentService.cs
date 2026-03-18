using NexUs.Models.DTO.Common;
using NexUs.Models.DTO.TeacherAssignments;

namespace NexUs.Services.Interfaces
{
    public interface ITeacherAssignmentService
    {
        Task<PagedResultDto<TeacherAssignmentListDto>> GetAllTeacherAssignmentsAsync(PaginationDto pagination);
        Task<TeacherAssignmentResponseDto?> GetTeacherAssignmentByIdAsync(int id);
        Task<PagedResultDto<TeacherAssignmentListDto>> GetArchivedTeacherAssignmentsAsync(PaginationDto pagination);
        Task<TeacherAssignmentResponseDto> CreateTeacherAssignmentAsync(CreateTeacherAssignmentDto dto, int? currentUserId);
        Task<TeacherAssignmentResponseDto?> UpdateTeacherAssignmentAsync(int id, UpdateTeacherAssignmentDto dto, int? currentUserId);
        Task<bool> DeleteTeacherAssignmentAsync(int id, int? currentUserId);
        Task<bool> RestoreTeacherAssignmentAsync(int id, int? currentUserId);
        Task<bool> PermanentDeleteTeacherAssignmentAsync(int id, int? currentUserId);
    }
}
