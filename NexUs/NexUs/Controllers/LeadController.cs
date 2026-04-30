using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using NexUs.Attributes;
using NexUs.Extensions;
using NexUs.Models.DTO.Common;
using NexUs.Models.DTO.Marketing;
using NexUs.Services.Interfaces;

namespace NexUs.Controllers
{
    [Route("api/lead")]
    [ApiController]
    [Authorize]
    public class LeadController : ControllerBase
    {
        private readonly ILeadService _service;
        public LeadController(ILeadService service) => _service = service;

        [RequirePermission("ViewLeads")]
        [HttpGet]
        public async Task<ActionResult<ApiResponse<PagedResultDto<LeadListDto>>>> GetAll([FromQuery] PaginationDto pagination, [FromQuery] string? status = null)
        {
            try { return Ok(ApiResponse<PagedResultDto<LeadListDto>>.SuccessResponse(await _service.GetAllAsync(pagination, status), "Leads retrieved")); }
            catch (Exception) { return StatusCode(500, ApiResponse<PagedResultDto<LeadListDto>>.ErrorResponse("Error")); }
        }

        [RequirePermission("ArchiveLeads")]
        [HttpGet("archive")]
        public async Task<ActionResult<ApiResponse<PagedResultDto<LeadListDto>>>> GetArchived([FromQuery] PaginationDto pagination)
        {
            try { return Ok(ApiResponse<PagedResultDto<LeadListDto>>.SuccessResponse(await _service.GetArchivedAsync(pagination), "Archived leads retrieved")); }
            catch (Exception) { return StatusCode(500, ApiResponse<PagedResultDto<LeadListDto>>.ErrorResponse("Error")); }
        }

        [RequirePermission("ViewLeads")]
        [HttpGet("{id:int}")]
        public async Task<ActionResult<ApiResponse<LeadResponseDto>>> GetById(int id)
        {
            try
            {
                var result = await _service.GetByIdAsync(id);
                if (result == null) return NotFound(ApiResponse<LeadResponseDto>.ErrorResponse("Lead not found"));
                return Ok(ApiResponse<LeadResponseDto>.SuccessResponse(result, "Lead retrieved"));
            }
            catch (Exception) { return StatusCode(500, ApiResponse<LeadResponseDto>.ErrorResponse("Error")); }
        }

        [RequirePermission("CreateLeads")]
        [HttpPost]
        public async Task<ActionResult<ApiResponse<LeadResponseDto>>> Create([FromBody] CreateLeadDto dto)
        {
            try
            {
                var userId = HttpContext.GetCurrentUserId();
                var result = await _service.CreateAsync(dto, userId);
                return CreatedAtAction(nameof(GetById), new { id = result.Id }, ApiResponse<LeadResponseDto>.SuccessResponse(result, "Lead created"));
            }
            catch (InvalidOperationException ex) { return BadRequest(ApiResponse<LeadResponseDto>.ErrorResponse(ex.Message)); }
            catch (Exception) { return StatusCode(500, ApiResponse<LeadResponseDto>.ErrorResponse("Error")); }
        }

        [RequirePermission("UpdateLeads")]
        [HttpPut("{id:int}")]
        public async Task<ActionResult<ApiResponse<LeadResponseDto>>> Update(int id, [FromBody] UpdateLeadDto dto)
        {
            try
            {
                var userId = HttpContext.GetCurrentUserId();
                var result = await _service.UpdateAsync(id, dto, userId);
                if (result == null) return NotFound(ApiResponse<LeadResponseDto>.ErrorResponse("Lead not found"));
                return Ok(ApiResponse<LeadResponseDto>.SuccessResponse(result, "Lead updated"));
            }
            catch (Exception) { return StatusCode(500, ApiResponse<LeadResponseDto>.ErrorResponse("Error")); }
        }

        [RequirePermission("DeleteLeads")]
        [HttpDelete("{id:int}")]
        public async Task<ActionResult<ApiResponse<bool>>> Delete(int id)
        {
            try
            {
                var userId = HttpContext.GetCurrentUserId();
                if (!await _service.DeleteAsync(id, userId)) return NotFound(ApiResponse<bool>.ErrorResponse("Lead not found"));
                return Ok(ApiResponse<bool>.SuccessResponse(true, "Lead archived"));
            }
            catch (Exception) { return StatusCode(500, ApiResponse<bool>.ErrorResponse("Error")); }
        }

        [RequirePermission("RestoreLeads")]
        [HttpPut("{id:int}/restore")]
        public async Task<ActionResult<ApiResponse<bool>>> Restore(int id)
        {
            try
            {
                var userId = HttpContext.GetCurrentUserId();
                if (!await _service.RestoreAsync(id, userId)) return NotFound(ApiResponse<bool>.ErrorResponse("Lead not found"));
                return Ok(ApiResponse<bool>.SuccessResponse(true, "Lead restored"));
            }
            catch (Exception) { return StatusCode(500, ApiResponse<bool>.ErrorResponse("Error")); }
        }

        [RequirePermission("PermanentDeleteLeads")]
        [HttpDelete("{id:int}/permanent")]
        public async Task<ActionResult<ApiResponse<bool>>> PermanentDelete(int id)
        {
            try
            {
                if (!await _service.PermanentDeleteAsync(id)) return NotFound(ApiResponse<bool>.ErrorResponse("Lead not found"));
                return Ok(ApiResponse<bool>.SuccessResponse(true, "Lead permanently deleted"));
            }
            catch (Exception) { return StatusCode(500, ApiResponse<bool>.ErrorResponse("Error")); }
        }
    }
}
