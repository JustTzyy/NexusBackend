using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using NexUs.Attributes;
using NexUs.Extensions;
using NexUs.Models.DTO.Common;
using NexUs.Models.DTO.Marketing;
using NexUs.Services.Interfaces;

namespace NexUs.Controllers
{
    [Route("api/automation-rule")]
    [ApiController]
    [Authorize]
    public class AutomationRuleController : ControllerBase
    {
        private readonly IAutomationService _service;
        public AutomationRuleController(IAutomationService service) => _service = service;

        [RequirePermission("ViewAutomationRules")]
        [HttpGet]
        public async Task<ActionResult<ApiResponse<PagedResultDto<AutomationRuleListDto>>>> GetAll([FromQuery] PaginationDto pagination)
        {
            try { return Ok(ApiResponse<PagedResultDto<AutomationRuleListDto>>.SuccessResponse(await _service.GetAllAsync(pagination), "Rules retrieved")); }
            catch (Exception ex) { return StatusCode(500, ApiResponse<PagedResultDto<AutomationRuleListDto>>.ErrorResponse("Error", new List<string> { ex.Message })); }
        }

        [RequirePermission("ViewAutomationRules")]
        [HttpGet("{id:int}")]
        public async Task<ActionResult<ApiResponse<AutomationRuleResponseDto>>> GetById(int id)
        {
            try
            {
                var result = await _service.GetByIdAsync(id);
                if (result == null) return NotFound(ApiResponse<AutomationRuleResponseDto>.ErrorResponse("Rule not found"));
                return Ok(ApiResponse<AutomationRuleResponseDto>.SuccessResponse(result, "Rule retrieved"));
            }
            catch (Exception ex) { return StatusCode(500, ApiResponse<AutomationRuleResponseDto>.ErrorResponse("Error", new List<string> { ex.Message })); }
        }

        [RequirePermission("CreateAutomationRules")]
        [HttpPost]
        public async Task<ActionResult<ApiResponse<AutomationRuleResponseDto>>> Create([FromBody] CreateAutomationRuleDto dto)
        {
            try
            {
                var userId = HttpContext.GetCurrentUserId();
                var result = await _service.CreateAsync(dto, userId);
                return CreatedAtAction(nameof(GetById), new { id = result.Id }, ApiResponse<AutomationRuleResponseDto>.SuccessResponse(result, "Rule created"));
            }
            catch (Exception ex) { return StatusCode(500, ApiResponse<AutomationRuleResponseDto>.ErrorResponse("Error", new List<string> { ex.Message })); }
        }

        [RequirePermission("UpdateAutomationRules")]
        [HttpPut("{id:int}")]
        public async Task<ActionResult<ApiResponse<AutomationRuleResponseDto>>> Update(int id, [FromBody] UpdateAutomationRuleDto dto)
        {
            try
            {
                var userId = HttpContext.GetCurrentUserId();
                var result = await _service.UpdateAsync(id, dto, userId);
                if (result == null) return NotFound(ApiResponse<AutomationRuleResponseDto>.ErrorResponse("Rule not found"));
                return Ok(ApiResponse<AutomationRuleResponseDto>.SuccessResponse(result, "Rule updated"));
            }
            catch (Exception ex) { return StatusCode(500, ApiResponse<AutomationRuleResponseDto>.ErrorResponse("Error", new List<string> { ex.Message })); }
        }

        [RequirePermission("DeleteAutomationRules")]
        [HttpDelete("{id:int}")]
        public async Task<ActionResult<ApiResponse<bool>>> Delete(int id)
        {
            try
            {
                var userId = HttpContext.GetCurrentUserId();
                if (!await _service.DeleteAsync(id, userId)) return NotFound(ApiResponse<bool>.ErrorResponse("Rule not found"));
                return Ok(ApiResponse<bool>.SuccessResponse(true, "Rule archived"));
            }
            catch (Exception ex) { return StatusCode(500, ApiResponse<bool>.ErrorResponse("Error", new List<string> { ex.Message })); }
        }

        [RequirePermission("ArchiveAutomationRules")]
        [HttpGet("archive")]
        public async Task<ActionResult<ApiResponse<PagedResultDto<AutomationRuleListDto>>>> GetArchived([FromQuery] PaginationDto pagination)
        {
            try { return Ok(ApiResponse<PagedResultDto<AutomationRuleListDto>>.SuccessResponse(await _service.GetArchivedAsync(pagination), "Archived rules retrieved")); }
            catch (Exception ex) { return StatusCode(500, ApiResponse<PagedResultDto<AutomationRuleListDto>>.ErrorResponse("Error", new List<string> { ex.Message })); }
        }

        [RequirePermission("RestoreAutomationRules")]
        [HttpPut("{id:int}/restore")]
        public async Task<ActionResult<ApiResponse<bool>>> Restore(int id)
        {
            try
            {
                var userId = HttpContext.GetCurrentUserId();
                if (!await _service.RestoreAsync(id, userId)) return NotFound(ApiResponse<bool>.ErrorResponse("Rule not found"));
                return Ok(ApiResponse<bool>.SuccessResponse(true, "Rule restored"));
            }
            catch (Exception ex) { return StatusCode(500, ApiResponse<bool>.ErrorResponse("Error", new List<string> { ex.Message })); }
        }

        [RequirePermission("PermanentDeleteAutomationRules")]
        [HttpDelete("{id:int}/permanent")]
        public async Task<ActionResult<ApiResponse<bool>>> PermanentDelete(int id)
        {
            try
            {
                if (!await _service.PermanentDeleteAsync(id)) return NotFound(ApiResponse<bool>.ErrorResponse("Rule not found"));
                return Ok(ApiResponse<bool>.SuccessResponse(true, "Rule permanently deleted"));
            }
            catch (Exception ex) { return StatusCode(500, ApiResponse<bool>.ErrorResponse("Error", new List<string> { ex.Message })); }
        }

        [RequirePermission("UpdateAutomationRules")]
        [HttpPut("{id:int}/activate")]
        public async Task<ActionResult<ApiResponse<bool>>> Activate(int id)
        {
            try
            {
                var userId = HttpContext.GetCurrentUserId();
                if (!await _service.ActivateAsync(id, userId)) return NotFound(ApiResponse<bool>.ErrorResponse("Rule not found"));
                return Ok(ApiResponse<bool>.SuccessResponse(true, "Rule activated"));
            }
            catch (Exception ex) { return StatusCode(500, ApiResponse<bool>.ErrorResponse("Error", new List<string> { ex.Message })); }
        }

        [RequirePermission("UpdateAutomationRules")]
        [HttpPut("{id:int}/deactivate")]
        public async Task<ActionResult<ApiResponse<bool>>> Deactivate(int id)
        {
            try
            {
                var userId = HttpContext.GetCurrentUserId();
                if (!await _service.DeactivateAsync(id, userId)) return NotFound(ApiResponse<bool>.ErrorResponse("Rule not found"));
                return Ok(ApiResponse<bool>.SuccessResponse(true, "Rule deactivated"));
            }
            catch (Exception ex) { return StatusCode(500, ApiResponse<bool>.ErrorResponse("Error", new List<string> { ex.Message })); }
        }

        [RequirePermission("UpdateAutomationRules")]
        [HttpPost("{id:int}/actions")]
        public async Task<ActionResult<ApiResponse<AutomationActionDto>>> AddAction(int id, [FromBody] CreateAutomationActionDto dto)
        {
            try
            {
                var userId = HttpContext.GetCurrentUserId();
                var result = await _service.AddActionAsync(id, dto, userId);
                return Ok(ApiResponse<AutomationActionDto>.SuccessResponse(result, "Action added"));
            }
            catch (Exception ex) { return StatusCode(500, ApiResponse<AutomationActionDto>.ErrorResponse("Error", new List<string> { ex.Message })); }
        }

        [RequirePermission("UpdateAutomationRules")]
        [HttpPut("{id:int}/actions/{actionId:int}")]
        public async Task<ActionResult<ApiResponse<AutomationActionDto>>> UpdateAction(int id, int actionId, [FromBody] CreateAutomationActionDto dto)
        {
            try
            {
                var userId = HttpContext.GetCurrentUserId();
                var result = await _service.UpdateActionAsync(id, actionId, dto, userId);
                if (result == null) return NotFound(ApiResponse<AutomationActionDto>.ErrorResponse("Action not found"));
                return Ok(ApiResponse<AutomationActionDto>.SuccessResponse(result, "Action updated"));
            }
            catch (Exception ex) { return StatusCode(500, ApiResponse<AutomationActionDto>.ErrorResponse("Error", new List<string> { ex.Message })); }
        }

        [RequirePermission("UpdateAutomationRules")]
        [HttpDelete("{id:int}/actions/{actionId:int}")]
        public async Task<ActionResult<ApiResponse<bool>>> DeleteAction(int id, int actionId)
        {
            try
            {
                if (!await _service.DeleteActionAsync(id, actionId)) return NotFound(ApiResponse<bool>.ErrorResponse("Action not found"));
                return Ok(ApiResponse<bool>.SuccessResponse(true, "Action deleted"));
            }
            catch (Exception ex) { return StatusCode(500, ApiResponse<bool>.ErrorResponse("Error", new List<string> { ex.Message })); }
        }
    }
}
