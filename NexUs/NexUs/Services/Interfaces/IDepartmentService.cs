using NexUs.Models.DTO.Common;
using NexUs.Models.DTO.Departments;

namespace NexUs.Services.Interfaces
{
    public interface IDepartmentService
    {
        Task<PagedResultDto<DepartmentListDto>> GetAllDepartmentsAsync(PaginationDto pagination);
        Task<DepartmentResponseDto?> GetDepartmentByIdAsync(int id);
        Task<PagedResultDto<DepartmentListDto>> GetArchivedDepartmentsAsync(PaginationDto pagination);
        Task<DepartmentResponseDto> CreateDepartmentAsync(CreateDepartmentDto dto, int? currentUserId);
        Task<DepartmentResponseDto?> UpdateDepartmentAsync(int id, UpdateDepartmentDto dto, int? currentUserId);
        Task<bool> DeleteDepartmentAsync(int id, int? currentUserId);
        Task<bool> RestoreDepartmentAsync(int id, int? currentUserId);
        Task<bool> PermanentDeleteDepartmentAsync(int id, int? currentUserId);
    }
}
