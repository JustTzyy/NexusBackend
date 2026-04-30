using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using NexUs.Attributes;
using NexUs.Extensions;
using NexUs.Models.DTO.Buildings;
using NexUs.Models.DTO.Common;
using NexUs.Services.Interfaces;

namespace NexUs.Controllers
{
    [Route("api/building")]
    [ApiController]
    [Authorize]
    public class BuildingController : ControllerBase
    {
        private readonly IBuildingService _buildingService;

        public BuildingController(IBuildingService buildingService)
        {
            _buildingService = buildingService;
        }

        /// <summary>
        /// Get all active buildings as a simple lookup list (no permission required)
        /// </summary>
        [HttpGet("lookup")]
        public async Task<ActionResult<ApiResponse<PagedResultDto<BuildingListDto>>>> GetBuildingLookup()
        {
            try
            {
                var result = await _buildingService.GetAllBuildingsAsync(new PaginationDto { PageSize = 1000 });
                return Ok(ApiResponse<PagedResultDto<BuildingListDto>>.SuccessResponse(result, "Buildings retrieved successfully"));
            }
            catch (Exception)
            {
                return StatusCode(500, ApiResponse<PagedResultDto<BuildingListDto>>.ErrorResponse("An error occurred while retrieving buildings"));
            }
        }

        /// <summary>
        /// Get all active buildings with pagination and search
        /// </summary>
        [RequirePermission("ViewBuildings")]
        [HttpGet]
        public async Task<ActionResult<ApiResponse<PagedResultDto<BuildingListDto>>>> GetAllBuildings([FromQuery] PaginationDto pagination)
        {
            try
            {
                var result = await _buildingService.GetAllBuildingsAsync(pagination);
                return Ok(ApiResponse<PagedResultDto<BuildingListDto>>.SuccessResponse(result, "Buildings retrieved successfully"));
            }
            catch (Exception)
            {
                return StatusCode(500, ApiResponse<PagedResultDto<BuildingListDto>>.ErrorResponse("An error occurred while retrieving buildings"));
            }
        }

        /// <summary>
        /// Get archived (soft-deleted) buildings
        /// </summary>
        [RequirePermission("ArchiveBuildings")]
        [HttpGet("archive")]
        public async Task<ActionResult<ApiResponse<PagedResultDto<BuildingListDto>>>> GetArchivedBuildings([FromQuery] PaginationDto pagination)
        {
            try
            {
                var result = await _buildingService.GetArchivedBuildingsAsync(pagination);
                return Ok(ApiResponse<PagedResultDto<BuildingListDto>>.SuccessResponse(result, "Archived buildings retrieved successfully"));
            }
            catch (Exception)
            {
                return StatusCode(500, ApiResponse<PagedResultDto<BuildingListDto>>.ErrorResponse("An error occurred while retrieving archived buildings"));
            }
        }

        /// <summary>
        /// Get available building managers (not already assigned to an active building)
        /// </summary>
        [RequirePermission("ViewBuildings")]
        [HttpGet("available-managers")]
        public async Task<ActionResult<ApiResponse<List<AvailableManagerDto>>>> GetAvailableManagers([FromQuery] int? excludeBuildingId)
        {
            try
            {
                var result = await _buildingService.GetAvailableManagersAsync(excludeBuildingId);
                return Ok(ApiResponse<List<AvailableManagerDto>>.SuccessResponse(result, "Available managers retrieved successfully"));
            }
            catch (Exception)
            {
                return StatusCode(500, ApiResponse<List<AvailableManagerDto>>.ErrorResponse("An error occurred while retrieving available managers"));
            }
        }

        /// <summary>
        /// Get the building managed by the currently authenticated Building Manager
        /// </summary>
        [HttpGet("my")]
        public async Task<ActionResult<ApiResponse<BuildingListDto?>>> GetMyBuilding()
        {
            try
            {
                var currentUserId = HttpContext.GetCurrentUserId();
                if (!currentUserId.HasValue)
                    return Unauthorized(ApiResponse<BuildingListDto?>.ErrorResponse("User not authenticated"));

                var result = await _buildingService.GetMyBuildingAsync(currentUserId.Value);
                return Ok(ApiResponse<BuildingListDto?>.SuccessResponse(result, "My building retrieved"));
            }
            catch (Exception)
            {
                return StatusCode(500, ApiResponse<BuildingListDto?>.ErrorResponse("Failed to get my building"));
            }
        }

        /// <summary>
        /// Get recommended building based on user location (city/province/region)
        /// </summary>
        [HttpGet("recommended")]
        public async Task<ActionResult<ApiResponse<BuildingListDto?>>> GetRecommendedBuilding(
            [FromQuery] string? city = null,
            [FromQuery] string? province = null,
            [FromQuery] string? region = null,
            [FromQuery] int? preferredBuildingId = null)
        {
            try
            {
                var result = await _buildingService.GetRecommendedBuildingAsync(city ?? "", province ?? "", region ?? "", preferredBuildingId);

                if (result == null)
                {
                    var hasAddress = !string.IsNullOrEmpty(city) || !string.IsNullOrEmpty(province) || !string.IsNullOrEmpty(region);
                    var message = hasAddress
                        ? "No building available in this area"
                        : "No address provided";
                    return Ok(ApiResponse<BuildingListDto?>.SuccessResponse(null, message));
                }

                return Ok(ApiResponse<BuildingListDto?>.SuccessResponse(result, "Recommended building retrieved"));
            }
            catch (Exception)
            {
                return StatusCode(500, ApiResponse<BuildingListDto?>.ErrorResponse("Failed to get recommended building"));
            }
        }

        /// <summary>
        /// Get building by ID with address and manager
        /// </summary>
        [RequirePermission("ViewBuildings")]
        [HttpGet("{id:int}")]
        public async Task<ActionResult<ApiResponse<BuildingResponseDto>>> GetBuildingById(int id)
        {
            try
            {
                var building = await _buildingService.GetBuildingByIdAsync(id);
                if (building == null)
                {
                    return NotFound(ApiResponse<BuildingResponseDto>.ErrorResponse("Building not found"));
                }

                return Ok(ApiResponse<BuildingResponseDto>.SuccessResponse(building, "Building retrieved successfully"));
            }
            catch (Exception)
            {
                return StatusCode(500, ApiResponse<BuildingResponseDto>.ErrorResponse("An error occurred while retrieving building"));
            }
        }

        /// <summary>
        /// Create a new building
        /// </summary>
        [RequirePermission("CreateBuildings")]
        [HttpPost]
        public async Task<ActionResult<ApiResponse<BuildingResponseDto>>> CreateBuilding([FromBody] CreateBuildingDto dto)
        {
            try
            {
                var currentUserId = HttpContext.GetCurrentUserId();
                var building = await _buildingService.CreateBuildingAsync(dto, currentUserId);
                return CreatedAtAction(nameof(GetBuildingById), new { id = building.Id },
                    ApiResponse<BuildingResponseDto>.SuccessResponse(building, "Building created successfully"));
            }
            catch (InvalidOperationException ex)
            {
                return BadRequest(ApiResponse<BuildingResponseDto>.ErrorResponse(ex.Message));
            }
            catch (Exception)
            {
                return StatusCode(500, ApiResponse<BuildingResponseDto>.ErrorResponse("An error occurred while creating building"));
            }
        }

        /// <summary>
        /// Update an existing building
        /// </summary>
        [RequirePermission("UpdateBuildings")]
        [HttpPut("{id}")]
        public async Task<ActionResult<ApiResponse<BuildingResponseDto>>> UpdateBuilding(int id, [FromBody] UpdateBuildingDto dto)
        {
            try
            {
                var currentUserId = HttpContext.GetCurrentUserId();
                var building = await _buildingService.UpdateBuildingAsync(id, dto, currentUserId);
                if (building == null)
                {
                    return NotFound(ApiResponse<BuildingResponseDto>.ErrorResponse("Building not found"));
                }

                return Ok(ApiResponse<BuildingResponseDto>.SuccessResponse(building, "Building updated successfully"));
            }
            catch (InvalidOperationException ex)
            {
                return BadRequest(ApiResponse<BuildingResponseDto>.ErrorResponse(ex.Message));
            }
            catch (Exception)
            {
                return StatusCode(500, ApiResponse<BuildingResponseDto>.ErrorResponse("An error occurred while updating building"));
            }
        }

        /// <summary>
        /// Soft delete a building (moves to archive)
        /// </summary>
        [RequirePermission("DeleteBuildings")]
        [HttpDelete("{id}")]
        public async Task<ActionResult<ApiResponse<object>>> DeleteBuilding(int id)
        {
            try
            {
                var currentUserId = HttpContext.GetCurrentUserId();
                var result = await _buildingService.DeleteBuildingAsync(id, currentUserId);
                if (!result)
                {
                    return NotFound(ApiResponse<object>.ErrorResponse("Building not found"));
                }

                return Ok(ApiResponse<object>.SuccessResponse(null, "Building deleted successfully"));
            }
            catch (Exception)
            {
                return StatusCode(500, ApiResponse<object>.ErrorResponse("An error occurred while deleting building"));
            }
        }

        /// <summary>
        /// Restore a soft-deleted building from archive
        /// </summary>
        [RequirePermission("RestoreBuildings")]
        [HttpPut("{id}/restore")]
        public async Task<ActionResult<ApiResponse<object>>> RestoreBuilding(int id)
        {
            try
            {
                var currentUserId = HttpContext.GetCurrentUserId();
                var result = await _buildingService.RestoreBuildingAsync(id, currentUserId);
                if (!result)
                {
                    return NotFound(ApiResponse<object>.ErrorResponse("Building not found in archive"));
                }

                return Ok(ApiResponse<object>.SuccessResponse(null, "Building restored successfully"));
            }
            catch (Exception)
            {
                return StatusCode(500, ApiResponse<object>.ErrorResponse("An error occurred while restoring building"));
            }
        }

        /// <summary>
        /// Permanently delete a building (cannot be undone)
        /// </summary>
        [RequirePermission("PermanentDeleteBuildings")]
        [HttpDelete("{id}/permanent")]
        public async Task<ActionResult<ApiResponse<object>>> PermanentDeleteBuilding(int id)
        {
            try
            {
                var currentUserId = HttpContext.GetCurrentUserId();
                var result = await _buildingService.PermanentDeleteBuildingAsync(id, currentUserId);
                if (!result)
                {
                    return NotFound(ApiResponse<object>.ErrorResponse("Building not found in archive"));
                }

                return Ok(ApiResponse<object>.SuccessResponse(null, "Building permanently deleted"));
            }
            catch (Exception)
            {
                return StatusCode(500, ApiResponse<object>.ErrorResponse("An error occurred while permanently deleting building"));
            }
        }
    }
}
