using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using NexUs.Attributes;
using NexUs.Extensions;
using NexUs.Models.DTO.Common;
using NexUs.Models.DTO.Marketing;
using NexUs.Services.Interfaces;

namespace NexUs.Controllers
{
    [Route("api/email-template")]
    [ApiController]
    [Authorize]
    public class EmailTemplateController : ControllerBase
    {
        private readonly IEmailTemplateService _service;
        public EmailTemplateController(IEmailTemplateService service) => _service = service;

        [RequirePermission("ViewEmailTemplates")]
        [HttpGet]
        public async Task<ActionResult<ApiResponse<PagedResultDto<EmailTemplateListDto>>>> GetAll([FromQuery] PaginationDto pagination)
        {
            try { var result = await _service.GetAllAsync(pagination); return Ok(ApiResponse<PagedResultDto<EmailTemplateListDto>>.SuccessResponse(result, "Templates retrieved")); }
            catch (Exception) { return StatusCode(500, ApiResponse<PagedResultDto<EmailTemplateListDto>>.ErrorResponse("Error retrieving templates")); }
        }

        [RequirePermission("ArchiveEmailTemplates")]
        [HttpGet("archive")]
        public async Task<ActionResult<ApiResponse<PagedResultDto<EmailTemplateListDto>>>> GetArchived([FromQuery] PaginationDto pagination)
        {
            try { var result = await _service.GetArchivedAsync(pagination); return Ok(ApiResponse<PagedResultDto<EmailTemplateListDto>>.SuccessResponse(result, "Archived templates retrieved")); }
            catch (Exception) { return StatusCode(500, ApiResponse<PagedResultDto<EmailTemplateListDto>>.ErrorResponse("Error")); }
        }

        [RequirePermission("ViewEmailTemplates")]
        [HttpGet("{id:int}")]
        public async Task<ActionResult<ApiResponse<EmailTemplateResponseDto>>> GetById(int id)
        {
            try
            {
                var result = await _service.GetByIdAsync(id);
                if (result == null) return NotFound(ApiResponse<EmailTemplateResponseDto>.ErrorResponse("Template not found"));
                return Ok(ApiResponse<EmailTemplateResponseDto>.SuccessResponse(result, "Template retrieved"));
            }
            catch (Exception) { return StatusCode(500, ApiResponse<EmailTemplateResponseDto>.ErrorResponse("Error")); }
        }

        [RequirePermission("CreateEmailTemplates")]
        [HttpPost]
        public async Task<ActionResult<ApiResponse<EmailTemplateResponseDto>>> Create([FromBody] CreateEmailTemplateDto dto)
        {
            try
            {
                var userId = HttpContext.GetCurrentUserId();
                var result = await _service.CreateAsync(dto, userId);
                return CreatedAtAction(nameof(GetById), new { id = result.Id }, ApiResponse<EmailTemplateResponseDto>.SuccessResponse(result, "Template created"));
            }
            catch (InvalidOperationException ex) { return BadRequest(ApiResponse<EmailTemplateResponseDto>.ErrorResponse(ex.Message)); }
            catch (Exception) { return StatusCode(500, ApiResponse<EmailTemplateResponseDto>.ErrorResponse("Error creating template")); }
        }

        [RequirePermission("UpdateEmailTemplates")]
        [HttpPut("{id:int}")]
        public async Task<ActionResult<ApiResponse<EmailTemplateResponseDto>>> Update(int id, [FromBody] UpdateEmailTemplateDto dto)
        {
            try
            {
                var userId = HttpContext.GetCurrentUserId();
                var result = await _service.UpdateAsync(id, dto, userId);
                if (result == null) return NotFound(ApiResponse<EmailTemplateResponseDto>.ErrorResponse("Template not found"));
                return Ok(ApiResponse<EmailTemplateResponseDto>.SuccessResponse(result, "Template updated"));
            }
            catch (Exception) { return StatusCode(500, ApiResponse<EmailTemplateResponseDto>.ErrorResponse("Error")); }
        }

        [RequirePermission("DeleteEmailTemplates")]
        [HttpDelete("{id:int}")]
        public async Task<ActionResult<ApiResponse<bool>>> Delete(int id)
        {
            try
            {
                var userId = HttpContext.GetCurrentUserId();
                var result = await _service.DeleteAsync(id, userId);
                if (!result) return NotFound(ApiResponse<bool>.ErrorResponse("Template not found"));
                return Ok(ApiResponse<bool>.SuccessResponse(true, "Template archived"));
            }
            catch (Exception) { return StatusCode(500, ApiResponse<bool>.ErrorResponse("Error")); }
        }

        [RequirePermission("RestoreEmailTemplates")]
        [HttpPut("{id:int}/restore")]
        public async Task<ActionResult<ApiResponse<bool>>> Restore(int id)
        {
            try
            {
                var userId = HttpContext.GetCurrentUserId();
                var result = await _service.RestoreAsync(id, userId);
                if (!result) return NotFound(ApiResponse<bool>.ErrorResponse("Template not found"));
                return Ok(ApiResponse<bool>.SuccessResponse(true, "Template restored"));
            }
            catch (Exception) { return StatusCode(500, ApiResponse<bool>.ErrorResponse("Error")); }
        }

        [RequirePermission("PermanentDeleteEmailTemplates")]
        [HttpDelete("{id:int}/permanent")]
        public async Task<ActionResult<ApiResponse<bool>>> PermanentDelete(int id)
        {
            try
            {
                var result = await _service.PermanentDeleteAsync(id);
                if (!result) return NotFound(ApiResponse<bool>.ErrorResponse("Template not found"));
                return Ok(ApiResponse<bool>.SuccessResponse(true, "Template permanently deleted"));
            }
            catch (Exception) { return StatusCode(500, ApiResponse<bool>.ErrorResponse("Error")); }
        }
    }
}
