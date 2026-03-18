using NexUs.Models.DTO.Common;
using NexUs.Models.DTO.Roles;
using NexUs.Models.DTO.Users;

namespace NexUs.Services.Interfaces
{
    public interface IUserService
    {
        Task<PagedResultDto<UserListDto>> GetAllUsersAsync(PaginationDto pagination);
        Task<UserResponseDto?> GetUserByIdAsync(int id);
        Task<List<RoleListDto>> GetUserRolesAsync(int userId);
        Task<PagedResultDto<UserListDto>> GetArchivedUsersAsync(PaginationDto pagination);
        Task<UserResponseDto> CreateUserAsync(CreateUserDto dto, int? currentUserId);
        Task<UserResponseDto?> UpdateUserAsync(int id, UpdateUserDto dto, int? currentUserId);
        Task<bool> DeleteUserAsync(int id, int? currentUserId);
        Task<bool> RestoreUserAsync(int id, int? currentUserId);
        Task<bool> PermanentDeleteUserAsync(int id, int? currentUserId);
        Task<bool> AssignRolesToUserAsync(int userId, List<int> roleIds, int? currentUserId);
        Task<int> CountUsersCreatedBetweenAsync(DateTime startDate, DateTime endDate);
        Task<List<UserListDto>> GetUsersByRoleAsync(string roleName);
        Task<PagedResultDto<ClientLogListDto>> GetClientSummariesAsync(PaginationDto pagination);
        Task<ClientDetailDto?> GetClientDetailAsync(int userId);
    }
}
