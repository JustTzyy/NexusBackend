using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using NexUs.Attributes;
using NexUs.Extensions;
using NexUs.Models.DTO.Common;
using NexUs.Models.DTO.Roles;
using NexUs.Models.DTO.Users;
using NexUs.Services.Interfaces;

namespace NexUs.Controllers
{
    [Route("api/user")]
    [ApiController]
    [Authorize]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;
        private readonly IRoleService _roleService;
        private readonly IAutomationService _automationService;

        public UserController(IUserService userService, IRoleService roleService, IAutomationService automationService)
        {
            _userService = userService;
            _roleService = roleService;
            _automationService = automationService;
        }

        private async Task<bool> ActorCanAssignRolesAsync(List<int>? roleIds)
        {
            if (roleIds == null || !roleIds.Any()) return true;
            bool isSuperAdmin = User.IsInRole("Super Admin");
            bool isAdmin = User.IsInRole("Admin");
            if (!isAdmin || isSuperAdmin) return true;

            // Admin (not Super Admin) — block assigning Super Admin or Admin roles
            var allRoles = await _roleService.GetAllRolesAsync(new PaginationDto { PageNumber = 1, PageSize = 100 });
            var restrictedIds = allRoles.Items
                .Where(r => r.Name == "Super Admin" || r.Name == "Admin")
                .Select(r => r.Id)
                .ToHashSet();
            return !roleIds.Any(id => restrictedIds.Contains(id));
        }

        /// <summary>
        /// Get current user's own profile (no permission required)
        /// </summary>
        [HttpGet("me")]
        public async Task<ActionResult<ApiResponse<UserResponseDto>>> GetCurrentUser()
        {
            try
            {
                var userId = HttpContext.GetCurrentUserId();
                if (userId == null)
                    return Unauthorized(ApiResponse<UserResponseDto>.ErrorResponse("Unauthorized"));

                var user = await _userService.GetUserByIdAsync(userId.Value);
                if (user == null)
                    return NotFound(ApiResponse<UserResponseDto>.ErrorResponse("User not found"));

                return Ok(ApiResponse<UserResponseDto>.SuccessResponse(user, "User retrieved successfully"));
            }
            catch (Exception ex)
            {
                return StatusCode(500, ApiResponse<UserResponseDto>.ErrorResponse("An error occurred while retrieving user", new List<string> { ex.Message }));
            }
        }

        /// <summary>
        /// Update current user's own profile (no permission required)
        /// </summary>
        [HttpPut("me")]
        public async Task<ActionResult<ApiResponse<UserResponseDto>>> UpdateCurrentUser([FromBody] UpdateUserDto dto)
        {
            try
            {
                var userId = HttpContext.GetCurrentUserId();
                if (userId == null)
                    return Unauthorized(ApiResponse<UserResponseDto>.ErrorResponse("Unauthorized"));

                // Prevent self-role-escalation
                dto.RoleIds = null;

                var user = await _userService.UpdateUserAsync(userId.Value, dto, userId);
                if (user == null)
                    return NotFound(ApiResponse<UserResponseDto>.ErrorResponse("User not found"));

                return Ok(ApiResponse<UserResponseDto>.SuccessResponse(user, "User updated successfully"));
            }
            catch (InvalidOperationException ex)
            {
                return BadRequest(ApiResponse<UserResponseDto>.ErrorResponse(ex.Message));
            }
            catch (Exception ex)
            {
                return StatusCode(500, ApiResponse<UserResponseDto>.ErrorResponse("An error occurred while updating user", new List<string> { ex.Message }));
            }
        }

        /// <summary>
        /// Get all active users with pagination and search
        /// </summary>
        [RequirePermission("ViewUsers")]
        [HttpGet]
        public async Task<ActionResult<ApiResponse<PagedResultDto<UserListDto>>>> GetAllUsers([FromQuery] PaginationDto pagination)
        {
            try
            {
                var result = await _userService.GetAllUsersAsync(pagination);
                return Ok(ApiResponse<PagedResultDto<UserListDto>>.SuccessResponse(result, "Users retrieved successfully"));
            }
            catch (Exception ex)
            {
                return StatusCode(500, ApiResponse<PagedResultDto<UserListDto>>.ErrorResponse("An error occurred while retrieving users", new List<string> { ex.Message }));
            }
        }

        /// <summary>
        /// Get user by ID with address and roles
        /// </summary>
        [RequirePermission("ViewUsers")]
        [HttpGet("{id}")]
        public async Task<ActionResult<ApiResponse<UserResponseDto>>> GetUserById(int id)
        {
            try
            {
                var user = await _userService.GetUserByIdAsync(id);
                if (user == null)
                {
                    return NotFound(ApiResponse<UserResponseDto>.ErrorResponse("User not found"));
                }

                return Ok(ApiResponse<UserResponseDto>.SuccessResponse(user, "User retrieved successfully"));
            }
            catch (Exception ex)
            {
                return StatusCode(500, ApiResponse<UserResponseDto>.ErrorResponse("An error occurred while retrieving user", new List<string> { ex.Message }));
            }
        }

        /// <summary>
        /// Get user's roles
        /// </summary>
        [RequirePermission("ViewUsers")]
        [HttpGet("{id}/roles")]
        public async Task<ActionResult<ApiResponse<List<RoleListDto>>>> GetUserRoles(int id)
        {
            try
            {
                var roles = await _userService.GetUserRolesAsync(id);
                return Ok(ApiResponse<List<RoleListDto>>.SuccessResponse(roles, "User roles retrieved successfully"));
            }
            catch (Exception ex)
            {
                return StatusCode(500, ApiResponse<List<RoleListDto>>.ErrorResponse("An error occurred while retrieving user roles", new List<string> { ex.Message }));
            }
        }

        /// <summary>
        /// Get users by role name
        /// </summary>
        [RequirePermission("ViewUsers")]
        [HttpGet("by-role/{roleName}")]
        public async Task<ActionResult<ApiResponse<List<UserListDto>>>> GetUsersByRole(string roleName)
        {
            try
            {
                var users = await _userService.GetUsersByRoleAsync(roleName);
                return Ok(ApiResponse<List<UserListDto>>.SuccessResponse(users, "Users retrieved successfully"));
            }
            catch (Exception ex)
            {
                return StatusCode(500, ApiResponse<List<UserListDto>>.ErrorResponse("An error occurred while retrieving users by role", new List<string> { ex.Message }));
            }
        }

        /// <summary>
        /// Get archived (soft-deleted) users
        /// </summary>
        [RequirePermission("ArchiveUsers")]
        [HttpGet("archive")]
        public async Task<ActionResult<ApiResponse<PagedResultDto<UserListDto>>>> GetArchivedUsers([FromQuery] PaginationDto pagination)
        {
            try
            {
                var result = await _userService.GetArchivedUsersAsync(pagination);
                return Ok(ApiResponse<PagedResultDto<UserListDto>>.SuccessResponse(result, "Archived users retrieved successfully"));
            }
            catch (Exception ex)
            {
                return StatusCode(500, ApiResponse<PagedResultDto<UserListDto>>.ErrorResponse("An error occurred while retrieving archived users", new List<string> { ex.Message }));
            }
        }

        /// <summary>
        /// Create a new user (automatically sends welcome email with credentials)
        /// </summary>
        [RequirePermission("CreateUsers")]
        [HttpPost]
        public async Task<ActionResult<ApiResponse<UserResponseDto>>> CreateUser([FromBody] CreateUserDto dto)
        {
            try
            {
                if (!await ActorCanAssignRolesAsync(dto.RoleIds))
                    return StatusCode(403, ApiResponse<UserResponseDto>.ErrorResponse("Admins cannot assign Super Admin or Admin roles."));

                var currentUserId = HttpContext.GetCurrentUserId();
                var user = await _userService.CreateUserAsync(dto, currentUserId);
                return CreatedAtAction(nameof(GetUserById), new { id = user.Id },
                    ApiResponse<UserResponseDto>.SuccessResponse(user, "User created successfully. Welcome email sent to user."));
            }
            catch (InvalidOperationException ex)
            {
                return BadRequest(ApiResponse<UserResponseDto>.ErrorResponse(ex.Message));
            }
            catch (Exception ex)
            {
                return StatusCode(500, ApiResponse<UserResponseDto>.ErrorResponse("An error occurred while creating user", new List<string> { ex.Message }));
            }
        }

        /// <summary>
        /// Update an existing user
        /// </summary>
        [RequirePermission("UpdateUsers")]
        [HttpPut("{id}")]
        public async Task<ActionResult<ApiResponse<UserResponseDto>>> UpdateUser(int id, [FromBody] UpdateUserDto dto)
        {
            try
            {
                if (!await ActorCanAssignRolesAsync(dto.RoleIds))
                    return StatusCode(403, ApiResponse<UserResponseDto>.ErrorResponse("Admins cannot assign Super Admin or Admin roles."));

                var currentUserId = HttpContext.GetCurrentUserId();
                var user = await _userService.UpdateUserAsync(id, dto, currentUserId);
                if (user == null)
                {
                    return NotFound(ApiResponse<UserResponseDto>.ErrorResponse("User not found"));
                }

                return Ok(ApiResponse<UserResponseDto>.SuccessResponse(user, "User updated successfully"));
            }
            catch (InvalidOperationException ex)
            {
                return BadRequest(ApiResponse<UserResponseDto>.ErrorResponse(ex.Message));
            }
            catch (Exception ex)
            {
                return StatusCode(500, ApiResponse<UserResponseDto>.ErrorResponse("An error occurred while updating user", new List<string> { ex.Message }));
            }
        }

        /// <summary>
        /// Soft delete a user (moves to archive)
        /// </summary>
        [RequirePermission("DeleteUsers")]
        [HttpDelete("{id}")]
        public async Task<ActionResult<ApiResponse<object>>> DeleteUser(int id)
        {
            try
            {
                var currentUserId = HttpContext.GetCurrentUserId();
                var result = await _userService.DeleteUserAsync(id, currentUserId);
                if (!result)
                {
                    return NotFound(ApiResponse<object>.ErrorResponse("User not found"));
                }

                return Ok(ApiResponse<object>.SuccessResponse(null, "User deleted successfully"));
            }
            catch (Exception ex)
            {
                return StatusCode(500, ApiResponse<object>.ErrorResponse("An error occurred while deleting user", new List<string> { ex.Message }));
            }
        }

        /// <summary>
        /// Restore a soft-deleted user from archive
        /// </summary>
        [RequirePermission("RestoreUsers")]
        [HttpPut("{id}/restore")]
        public async Task<ActionResult<ApiResponse<object>>> RestoreUser(int id)
        {
            try
            {
                var currentUserId = HttpContext.GetCurrentUserId();
                var result = await _userService.RestoreUserAsync(id, currentUserId);
                if (!result)
                {
                    return NotFound(ApiResponse<object>.ErrorResponse("User not found in archive"));
                }

                return Ok(ApiResponse<object>.SuccessResponse(null, "User restored successfully"));
            }
            catch (Exception ex)
            {
                return StatusCode(500, ApiResponse<object>.ErrorResponse("An error occurred while restoring user", new List<string> { ex.Message }));
            }
        }

        /// <summary>
        /// Permanently delete a user (cannot be undone)
        /// </summary>
        [RequirePermission("PermanentDeleteUsers")]
        [HttpDelete("{id}/permanent")]
        public async Task<ActionResult<ApiResponse<object>>> PermanentDeleteUser(int id)
        {
            try
            {
                var currentUserId = HttpContext.GetCurrentUserId();
                var result = await _userService.PermanentDeleteUserAsync(id, currentUserId);
                if (!result)
                {
                    return NotFound(ApiResponse<object>.ErrorResponse("User not found in archive"));
                }

                return Ok(ApiResponse<object>.SuccessResponse(null, "User permanently deleted"));
            }
            catch (Exception ex)
            {
                return StatusCode(500, ApiResponse<object>.ErrorResponse("An error occurred while permanently deleting user", new List<string> { ex.Message }));
            }
        }

        /// <summary>
        /// Assign roles to a user
        /// </summary>
        [RequirePermission("UpdateUsers")]
        [HttpPost("{id}/roles")]
        public async Task<ActionResult<ApiResponse<object>>> AssignRolesToUser(int id, [FromBody] List<int> roleIds)
        {
            try
            {
                var currentUserId = HttpContext.GetCurrentUserId();
                var result = await _userService.AssignRolesToUserAsync(id, roleIds, currentUserId);
                if (!result)
                {
                    return NotFound(ApiResponse<object>.ErrorResponse("User not found"));
                }

                return Ok(ApiResponse<object>.SuccessResponse(null, "Roles assigned successfully"));
            }
            catch (Exception ex)
            {
                return StatusCode(500, ApiResponse<object>.ErrorResponse("An error occurred while assigning roles", new List<string> { ex.Message }));
            }
        }

        /// <summary>
        /// Get paginated list of Lead + Customer users (Client Log)
        /// </summary>
        [RequirePermission("ViewUsers")]
        [HttpGet("clients")]
        public async Task<ActionResult<ApiResponse<PagedResultDto<ClientLogListDto>>>> GetClients([FromQuery] PaginationDto pagination)
        {
            try
            {
                var result = await _userService.GetClientSummariesAsync(pagination);
                return Ok(ApiResponse<PagedResultDto<ClientLogListDto>>.SuccessResponse(result, "Client log retrieved successfully"));
            }
            catch (Exception ex)
            {
                return StatusCode(500, ApiResponse<PagedResultDto<ClientLogListDto>>.ErrorResponse("An error occurred while retrieving client log", new List<string> { ex.Message }));
            }
        }

        /// <summary>
        /// Get full detail (profile + transactions + ongoing sessions) for a Lead/Customer user
        /// </summary>
        [RequirePermission("ViewUsers")]
        [HttpGet("clients/{id}")]
        public async Task<ActionResult<ApiResponse<ClientDetailDto>>> GetClientDetail(int id)
        {
            try
            {
                var result = await _userService.GetClientDetailAsync(id);
                if (result == null)
                    return NotFound(ApiResponse<ClientDetailDto>.ErrorResponse("Client not found"));

                return Ok(ApiResponse<ClientDetailDto>.SuccessResponse(result, "Client detail retrieved successfully"));
            }
            catch (Exception ex)
            {
                return StatusCode(500, ApiResponse<ClientDetailDto>.ErrorResponse("An error occurred while retrieving client detail", new List<string> { ex.Message }));
            }
        }

        /// <summary>
        /// Fires a ProfileCompleted automation email for the current user.
        /// Called by the frontend once after the welcome setup wizard finishes.
        /// </summary>
        [HttpPost("complete-profile")]
        public async Task<ActionResult<ApiResponse<object>>> CompleteProfile()
        {
            var userId = HttpContext.GetCurrentUserId();
            if (userId == null)
                return Unauthorized(ApiResponse<object>.ErrorResponse("Unauthorized"));

            var user = await _userService.GetUserByIdAsync(userId.Value);
            if (user == null)
                return NotFound(ApiResponse<object>.ErrorResponse("User not found"));

            try
            {
                await _automationService.TriggerAndSendImmediatelyAsync("ProfileCompleted", new Dictionary<string, object>
                {
                    { "Email",     user.Email ?? "" },
                    { "FirstName", user.FirstName ?? user.Email ?? "" },
                    { "UserId",    userId.Value }
                });
            }
            catch
            {
                // Non-critical — don't surface email failures to the user
            }

            return Ok(ApiResponse<object>.SuccessResponse(null, "Profile completion notification sent"));
        }
    }
}
