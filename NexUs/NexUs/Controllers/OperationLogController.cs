using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using NexUs.Attributes;
using NexUs.Models.DTO.Common;
using NexUs.Models.DTO.OperationLogs;
using NexUs.Services.Interfaces;

namespace NexUs.Controllers
{
    [Route("api/operation-log")]
    [ApiController]
    [Authorize]
    public class OperationLogController : ControllerBase
    {
        private readonly IOperationLogService _operationLogService;

        public OperationLogController(IOperationLogService operationLogService)
        {
            _operationLogService = operationLogService;
        }

        [RequirePermission("ViewOperationLogs")]
        [HttpGet]
        public async Task<ActionResult<ApiResponse<PagedResultDto<OperationLogListDto>>>> GetAllLogs([FromQuery] OperationLogPaginationDto pagination)
        {
            try
            {
                var result = await _operationLogService.GetAllLogsAsync(pagination);
                return Ok(ApiResponse<PagedResultDto<OperationLogListDto>>.SuccessResponse(result, "Operation logs retrieved successfully"));
            }
            catch (Exception ex)
            {
                return StatusCode(500, ApiResponse<PagedResultDto<OperationLogListDto>>.ErrorResponse("An error occurred while retrieving operation logs", new List<string> { ex.Message }));
            }
        }

        [RequirePermission("ViewOperationLogs")]
        [HttpGet("{id}")]
        public async Task<ActionResult<ApiResponse<OperationLogDetailDto>>> GetLogById(int id)
        {
            try
            {
                var log = await _operationLogService.GetLogByIdAsync(id);
                if (log == null)
                {
                    return NotFound(ApiResponse<OperationLogDetailDto>.ErrorResponse("Operation log not found"));
                }

                return Ok(ApiResponse<OperationLogDetailDto>.SuccessResponse(log, "Operation log retrieved successfully"));
            }
            catch (Exception ex)
            {
                return StatusCode(500, ApiResponse<OperationLogDetailDto>.ErrorResponse("An error occurred while retrieving operation log", new List<string> { ex.Message }));
            }
        }
    }
}
