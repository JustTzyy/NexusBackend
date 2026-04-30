using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using NexUs.Attributes;
using NexUs.Models.DTO.AuditLogs;
using NexUs.Models.DTO.Common;
using NexUs.Services.Interfaces;

namespace NexUs.Controllers
{
    [Route("api/audit-log")]
    [ApiController]
    [Authorize]
    public class AuditLogController : ControllerBase
    {
        private readonly IAuditService _auditService;

        public AuditLogController(IAuditService auditService)
        {
            _auditService = auditService;
        }

        /// <summary>
        /// Get all audit logs with pagination, search, and filters
        /// </summary>
        [RequirePermission("ViewAuditLogs")]
        [HttpGet]
        public async Task<ActionResult<ApiResponse<PagedResultDto<AuditLogListDto>>>> GetAllLogs([FromQuery] AuditLogPaginationDto pagination)
        {
            try
            {
                var result = await _auditService.GetAllLogsAsync(pagination);
                return Ok(ApiResponse<PagedResultDto<AuditLogListDto>>.SuccessResponse(result, "Audit logs retrieved successfully"));
            }
            catch (Exception)
            {
                return StatusCode(500, ApiResponse<PagedResultDto<AuditLogListDto>>.ErrorResponse("An error occurred while retrieving audit logs"));
            }
        }

        /// <summary>
        /// Get audit log by ID
        /// </summary>
        [RequirePermission("ViewAuditLogs")]
        [HttpGet("{id}")]
        public async Task<ActionResult<ApiResponse<AuditLogDetailDto>>> GetLogById(int id)
        {
            try
            {
                var log = await _auditService.GetLogByIdAsync(id);
                if (log == null)
                {
                    return NotFound(ApiResponse<AuditLogDetailDto>.ErrorResponse("Audit log not found"));
                }

                return Ok(ApiResponse<AuditLogDetailDto>.SuccessResponse(log, "Audit log retrieved successfully"));
            }
            catch (Exception)
            {
                return StatusCode(500, ApiResponse<AuditLogDetailDto>.ErrorResponse("An error occurred while retrieving audit log"));
            }
        }
    }
}
