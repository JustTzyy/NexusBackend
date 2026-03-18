using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using NexUs.Attributes;
using NexUs.Extensions;
using NexUs.Models.DTO.Common;
using NexUs.Models.DTO.AvailableTimeSlots;
using NexUs.Services.Interfaces;

namespace NexUs.Controllers
{
    [Route("api/available-time-slot")]
    [ApiController]
    [Authorize]
    public class AvailableTimeSlotController : ControllerBase
    {
        private readonly IAvailableTimeSlotService _availableTimeSlotService;

        public AvailableTimeSlotController(IAvailableTimeSlotService availableTimeSlotService)
        {
            _availableTimeSlotService = availableTimeSlotService;
        }

        /// <summary>
        /// Lookup all active time slots (no permission required - reference data)
        /// </summary>
        [HttpGet("lookup")]
        public async Task<ActionResult<ApiResponse<PagedResultDto<AvailableTimeSlotListDto>>>> LookupAvailableTimeSlots()
        {
            try
            {
                var result = await _availableTimeSlotService.GetAllAvailableTimeSlotsAsync(new PaginationDto { PageNumber = 1, PageSize = 200 });
                return Ok(ApiResponse<PagedResultDto<AvailableTimeSlotListDto>>.SuccessResponse(result, "Time slots retrieved successfully"));
            }
            catch (Exception ex)
            {
                return StatusCode(500, ApiResponse<PagedResultDto<AvailableTimeSlotListDto>>.ErrorResponse("An error occurred while retrieving time slots", new List<string> { ex.Message }));
            }
        }

        [RequirePermission("ViewAvailableTimeSlots")]
        [HttpGet]
        public async Task<ActionResult<ApiResponse<PagedResultDto<AvailableTimeSlotListDto>>>> GetAllAvailableTimeSlots([FromQuery] PaginationDto pagination)
        {
            try
            {
                var result = await _availableTimeSlotService.GetAllAvailableTimeSlotsAsync(pagination);
                return Ok(ApiResponse<PagedResultDto<AvailableTimeSlotListDto>>.SuccessResponse(result, "Time slots retrieved successfully"));
            }
            catch (Exception ex)
            {
                return StatusCode(500, ApiResponse<PagedResultDto<AvailableTimeSlotListDto>>.ErrorResponse("An error occurred while retrieving time slots", new List<string> { ex.Message }));
            }
        }

        [RequirePermission("ArchiveAvailableTimeSlots")]
        [HttpGet("archive")]
        public async Task<ActionResult<ApiResponse<PagedResultDto<AvailableTimeSlotListDto>>>> GetArchivedAvailableTimeSlots([FromQuery] PaginationDto pagination)
        {
            try
            {
                var result = await _availableTimeSlotService.GetArchivedAvailableTimeSlotsAsync(pagination);
                return Ok(ApiResponse<PagedResultDto<AvailableTimeSlotListDto>>.SuccessResponse(result, "Archived time slots retrieved successfully"));
            }
            catch (Exception ex)
            {
                return StatusCode(500, ApiResponse<PagedResultDto<AvailableTimeSlotListDto>>.ErrorResponse("An error occurred while retrieving archived time slots", new List<string> { ex.Message }));
            }
        }

        [RequirePermission("ViewAvailableTimeSlots")]
        [HttpGet("{id:int}")]
        public async Task<ActionResult<ApiResponse<AvailableTimeSlotResponseDto>>> GetAvailableTimeSlotById(int id)
        {
            try
            {
                var slot = await _availableTimeSlotService.GetAvailableTimeSlotByIdAsync(id);
                if (slot == null)
                {
                    return NotFound(ApiResponse<AvailableTimeSlotResponseDto>.ErrorResponse("Time slot not found"));
                }

                return Ok(ApiResponse<AvailableTimeSlotResponseDto>.SuccessResponse(slot, "Time slot retrieved successfully"));
            }
            catch (Exception ex)
            {
                return StatusCode(500, ApiResponse<AvailableTimeSlotResponseDto>.ErrorResponse("An error occurred while retrieving time slot", new List<string> { ex.Message }));
            }
        }

        [RequirePermission("CreateAvailableTimeSlots")]
        [HttpPost]
        public async Task<ActionResult<ApiResponse<AvailableTimeSlotResponseDto>>> CreateAvailableTimeSlot([FromBody] CreateAvailableTimeSlotDto dto)
        {
            try
            {
                var currentUserId = HttpContext.GetCurrentUserId();
                var slot = await _availableTimeSlotService.CreateAvailableTimeSlotAsync(dto, currentUserId);
                return CreatedAtAction(nameof(GetAvailableTimeSlotById), new { id = slot.Id },
                    ApiResponse<AvailableTimeSlotResponseDto>.SuccessResponse(slot, "Time slot created successfully"));
            }
            catch (InvalidOperationException ex)
            {
                return BadRequest(ApiResponse<AvailableTimeSlotResponseDto>.ErrorResponse(ex.Message));
            }
            catch (Exception ex)
            {
                return StatusCode(500, ApiResponse<AvailableTimeSlotResponseDto>.ErrorResponse("An error occurred while creating time slot", new List<string> { ex.Message }));
            }
        }

        [RequirePermission("UpdateAvailableTimeSlots")]
        [HttpPut("{id}")]
        public async Task<ActionResult<ApiResponse<AvailableTimeSlotResponseDto>>> UpdateAvailableTimeSlot(int id, [FromBody] UpdateAvailableTimeSlotDto dto)
        {
            try
            {
                var currentUserId = HttpContext.GetCurrentUserId();
                var slot = await _availableTimeSlotService.UpdateAvailableTimeSlotAsync(id, dto, currentUserId);
                if (slot == null)
                {
                    return NotFound(ApiResponse<AvailableTimeSlotResponseDto>.ErrorResponse("Time slot not found"));
                }

                return Ok(ApiResponse<AvailableTimeSlotResponseDto>.SuccessResponse(slot, "Time slot updated successfully"));
            }
            catch (InvalidOperationException ex)
            {
                return BadRequest(ApiResponse<AvailableTimeSlotResponseDto>.ErrorResponse(ex.Message));
            }
            catch (Exception ex)
            {
                return StatusCode(500, ApiResponse<AvailableTimeSlotResponseDto>.ErrorResponse("An error occurred while updating time slot", new List<string> { ex.Message }));
            }
        }

        [RequirePermission("DeleteAvailableTimeSlots")]
        [HttpDelete("{id}")]
        public async Task<ActionResult<ApiResponse<object>>> DeleteAvailableTimeSlot(int id)
        {
            try
            {
                var currentUserId = HttpContext.GetCurrentUserId();
                var result = await _availableTimeSlotService.DeleteAvailableTimeSlotAsync(id, currentUserId);
                if (!result)
                {
                    return NotFound(ApiResponse<object>.ErrorResponse("Time slot not found"));
                }

                return Ok(ApiResponse<object>.SuccessResponse(null, "Time slot deleted successfully"));
            }
            catch (Exception ex)
            {
                return StatusCode(500, ApiResponse<object>.ErrorResponse("An error occurred while deleting time slot", new List<string> { ex.Message }));
            }
        }

        [RequirePermission("RestoreAvailableTimeSlots")]
        [HttpPut("{id}/restore")]
        public async Task<ActionResult<ApiResponse<object>>> RestoreAvailableTimeSlot(int id)
        {
            try
            {
                var currentUserId = HttpContext.GetCurrentUserId();
                var result = await _availableTimeSlotService.RestoreAvailableTimeSlotAsync(id, currentUserId);
                if (!result)
                {
                    return NotFound(ApiResponse<object>.ErrorResponse("Time slot not found in archive"));
                }

                return Ok(ApiResponse<object>.SuccessResponse(null, "Time slot restored successfully"));
            }
            catch (Exception ex)
            {
                return StatusCode(500, ApiResponse<object>.ErrorResponse("An error occurred while restoring time slot", new List<string> { ex.Message }));
            }
        }

        [RequirePermission("PermanentDeleteAvailableTimeSlots")]
        [HttpDelete("{id}/permanent")]
        public async Task<ActionResult<ApiResponse<object>>> PermanentDeleteAvailableTimeSlot(int id)
        {
            try
            {
                var currentUserId = HttpContext.GetCurrentUserId();
                var result = await _availableTimeSlotService.PermanentDeleteAvailableTimeSlotAsync(id, currentUserId);
                if (!result)
                {
                    return NotFound(ApiResponse<object>.ErrorResponse("Time slot not found in archive"));
                }

                return Ok(ApiResponse<object>.SuccessResponse(null, "Time slot permanently deleted"));
            }
            catch (Exception ex)
            {
                return StatusCode(500, ApiResponse<object>.ErrorResponse("An error occurred while permanently deleting time slot", new List<string> { ex.Message }));
            }
        }
    }
}
