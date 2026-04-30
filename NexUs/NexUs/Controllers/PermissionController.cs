using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using NexUs.Attributes;
using NexUs.Extensions;
using NexUs.Models.DTO.Common;
using NexUs.Models.DTO.Permissions;
using NexUs.Services.Interfaces;

namespace NexUs.Controllers
{
    [Route("api/permission")]
    [ApiController]
    [Authorize]
    public class PermissionController : ControllerBase
    {
        private readonly IPermissionService _permissionService;

        public PermissionController(IPermissionService permissionService)
        {
            _permissionService = permissionService;
        }

        /// <summary>
        /// Get all active permissions with pagination and search
        /// </summary>
        [RequirePermission("ViewPermissions")]
        [HttpGet]
        public async Task<ActionResult<ApiResponse<PagedResultDto<PermissionListDto>>>> GetAllPermissions([FromQuery] PaginationDto pagination)
        {
            try
            {
                var result = await _permissionService.GetAllPermissionsAsync(pagination);
                return Ok(ApiResponse<PagedResultDto<PermissionListDto>>.SuccessResponse(result, "Permissions retrieved successfully"));
            }
            catch (Exception)
            {
                return StatusCode(500, ApiResponse<PagedResultDto<PermissionListDto>>.ErrorResponse("An error occurred while retrieving permissions"));
            }
        }

        /// <summary>
        /// Get permission by ID
        /// </summary>
        [RequirePermission("ViewPermissions")]
        [HttpGet("{id}")]
        public async Task<ActionResult<ApiResponse<PermissionResponseDto>>> GetPermissionById(int id)
        {
            try
            {
                var permission = await _permissionService.GetPermissionByIdAsync(id);
                if (permission == null)
                {
                    return NotFound(ApiResponse<PermissionResponseDto>.ErrorResponse("Permission not found"));
                }

                return Ok(ApiResponse<PermissionResponseDto>.SuccessResponse(permission, "Permission retrieved successfully"));
            }
            catch (Exception)
            {
                return StatusCode(500, ApiResponse<PermissionResponseDto>.ErrorResponse("An error occurred while retrieving permission"));
            }
        }

        /// <summary>
        /// Get permissions by module
        /// </summary>
        [RequirePermission("ViewPermissions")]
        [HttpGet("module/{module}")]
        public async Task<ActionResult<ApiResponse<List<PermissionListDto>>>> GetPermissionsByModule(string module)
        {
            try
            {
                var permissions = await _permissionService.GetPermissionsByModuleAsync(module);
                return Ok(ApiResponse<List<PermissionListDto>>.SuccessResponse(permissions, "Permissions retrieved successfully"));
            }
            catch (Exception)
            {
                return StatusCode(500, ApiResponse<List<PermissionListDto>>.ErrorResponse("An error occurred while retrieving permissions"));
            }
        }

        /// <summary>
        /// Get archived (soft-deleted) permissions
        /// </summary>
        [RequirePermission("ArchivePermissions")]
        [HttpGet("archive")]
        public async Task<ActionResult<ApiResponse<PagedResultDto<PermissionListDto>>>> GetArchivedPermissions([FromQuery] PaginationDto pagination)
        {
            try
            {
                var result = await _permissionService.GetArchivedPermissionsAsync(pagination);
                return Ok(ApiResponse<PagedResultDto<PermissionListDto>>.SuccessResponse(result, "Archived permissions retrieved successfully"));
            }
            catch (Exception)
            {
                return StatusCode(500, ApiResponse<PagedResultDto<PermissionListDto>>.ErrorResponse("An error occurred while retrieving archived permissions"));
            }
        }

        /// <summary>
        /// Create a new permission
        /// </summary>
        [RequirePermission("CreatePermissions")]
        [HttpPost]
        public async Task<ActionResult<ApiResponse<PermissionResponseDto>>> CreatePermission([FromBody] CreatePermissionDto dto)
        {
            try
            {
                var currentUserId = HttpContext.GetCurrentUserId();
                var permission = await _permissionService.CreatePermissionAsync(dto, currentUserId);
                return CreatedAtAction(nameof(GetPermissionById), new { id = permission.Id },
                    ApiResponse<PermissionResponseDto>.SuccessResponse(permission, "Permission created successfully"));
            }
            catch (InvalidOperationException ex)
            {
                return BadRequest(ApiResponse<PermissionResponseDto>.ErrorResponse(ex.Message));
            }
            catch (Exception)
            {
                return StatusCode(500, ApiResponse<PermissionResponseDto>.ErrorResponse("An error occurred while creating permission"));
            }
        }

        /// <summary>
        /// Update an existing permission
        /// </summary>
        [RequirePermission("UpdatePermissions")]
        [HttpPut("{id}")]
        public async Task<ActionResult<ApiResponse<PermissionResponseDto>>> UpdatePermission(int id, [FromBody] UpdatePermissionDto dto)
        {
            try
            {
                var currentUserId = HttpContext.GetCurrentUserId();
                var permission = await _permissionService.UpdatePermissionAsync(id, dto, currentUserId);
                if (permission == null)
                {
                    return NotFound(ApiResponse<PermissionResponseDto>.ErrorResponse("Permission not found"));
                }

                return Ok(ApiResponse<PermissionResponseDto>.SuccessResponse(permission, "Permission updated successfully"));
            }
            catch (InvalidOperationException ex)
            {
                return BadRequest(ApiResponse<PermissionResponseDto>.ErrorResponse(ex.Message));
            }
            catch (Exception)
            {
                return StatusCode(500, ApiResponse<PermissionResponseDto>.ErrorResponse("An error occurred while updating permission"));
            }
        }

        /// <summary>
        /// Soft delete a permission (moves to archive)
        /// </summary>
        [RequirePermission("DeletePermissions")]
        [HttpDelete("{id}")]
        public async Task<ActionResult<ApiResponse<object>>> DeletePermission(int id)
        {
            try
            {
                var currentUserId = HttpContext.GetCurrentUserId();
                var result = await _permissionService.DeletePermissionAsync(id, currentUserId);
                if (!result)
                {
                    return NotFound(ApiResponse<object>.ErrorResponse("Permission not found"));
                }

                return Ok(ApiResponse<object>.SuccessResponse(null, "Permission deleted successfully"));
            }
            catch (Exception)
            {
                return StatusCode(500, ApiResponse<object>.ErrorResponse("An error occurred while deleting permission"));
            }
        }

        /// <summary>
        /// Restore a soft-deleted permission from archive
        /// </summary>
        [RequirePermission("RestorePermissions")]
        [HttpPut("{id}/restore")]
        public async Task<ActionResult<ApiResponse<object>>> RestorePermission(int id)
        {
            try
            {
                var currentUserId = HttpContext.GetCurrentUserId();
                var result = await _permissionService.RestorePermissionAsync(id, currentUserId);
                if (!result)
                {
                    return NotFound(ApiResponse<object>.ErrorResponse("Permission not found in archive"));
                }

                return Ok(ApiResponse<object>.SuccessResponse(null, "Permission restored successfully"));
            }
            catch (Exception)
            {
                return StatusCode(500, ApiResponse<object>.ErrorResponse("An error occurred while restoring permission"));
            }
        }

        /// <summary>
        /// Permanently delete a permission (cannot be undone)
        /// </summary>
        [RequirePermission("PermanentDeletePermissions")]
        [HttpDelete("{id}/permanent")]
        public async Task<ActionResult<ApiResponse<object>>> PermanentDeletePermission(int id)
        {
            try
            {
                var currentUserId = HttpContext.GetCurrentUserId();
                var result = await _permissionService.PermanentDeletePermissionAsync(id, currentUserId);
                if (!result)
                {
                    return NotFound(ApiResponse<object>.ErrorResponse("Permission not found in archive"));
                }

                return Ok(ApiResponse<object>.SuccessResponse(null, "Permission permanently deleted"));
            }
            catch (Exception)
            {
                return StatusCode(500, ApiResponse<object>.ErrorResponse("An error occurred while permanently deleting permission"));
            }
        }
    }
}
