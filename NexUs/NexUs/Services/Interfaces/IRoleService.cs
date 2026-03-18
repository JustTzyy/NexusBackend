using NexUs.Models.DTO.Common;
using NexUs.Models.DTO.Permissions;
using NexUs.Models.DTO.Roles;

namespace NexUs.Services.Interfaces
{
    public interface IRoleService
    {
        Task<PagedResultDto<RoleListDto>> GetAllRolesAsync(PaginationDto pagination);
        Task<RoleResponseDto?> GetRoleByIdAsync(int id);
        Task<List<PermissionListDto>> GetRolePermissionsAsync(int roleId);
        Task<PagedResultDto<RoleListDto>> GetArchivedRolesAsync(PaginationDto pagination);
        Task<RoleResponseDto> CreateRoleAsync(CreateRoleDto dto, int? currentUserId);
        Task<RoleResponseDto?> UpdateRoleAsync(int id, UpdateRoleDto dto, int? currentUserId);
        Task<bool> DeleteRoleAsync(int id, int? currentUserId);
        Task<bool> RestoreRoleAsync(int id, int? currentUserId);
        Task<bool> PermanentDeleteRoleAsync(int id, int? currentUserId);
        Task<bool> AssignPermissionsToRoleAsync(int roleId, AssignPermissionsDto dto, int? currentUserId);
    }
}
