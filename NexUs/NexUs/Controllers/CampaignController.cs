using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using NexUs.Attributes;
using NexUs.Extensions;
using NexUs.Models.DTO.Common;
using NexUs.Models.DTO.Marketing;
using NexUs.Services.Interfaces;

namespace NexUs.Controllers
{
    [Route("api/campaign")]
    [ApiController]
    [Authorize]
    public class CampaignController : ControllerBase
    {
        private readonly ICampaignService _service;
        public CampaignController(ICampaignService service) => _service = service;

        [RequirePermission("ViewCampaigns")]
        [HttpGet]
        public async Task<ActionResult<ApiResponse<PagedResultDto<CampaignListDto>>>> GetAll([FromQuery] PaginationDto pagination, [FromQuery] string? status = null)
        {
            try { return Ok(ApiResponse<PagedResultDto<CampaignListDto>>.SuccessResponse(await _service.GetAllAsync(pagination, status), "Campaigns retrieved")); }
            catch (Exception) { return StatusCode(500, ApiResponse<PagedResultDto<CampaignListDto>>.ErrorResponse("Error")); }
        }

        [RequirePermission("ArchiveCampaigns")]
        [HttpGet("archive")]
        public async Task<ActionResult<ApiResponse<PagedResultDto<CampaignListDto>>>> GetArchived([FromQuery] PaginationDto pagination)
        {
            try { return Ok(ApiResponse<PagedResultDto<CampaignListDto>>.SuccessResponse(await _service.GetArchivedAsync(pagination), "Archived campaigns retrieved")); }
            catch (Exception) { return StatusCode(500, ApiResponse<PagedResultDto<CampaignListDto>>.ErrorResponse("Error")); }
        }

        [RequirePermission("ViewCampaigns")]
        [HttpGet("{id:int}")]
        public async Task<ActionResult<ApiResponse<CampaignResponseDto>>> GetById(int id)
        {
            try
            {
                var result = await _service.GetByIdAsync(id);
                if (result == null) return NotFound(ApiResponse<CampaignResponseDto>.ErrorResponse("Campaign not found"));
                return Ok(ApiResponse<CampaignResponseDto>.SuccessResponse(result, "Campaign retrieved"));
            }
            catch (Exception) { return StatusCode(500, ApiResponse<CampaignResponseDto>.ErrorResponse("Error")); }
        }

        [RequirePermission("CreateCampaigns")]
        [HttpPost]
        public async Task<ActionResult<ApiResponse<CampaignResponseDto>>> Create([FromBody] CreateCampaignDto dto)
        {
            try
            {
                var userId = HttpContext.GetCurrentUserId();
                var result = await _service.CreateAsync(dto, userId);
                return CreatedAtAction(nameof(GetById), new { id = result.Id }, ApiResponse<CampaignResponseDto>.SuccessResponse(result, "Campaign created"));
            }
            catch (InvalidOperationException ex) { return BadRequest(ApiResponse<CampaignResponseDto>.ErrorResponse(ex.Message)); }
            catch (Exception) { return StatusCode(500, ApiResponse<CampaignResponseDto>.ErrorResponse("Error")); }
        }

        [RequirePermission("UpdateCampaigns")]
        [HttpPut("{id:int}")]
        public async Task<ActionResult<ApiResponse<CampaignResponseDto>>> Update(int id, [FromBody] UpdateCampaignDto dto)
        {
            try
            {
                var userId = HttpContext.GetCurrentUserId();
                var result = await _service.UpdateAsync(id, dto, userId);
                if (result == null) return NotFound(ApiResponse<CampaignResponseDto>.ErrorResponse("Campaign not found"));
                return Ok(ApiResponse<CampaignResponseDto>.SuccessResponse(result, "Campaign updated"));
            }
            catch (InvalidOperationException ex) { return BadRequest(ApiResponse<CampaignResponseDto>.ErrorResponse(ex.Message)); }
            catch (Exception) { return StatusCode(500, ApiResponse<CampaignResponseDto>.ErrorResponse("Error")); }
        }

        [RequirePermission("DeleteCampaigns")]
        [HttpDelete("{id:int}")]
        public async Task<ActionResult<ApiResponse<bool>>> Delete(int id)
        {
            try
            {
                var userId = HttpContext.GetCurrentUserId();
                if (!await _service.DeleteAsync(id, userId)) return NotFound(ApiResponse<bool>.ErrorResponse("Campaign not found"));
                return Ok(ApiResponse<bool>.SuccessResponse(true, "Campaign archived"));
            }
            catch (Exception) { return StatusCode(500, ApiResponse<bool>.ErrorResponse("Error")); }
        }

        [RequirePermission("RestoreCampaigns")]
        [HttpPut("{id:int}/restore")]
        public async Task<ActionResult<ApiResponse<bool>>> Restore(int id)
        {
            try
            {
                var userId = HttpContext.GetCurrentUserId();
                if (!await _service.RestoreAsync(id, userId)) return NotFound(ApiResponse<bool>.ErrorResponse("Campaign not found"));
                return Ok(ApiResponse<bool>.SuccessResponse(true, "Campaign restored"));
            }
            catch (Exception) { return StatusCode(500, ApiResponse<bool>.ErrorResponse("Error")); }
        }

        [RequirePermission("PermanentDeleteCampaigns")]
        [HttpDelete("{id:int}/permanent")]
        public async Task<ActionResult<ApiResponse<bool>>> PermanentDelete(int id)
        {
            try
            {
                if (!await _service.PermanentDeleteAsync(id)) return NotFound(ApiResponse<bool>.ErrorResponse("Campaign not found"));
                return Ok(ApiResponse<bool>.SuccessResponse(true, "Campaign permanently deleted"));
            }
            catch (Exception) { return StatusCode(500, ApiResponse<bool>.ErrorResponse("Error")); }
        }

        [RequirePermission("UpdateCampaigns")]
        [HttpPost("{id:int}/build-targets")]
        public async Task<ActionResult<ApiResponse<BuildTargetsResultDto>>> BuildTargets(int id)
        {
            try
            {
                var userId = HttpContext.GetCurrentUserId();
                var result = await _service.BuildTargetsAsync(id, userId);
                return Ok(ApiResponse<BuildTargetsResultDto>.SuccessResponse(result, "Targets built successfully"));
            }
            catch (KeyNotFoundException ex) { return NotFound(ApiResponse<BuildTargetsResultDto>.ErrorResponse(ex.Message)); }
            catch (Exception) { return StatusCode(500, ApiResponse<BuildTargetsResultDto>.ErrorResponse("Error building targets")); }
        }

        [RequirePermission("SendCampaigns")]
        [HttpPost("{id:int}/send")]
        public async Task<ActionResult<ApiResponse<bool>>> Send(int id)
        {
            try
            {
                var userId = HttpContext.GetCurrentUserId();
                if (!await _service.SendAsync(id, userId)) return NotFound(ApiResponse<bool>.ErrorResponse("Campaign not found"));
                return Ok(ApiResponse<bool>.SuccessResponse(true, "Campaign queued for sending"));
            }
            catch (Exception) { return StatusCode(500, ApiResponse<bool>.ErrorResponse("Error")); }
        }

        [RequirePermission("UpdateCampaigns")]
        [HttpPost("{id:int}/schedule")]
        public async Task<ActionResult<ApiResponse<bool>>> Schedule(int id, [FromBody] ScheduleCampaignDto dto)
        {
            try
            {
                var userId = HttpContext.GetCurrentUserId();
                if (!await _service.ScheduleAsync(id, dto, userId)) return NotFound(ApiResponse<bool>.ErrorResponse("Campaign not found"));
                return Ok(ApiResponse<bool>.SuccessResponse(true, "Campaign scheduled"));
            }
            catch (Exception) { return StatusCode(500, ApiResponse<bool>.ErrorResponse("Error")); }
        }

        [RequirePermission("UpdateCampaigns")]
        [HttpPost("{id:int}/cancel")]
        public async Task<ActionResult<ApiResponse<bool>>> Cancel(int id)
        {
            try
            {
                var userId = HttpContext.GetCurrentUserId();
                if (!await _service.CancelAsync(id, userId)) return NotFound(ApiResponse<bool>.ErrorResponse("Campaign not found"));
                return Ok(ApiResponse<bool>.SuccessResponse(true, "Campaign cancelled"));
            }
            catch (Exception) { return StatusCode(500, ApiResponse<bool>.ErrorResponse("Error")); }
        }

        [RequirePermission("ViewCampaigns")]
        [HttpGet("{id:int}/targets")]
        public async Task<ActionResult<ApiResponse<PagedResultDto<CampaignTargetListDto>>>> GetTargets(int id, [FromQuery] PaginationDto pagination)
        {
            try { return Ok(ApiResponse<PagedResultDto<CampaignTargetListDto>>.SuccessResponse(await _service.GetTargetsAsync(id, pagination), "Targets retrieved")); }
            catch (Exception) { return StatusCode(500, ApiResponse<PagedResultDto<CampaignTargetListDto>>.ErrorResponse("Error")); }
        }

        [RequirePermission("ViewCampaigns")]
        [HttpGet("{id:int}/messages")]
        public async Task<ActionResult<ApiResponse<PagedResultDto<EmailMessageListDto>>>> GetMessages(int id, [FromQuery] PaginationDto pagination, [FromServices] IEmailMessageService messageService)
        {
            try { return Ok(ApiResponse<PagedResultDto<EmailMessageListDto>>.SuccessResponse(await messageService.GetAllAsync(pagination, null, id), "Messages retrieved")); }
            catch (Exception) { return StatusCode(500, ApiResponse<PagedResultDto<EmailMessageListDto>>.ErrorResponse("Error")); }
        }
    }
}
