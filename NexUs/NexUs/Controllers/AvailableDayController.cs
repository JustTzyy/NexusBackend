using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using NexUs.Attributes;
using NexUs.Extensions;
using NexUs.Models.DTO.Common;
using NexUs.Models.DTO.AvailableDays;
using NexUs.Services.Interfaces;

namespace NexUs.Controllers
{
    [Route("api/available-day")]
    [ApiController]
    [Authorize]
    public class AvailableDayController : ControllerBase
    {
        private readonly IAvailableDayService _availableDayService;

        public AvailableDayController(IAvailableDayService availableDayService)
        {
            _availableDayService = availableDayService;
        }

        /// <summary>
        /// Lookup all active available days (no permission required - reference data)
        /// </summary>
        [HttpGet("lookup")]
        public async Task<ActionResult<ApiResponse<PagedResultDto<AvailableDayListDto>>>> LookupAvailableDays()
        {
            try
            {
                var result = await _availableDayService.GetAllAvailableDaysAsync(new PaginationDto { PageNumber = 1, PageSize = 200 });
                return Ok(ApiResponse<PagedResultDto<AvailableDayListDto>>.SuccessResponse(result, "Available days retrieved successfully"));
            }
            catch (Exception ex)
            {
                return StatusCode(500, ApiResponse<PagedResultDto<AvailableDayListDto>>.ErrorResponse("An error occurred while retrieving available days", new List<string> { ex.Message }));
            }
        }

        [RequirePermission("ViewAvailableDays")]
        [HttpGet]
        public async Task<ActionResult<ApiResponse<PagedResultDto<AvailableDayListDto>>>> GetAllAvailableDays([FromQuery] PaginationDto pagination)
        {
            try
            {
                var result = await _availableDayService.GetAllAvailableDaysAsync(pagination);
                return Ok(ApiResponse<PagedResultDto<AvailableDayListDto>>.SuccessResponse(result, "Available days retrieved successfully"));
            }
            catch (Exception ex)
            {
                return StatusCode(500, ApiResponse<PagedResultDto<AvailableDayListDto>>.ErrorResponse("An error occurred while retrieving available days", new List<string> { ex.Message }));
            }
        }

        [RequirePermission("ArchiveAvailableDays")]
        [HttpGet("archive")]
        public async Task<ActionResult<ApiResponse<PagedResultDto<AvailableDayListDto>>>> GetArchivedAvailableDays([FromQuery] PaginationDto pagination)
        {
            try
            {
                var result = await _availableDayService.GetArchivedAvailableDaysAsync(pagination);
                return Ok(ApiResponse<PagedResultDto<AvailableDayListDto>>.SuccessResponse(result, "Archived available days retrieved successfully"));
            }
            catch (Exception ex)
            {
                return StatusCode(500, ApiResponse<PagedResultDto<AvailableDayListDto>>.ErrorResponse("An error occurred while retrieving archived available days", new List<string> { ex.Message }));
            }
        }

        [RequirePermission("ViewAvailableDays")]
        [HttpGet("{id:int}")]
        public async Task<ActionResult<ApiResponse<AvailableDayResponseDto>>> GetAvailableDayById(int id)
        {
            try
            {
                var day = await _availableDayService.GetAvailableDayByIdAsync(id);
                if (day == null)
                {
                    return NotFound(ApiResponse<AvailableDayResponseDto>.ErrorResponse("Available day not found"));
                }

                return Ok(ApiResponse<AvailableDayResponseDto>.SuccessResponse(day, "Available day retrieved successfully"));
            }
            catch (Exception ex)
            {
                return StatusCode(500, ApiResponse<AvailableDayResponseDto>.ErrorResponse("An error occurred while retrieving available day", new List<string> { ex.Message }));
            }
        }

        [RequirePermission("CreateAvailableDays")]
        [HttpPost]
        public async Task<ActionResult<ApiResponse<AvailableDayResponseDto>>> CreateAvailableDay([FromBody] CreateAvailableDayDto dto)
        {
            try
            {
                var currentUserId = HttpContext.GetCurrentUserId();
                var day = await _availableDayService.CreateAvailableDayAsync(dto, currentUserId);
                return CreatedAtAction(nameof(GetAvailableDayById), new { id = day.Id },
                    ApiResponse<AvailableDayResponseDto>.SuccessResponse(day, "Available day created successfully"));
            }
            catch (InvalidOperationException ex)
            {
                return BadRequest(ApiResponse<AvailableDayResponseDto>.ErrorResponse(ex.Message));
            }
            catch (Exception ex)
            {
                return StatusCode(500, ApiResponse<AvailableDayResponseDto>.ErrorResponse("An error occurred while creating available day", new List<string> { ex.Message }));
            }
        }

        [RequirePermission("UpdateAvailableDays")]
        [HttpPut("{id}")]
        public async Task<ActionResult<ApiResponse<AvailableDayResponseDto>>> UpdateAvailableDay(int id, [FromBody] UpdateAvailableDayDto dto)
        {
            try
            {
                var currentUserId = HttpContext.GetCurrentUserId();
                var day = await _availableDayService.UpdateAvailableDayAsync(id, dto, currentUserId);
                if (day == null)
                {
                    return NotFound(ApiResponse<AvailableDayResponseDto>.ErrorResponse("Available day not found"));
                }

                return Ok(ApiResponse<AvailableDayResponseDto>.SuccessResponse(day, "Available day updated successfully"));
            }
            catch (InvalidOperationException ex)
            {
                return BadRequest(ApiResponse<AvailableDayResponseDto>.ErrorResponse(ex.Message));
            }
            catch (Exception ex)
            {
                return StatusCode(500, ApiResponse<AvailableDayResponseDto>.ErrorResponse("An error occurred while updating available day", new List<string> { ex.Message }));
            }
        }

        [RequirePermission("DeleteAvailableDays")]
        [HttpDelete("{id}")]
        public async Task<ActionResult<ApiResponse<object>>> DeleteAvailableDay(int id)
        {
            try
            {
                var currentUserId = HttpContext.GetCurrentUserId();
                var result = await _availableDayService.DeleteAvailableDayAsync(id, currentUserId);
                if (!result)
                {
                    return NotFound(ApiResponse<object>.ErrorResponse("Available day not found"));
                }

                return Ok(ApiResponse<object>.SuccessResponse(null, "Available day deleted successfully"));
            }
            catch (Exception ex)
            {
                return StatusCode(500, ApiResponse<object>.ErrorResponse("An error occurred while deleting available day", new List<string> { ex.Message }));
            }
        }

        [RequirePermission("RestoreAvailableDays")]
        [HttpPut("{id}/restore")]
        public async Task<ActionResult<ApiResponse<object>>> RestoreAvailableDay(int id)
        {
            try
            {
                var currentUserId = HttpContext.GetCurrentUserId();
                var result = await _availableDayService.RestoreAvailableDayAsync(id, currentUserId);
                if (!result)
                {
                    return NotFound(ApiResponse<object>.ErrorResponse("Available day not found in archive"));
                }

                return Ok(ApiResponse<object>.SuccessResponse(null, "Available day restored successfully"));
            }
            catch (Exception ex)
            {
                return StatusCode(500, ApiResponse<object>.ErrorResponse("An error occurred while restoring available day", new List<string> { ex.Message }));
            }
        }

        [RequirePermission("PermanentDeleteAvailableDays")]
        [HttpDelete("{id}/permanent")]
        public async Task<ActionResult<ApiResponse<object>>> PermanentDeleteAvailableDay(int id)
        {
            try
            {
                var currentUserId = HttpContext.GetCurrentUserId();
                var result = await _availableDayService.PermanentDeleteAvailableDayAsync(id, currentUserId);
                if (!result)
                {
                    return NotFound(ApiResponse<object>.ErrorResponse("Available day not found in archive"));
                }

                return Ok(ApiResponse<object>.SuccessResponse(null, "Available day permanently deleted"));
            }
            catch (Exception ex)
            {
                return StatusCode(500, ApiResponse<object>.ErrorResponse("An error occurred while permanently deleting available day", new List<string> { ex.Message }));
            }
        }
    }
}
