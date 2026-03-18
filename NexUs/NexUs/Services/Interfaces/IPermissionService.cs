using NexUs.Models.DTO.Common;
using NexUs.Models.DTO.Permissions;

namespace NexUs.Services.Interfaces
{
    public interface IPermissionService
    {
        Task<PagedResultDto<PermissionListDto>> GetAllPermissionsAsync(PaginationDto pagination);
        Task<PermissionResponseDto?> GetPermissionByIdAsync(int id);
        Task<List<PermissionListDto>> GetPermissionsByModuleAsync(string module);
        Task<PagedResultDto<PermissionListDto>> GetArchivedPermissionsAsync(PaginationDto pagination);
        Task<PermissionResponseDto> CreatePermissionAsync(CreatePermissionDto dto, int? currentUserId);
        Task<PermissionResponseDto?> UpdatePermissionAsync(int id, UpdatePermissionDto dto, int? currentUserId);
        Task<bool> DeletePermissionAsync(int id, int? currentUserId);
        Task<bool> RestorePermissionAsync(int id, int? currentUserId);
        Task<bool> PermanentDeletePermissionAsync(int id, int? currentUserId);
        Task<List<string>> GetUserPermissionsAsync(int userId);
    }
}
