using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using NexUs.Attributes;
using NexUs.Extensions;
using NexUs.Models.DTO.Common;
using NexUs.Models.DTO.SessionLogs;
using NexUs.Services.Interfaces;

namespace NexUs.Controllers
{
    [Route("api/session-log")]
    [ApiController]
    [Authorize]
    public class SessionLogController : ControllerBase
    {
        private readonly ISessionLogService _sessionLogService;

        public SessionLogController(ISessionLogService sessionLogService)
        {
            _sessionLogService = sessionLogService;
        }

        /// <summary>
        /// Get all session logs for a specific tutoring request
        /// </summary>
        [RequirePermission("ViewSessionLogs")]
        [HttpGet("by-request/{tutoringRequestId:int}")]
        public async Task<ActionResult<ApiResponse<List<SessionLogResponseDto>>>> GetByRequest(int tutoringRequestId)
        {
            try
            {
                var result = await _sessionLogService.GetByTutoringRequestAsync(tutoringRequestId);
                return Ok(ApiResponse<List<SessionLogResponseDto>>.SuccessResponse(result, "Session logs retrieved successfully"));
            }
            catch (Exception)
            {
                return StatusCode(500, ApiResponse<List<SessionLogResponseDto>>.ErrorResponse("An error occurred while retrieving session logs"));
            }
        }

        /// <summary>
        /// Get a single session log by ID
        /// </summary>
        [RequirePermission("ViewSessionLogs")]
        [HttpGet("{id:int}")]
        public async Task<ActionResult<ApiResponse<SessionLogResponseDto>>> GetById(int id)
        {
            try
            {
                var result = await _sessionLogService.GetByIdAsync(id);
                if (result == null)
                    return NotFound(ApiResponse<SessionLogResponseDto>.ErrorResponse("Session log not found"));

                return Ok(ApiResponse<SessionLogResponseDto>.SuccessResponse(result, "Session log retrieved successfully"));
            }
            catch (Exception)
            {
                return StatusCode(500, ApiResponse<SessionLogResponseDto>.ErrorResponse("An error occurred while retrieving session log"));
            }
        }

        /// <summary>
        /// Get all session logs (paginated)
        /// </summary>
        [RequirePermission("ViewSessionLogs")]
        [HttpGet]
        public async Task<ActionResult<ApiResponse<PagedResultDto<SessionLogResponseDto>>>> GetAll([FromQuery] PaginationDto pagination)
        {
            try
            {
                var result = await _sessionLogService.GetAllAsync(pagination);
                return Ok(ApiResponse<PagedResultDto<SessionLogResponseDto>>.SuccessResponse(result, "Session logs retrieved successfully"));
            }
            catch (Exception)
            {
                return StatusCode(500, ApiResponse<PagedResultDto<SessionLogResponseDto>>.ErrorResponse("An error occurred while retrieving session logs"));
            }
        }

        /// <summary>
        /// Create a new session log
        /// </summary>
        [RequirePermission("CreateSessionLogs")]
        [HttpPost]
        public async Task<ActionResult<ApiResponse<SessionLogResponseDto>>> Create([FromBody] CreateSessionLogDto dto)
        {
            try
            {
                var userId = HttpContext.GetCurrentUserId();
                var result = await _sessionLogService.CreateAsync(dto, userId);
                return CreatedAtAction(nameof(GetByRequest), new { tutoringRequestId = result.TutoringRequestId },
                    ApiResponse<SessionLogResponseDto>.SuccessResponse(result, "Session log created successfully"));
            }
            catch (InvalidOperationException ex)
            {
                return BadRequest(ApiResponse<SessionLogResponseDto>.ErrorResponse(ex.Message));
            }
            catch (Exception)
            {
                return StatusCode(500, ApiResponse<SessionLogResponseDto>.ErrorResponse("An error occurred while creating session log"));
            }
        }

        /// <summary>
        /// Update an existing session log
        /// </summary>
        [RequirePermission("UpdateSessionLogs")]
        [HttpPut("{id:int}")]
        public async Task<ActionResult<ApiResponse<SessionLogResponseDto>>> Update(int id, [FromBody] UpdateSessionLogDto dto)
        {
            try
            {
                var userId = HttpContext.GetCurrentUserId();
                var isAdmin = User.IsInRole("Super Admin") || User.IsInRole("Admin");
                var result = await _sessionLogService.UpdateAsync(id, dto, userId, isAdmin);
                if (result == null)
                    return NotFound(ApiResponse<SessionLogResponseDto>.ErrorResponse("Session log not found"));

                return Ok(ApiResponse<SessionLogResponseDto>.SuccessResponse(result, "Session log updated successfully"));
            }
            catch (UnauthorizedAccessException)
            {
                return StatusCode(403, ApiResponse<SessionLogResponseDto>.ErrorResponse("You do not have permission to update this session log."));
            }
            catch (Exception)
            {
                return StatusCode(500, ApiResponse<SessionLogResponseDto>.ErrorResponse("An error occurred while updating session log"));
            }
        }

        /// <summary>
        /// Soft delete a session log
        /// </summary>
        [RequirePermission("DeleteSessionLogs")]
        [HttpDelete("{id:int}")]
        public async Task<ActionResult<ApiResponse<object>>> Delete(int id)
        {
            try
            {
                var userId = HttpContext.GetCurrentUserId();
                var isAdmin = User.IsInRole("Super Admin") || User.IsInRole("Admin");
                var result = await _sessionLogService.DeleteAsync(id, userId, isAdmin);
                if (!result)
                    return NotFound(ApiResponse<object>.ErrorResponse("Session log not found"));

                return Ok(ApiResponse<object>.SuccessResponse(null, "Session log deleted successfully"));
            }
            catch (UnauthorizedAccessException)
            {
                return StatusCode(403, ApiResponse<object>.ErrorResponse("You do not have permission to delete this session log."));
            }
            catch (Exception)
            {
                return StatusCode(500, ApiResponse<object>.ErrorResponse("An error occurred while deleting session log"));
            }
        }
    }
}
