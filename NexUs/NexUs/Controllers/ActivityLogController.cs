using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using NexUs.Models.DTO.ActivityLogs;
using NexUs.Models.DTO.Common;
using NexUs.Services.Interfaces;
using System.Security.Claims;

namespace NexUs.Controllers
{
    [Route("api/activity-log")]
    [ApiController]
    [Authorize]
    public class ActivityLogController : ControllerBase
    {
        private readonly IAuditService _auditService;

        public ActivityLogController(IAuditService auditService)
        {
            _auditService = auditService;
        }

        /// <summary>
        /// Get current user's activity logs with pagination, search, and filters
        /// </summary>
        [HttpGet]
        public async Task<ActionResult<ApiResponse<PagedResultDto<ActivityLogListDto>>>> GetMyLogs([FromQuery] ActivityLogPaginationDto pagination)
        {
            try
            {
                var userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value
                          ?? User.FindFirst("userId")?.Value;
                var parsedUserId = int.TryParse(userId, out var id) ? id : 0;

                if (parsedUserId == 0)
                {
                    return Unauthorized(ApiResponse<PagedResultDto<ActivityLogListDto>>.ErrorResponse("User not authenticated"));
                }

                var result = await _auditService.GetUserLogsAsync(parsedUserId, pagination);
                return Ok(ApiResponse<PagedResultDto<ActivityLogListDto>>.SuccessResponse(result, "Activity logs retrieved successfully"));
            }
            catch (Exception ex)
            {
                return StatusCode(500, ApiResponse<PagedResultDto<ActivityLogListDto>>.ErrorResponse("An error occurred while retrieving activity logs", new List<string> { ex.Message }));
            }
        }

        /// <summary>
        /// Get a single activity log by ID (only if it belongs to current user)
        /// </summary>
        [HttpGet("{id}")]
        public async Task<ActionResult<ApiResponse<ActivityLogDetailDto>>> GetLogById(int id)
        {
            try
            {
                var userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value
                          ?? User.FindFirst("userId")?.Value;
                var parsedUserId = int.TryParse(userId, out var uid) ? uid : 0;

                if (parsedUserId == 0)
                {
                    return Unauthorized(ApiResponse<ActivityLogDetailDto>.ErrorResponse("User not authenticated"));
                }

                var log = await _auditService.GetUserLogByIdAsync(parsedUserId, id);
                if (log == null)
                {
                    return NotFound(ApiResponse<ActivityLogDetailDto>.ErrorResponse("Activity log not found"));
                }

                return Ok(ApiResponse<ActivityLogDetailDto>.SuccessResponse(log, "Activity log retrieved successfully"));
            }
            catch (Exception ex)
            {
                return StatusCode(500, ApiResponse<ActivityLogDetailDto>.ErrorResponse("An error occurred while retrieving activity log", new List<string> { ex.Message }));
            }
        }
    }
}
