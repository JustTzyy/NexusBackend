using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using NexUs.Attributes;
using NexUs.Models.DTO.Common;
using NexUs.Models.DTO.Marketing;
using NexUs.Services.Interfaces;

namespace NexUs.Controllers
{
    [Route("api/email-message")]
    [ApiController]
    [Authorize]
    public class EmailMessageController : ControllerBase
    {
        private readonly IEmailMessageService _service;
        public EmailMessageController(IEmailMessageService service) => _service = service;

        [RequirePermission("ViewEmailLogs")]
        [HttpGet]
        public async Task<ActionResult<ApiResponse<PagedResultDto<EmailMessageListDto>>>> GetAll([FromQuery] PaginationDto pagination, [FromQuery] string? status = null, [FromQuery] int? campaignId = null)
        {
            try { return Ok(ApiResponse<PagedResultDto<EmailMessageListDto>>.SuccessResponse(await _service.GetAllAsync(pagination, status, campaignId), "Messages retrieved")); }
            catch (Exception ex) { return StatusCode(500, ApiResponse<PagedResultDto<EmailMessageListDto>>.ErrorResponse("Error", new List<string> { ex.Message })); }
        }

        [RequirePermission("ViewEmailLogs")]
        [HttpGet("{id:int}")]
        public async Task<ActionResult<ApiResponse<EmailMessageResponseDto>>> GetById(int id)
        {
            try
            {
                var result = await _service.GetByIdAsync(id);
                if (result == null) return NotFound(ApiResponse<EmailMessageResponseDto>.ErrorResponse("Message not found"));
                return Ok(ApiResponse<EmailMessageResponseDto>.SuccessResponse(result, "Message retrieved"));
            }
            catch (Exception ex) { return StatusCode(500, ApiResponse<EmailMessageResponseDto>.ErrorResponse("Error", new List<string> { ex.Message })); }
        }

        [RequirePermission("ViewEmailLogs")]
        [HttpGet("{id:int}/events")]
        public async Task<ActionResult<ApiResponse<List<EmailEventDto>>>> GetEvents(int id)
        {
            try { return Ok(ApiResponse<List<EmailEventDto>>.SuccessResponse(await _service.GetEventsAsync(id), "Events retrieved")); }
            catch (Exception ex) { return StatusCode(500, ApiResponse<List<EmailEventDto>>.ErrorResponse("Error", new List<string> { ex.Message })); }
        }
    }
}
