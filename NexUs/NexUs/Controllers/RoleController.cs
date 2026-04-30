using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using NexUs.Attributes;
using NexUs.Extensions;
using NexUs.Models.DTO.Common;
using NexUs.Models.DTO.Permissions;
using NexUs.Models.DTO.Roles;
using NexUs.Services.Interfaces;

namespace NexUs.Controllers
{
    [Route("api/role")]
    [ApiController]
    [Authorize]
    public class RoleController : ControllerBase
    {
        private readonly IRoleService _roleService;

        public RoleController(IRoleService roleService)
        {
            _roleService = roleService;
        }

        /// <summary>
        /// Get all active roles with pagination and search
        /// </summary>
        [RequirePermission("ViewRoles")]
        [HttpGet]
        public async Task<ActionResult<ApiResponse<PagedResultDto<RoleListDto>>>> GetAllRoles([FromQuery] PaginationDto pagination)
        {
            try
            {
                var result = await _roleService.GetAllRolesAsync(pagination);
                return Ok(ApiResponse<PagedResultDto<RoleListDto>>.SuccessResponse(result, "Roles retrieved successfully"));
            }
            catch (Exception)
            {
                return StatusCode(500, ApiResponse<PagedResultDto<RoleListDto>>.ErrorResponse("An error occurred while retrieving roles"));
            }
        }

        /// <summary>
        /// Get role by ID with permissions
        /// </summary>
        [RequirePermission("ViewRoles")]
        [HttpGet("{id}")]
        public async Task<ActionResult<ApiResponse<RoleResponseDto>>> GetRoleById(int id)
        {
            try
            {
                var role = await _roleService.GetRoleByIdAsync(id);
                if (role == null)
                {
                    return NotFound(ApiResponse<RoleResponseDto>.ErrorResponse("Role not found"));
                }

                return Ok(ApiResponse<RoleResponseDto>.SuccessResponse(role, "Role retrieved successfully"));
            }
            catch (Exception)
            {
                return StatusCode(500, ApiResponse<RoleResponseDto>.ErrorResponse("An error occurred while retrieving role"));
            }
        }

        /// <summary>
        /// Get role's permissions
        /// </summary>
        [RequirePermission("ViewRoles")]
        [HttpGet("{id}/permissions")]
        public async Task<ActionResult<ApiResponse<List<PermissionListDto>>>> GetRolePermissions(int id)
        {
            try
            {
                var permissions = await _roleService.GetRolePermissionsAsync(id);
                return Ok(ApiResponse<List<PermissionListDto>>.SuccessResponse(permissions, "Role permissions retrieved successfully"));
            }
            catch (Exception)
            {
                return StatusCode(500, ApiResponse<List<PermissionListDto>>.ErrorResponse("An error occurred while retrieving role permissions"));
            }
        }

        /// <summary>
        /// Get archived (soft-deleted) roles
        /// </summary>
        [RequirePermission("ArchiveRoles")]
        [HttpGet("archive")]
        public async Task<ActionResult<ApiResponse<PagedResultDto<RoleListDto>>>> GetArchivedRoles([FromQuery] PaginationDto pagination)
        {
            try
            {
                var result = await _roleService.GetArchivedRolesAsync(pagination);
                return Ok(ApiResponse<PagedResultDto<RoleListDto>>.SuccessResponse(result, "Archived roles retrieved successfully"));
            }
            catch (Exception)
            {
                return StatusCode(500, ApiResponse<PagedResultDto<RoleListDto>>.ErrorResponse("An error occurred while retrieving archived roles"));
            }
        }

        /// <summary>
        /// Create a new role
        /// </summary>
        [RequirePermission("CreateRoles")]
        [HttpPost]
        public async Task<ActionResult<ApiResponse<RoleResponseDto>>> CreateRole([FromBody] CreateRoleDto dto)
        {
            try
            {
                var currentUserId = HttpContext.GetCurrentUserId();
                var role = await _roleService.CreateRoleAsync(dto, currentUserId);
                return CreatedAtAction(nameof(GetRoleById), new { id = role.Id },
                    ApiResponse<RoleResponseDto>.SuccessResponse(role, "Role created successfully"));
            }
            catch (InvalidOperationException ex)
            {
                return BadRequest(ApiResponse<RoleResponseDto>.ErrorResponse(ex.Message));
            }
            catch (Exception)
            {
                return StatusCode(500, ApiResponse<RoleResponseDto>.ErrorResponse("An error occurred while creating role"));
            }
        }

        /// <summary>
        /// Update an existing role
        /// </summary>
        [RequirePermission("UpdateRoles")]
        [HttpPut("{id}")]
        public async Task<ActionResult<ApiResponse<RoleResponseDto>>> UpdateRole(int id, [FromBody] UpdateRoleDto dto)
        {
            try
            {
                var currentUserId = HttpContext.GetCurrentUserId();
                var role = await _roleService.UpdateRoleAsync(id, dto, currentUserId);
                if (role == null)
                {
                    return NotFound(ApiResponse<RoleResponseDto>.ErrorResponse("Role not found"));
                }

                return Ok(ApiResponse<RoleResponseDto>.SuccessResponse(role, "Role updated successfully"));
            }
            catch (InvalidOperationException ex)
            {
                return BadRequest(ApiResponse<RoleResponseDto>.ErrorResponse(ex.Message));
            }
            catch (Exception)
            {
                return StatusCode(500, ApiResponse<RoleResponseDto>.ErrorResponse("An error occurred while updating role"));
            }
        }

        /// <summary>
        /// Soft delete a role (moves to archive)
        /// </summary>
        [RequirePermission("DeleteRoles")]
        [HttpDelete("{id}")]
        public async Task<ActionResult<ApiResponse<object>>> DeleteRole(int id)
        {
            try
            {
                var currentUserId = HttpContext.GetCurrentUserId();
                var result = await _roleService.DeleteRoleAsync(id, currentUserId);
                if (!result)
                {
                    return NotFound(ApiResponse<object>.ErrorResponse("Role not found"));
                }

                return Ok(ApiResponse<object>.SuccessResponse(null, "Role deleted successfully"));
            }
            catch (Exception)
            {
                return StatusCode(500, ApiResponse<object>.ErrorResponse("An error occurred while deleting role"));
            }
        }

        /// <summary>
        /// Restore a soft-deleted role from archive
        /// </summary>
        [RequirePermission("RestoreRoles")]
        [HttpPut("{id}/restore")]
        public async Task<ActionResult<ApiResponse<object>>> RestoreRole(int id)
        {
            try
            {
                var currentUserId = HttpContext.GetCurrentUserId();
                var result = await _roleService.RestoreRoleAsync(id, currentUserId);
                if (!result)
                {
                    return NotFound(ApiResponse<object>.ErrorResponse("Role not found in archive"));
                }

                return Ok(ApiResponse<object>.SuccessResponse(null, "Role restored successfully"));
            }
            catch (Exception)
            {
                return StatusCode(500, ApiResponse<object>.ErrorResponse("An error occurred while restoring role"));
            }
        }

        /// <summary>
        /// Permanently delete a role (cannot be undone)
        /// </summary>
        [RequirePermission("PermanentDeleteRoles")]
        [HttpDelete("{id}/permanent")]
        public async Task<ActionResult<ApiResponse<object>>> PermanentDeleteRole(int id)
        {
            try
            {
                var currentUserId = HttpContext.GetCurrentUserId();
                var result = await _roleService.PermanentDeleteRoleAsync(id, currentUserId);
                if (!result)
                {
                    return NotFound(ApiResponse<object>.ErrorResponse("Role not found in archive"));
                }

                return Ok(ApiResponse<object>.SuccessResponse(null, "Role permanently deleted"));
            }
            catch (Exception)
            {
                return StatusCode(500, ApiResponse<object>.ErrorResponse("An error occurred while permanently deleting role"));
            }
        }

        /// <summary>
        /// Assign permissions to a role
        /// </summary>
        [RequirePermission("UpdateRoles")]
        [HttpPost("{id}/permissions")]
        public async Task<ActionResult<ApiResponse<object>>> AssignPermissionsToRole(int id, [FromBody] AssignPermissionsDto dto)
        {
            try
            {
                var currentUserId = HttpContext.GetCurrentUserId();
                var result = await _roleService.AssignPermissionsToRoleAsync(id, dto, currentUserId);
                if (!result)
                {
                    return NotFound(ApiResponse<object>.ErrorResponse("Role not found"));
                }

                return Ok(ApiResponse<object>.SuccessResponse(null, "Permissions assigned successfully"));
            }
            catch (Exception)
            {
                return StatusCode(500, ApiResponse<object>.ErrorResponse("An error occurred while assigning permissions"));
            }
        }
    }
}
