using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using NexUs.Models.DTO.Common;
using NexUs.Models.DTO.OperationLogs;
using NexUs.Services.Interfaces;
using System.Security.Claims;

namespace NexUs.Controllers
{
    [Route("api/auth-log")]
    [ApiController]
    [Authorize]
    public class AuthenticationLogController : ControllerBase
    {
        private readonly IOperationLogService _operationLogService;

        public AuthenticationLogController(IOperationLogService operationLogService)
        {
            _operationLogService = operationLogService;
        }

        /// <summary>
        /// Get current user's authentication logs (login/logout) with pagination and filters
        /// </summary>
        [HttpGet]
        public async Task<ActionResult<ApiResponse<PagedResultDto<OperationLogListDto>>>> GetMyAuthLogs([FromQuery] OperationLogPaginationDto pagination)
        {
            try
            {
                var userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value
                          ?? User.FindFirst("userId")?.Value;
                var parsedUserId = int.TryParse(userId, out var id) ? id : 0;

                if (parsedUserId == 0)
                {
                    return Unauthorized(ApiResponse<PagedResultDto<OperationLogListDto>>.ErrorResponse("User not authenticated"));
                }

                var result = await _operationLogService.GetUserLogsAsync(parsedUserId, pagination);
                return Ok(ApiResponse<PagedResultDto<OperationLogListDto>>.SuccessResponse(result, "Authentication logs retrieved successfully"));
            }
            catch (Exception)
            {
                return StatusCode(500, ApiResponse<PagedResultDto<OperationLogListDto>>.ErrorResponse("An error occurred while retrieving authentication logs"));
            }
        }

        /// <summary>
        /// Get a single authentication log by ID (only if it belongs to current user)
        /// </summary>
        [HttpGet("{id}")]
        public async Task<ActionResult<ApiResponse<OperationLogDetailDto>>> GetLogById(int id)
        {
            try
            {
                var userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value
                          ?? User.FindFirst("userId")?.Value;
                var parsedUserId = int.TryParse(userId, out var uid) ? uid : 0;

                if (parsedUserId == 0)
                {
                    return Unauthorized(ApiResponse<OperationLogDetailDto>.ErrorResponse("User not authenticated"));
                }

                var log = await _operationLogService.GetUserLogByIdAsync(parsedUserId, id);
                if (log == null)
                {
                    return NotFound(ApiResponse<OperationLogDetailDto>.ErrorResponse("Authentication log not found"));
                }

                return Ok(ApiResponse<OperationLogDetailDto>.SuccessResponse(log, "Authentication log retrieved successfully"));
            }
            catch (Exception)
            {
                return StatusCode(500, ApiResponse<OperationLogDetailDto>.ErrorResponse("An error occurred while retrieving authentication log"));
            }
        }
    }
}
