using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using NexUs.Attributes;
using NexUs.Extensions;
using NexUs.Models.DTO.Common;
using NexUs.Models.DTO.Marketing;
using NexUs.Services.Interfaces;

namespace NexUs.Controllers
{
    [Route("api/segment")]
    [ApiController]
    [Authorize]
    public class SegmentController : ControllerBase
    {
        private readonly ISegmentService _service;
        public SegmentController(ISegmentService service) => _service = service;

        [RequirePermission("ViewSegments")]
        [HttpGet]
        public async Task<ActionResult<ApiResponse<PagedResultDto<SegmentListDto>>>> GetAll([FromQuery] PaginationDto pagination)
        {
            try { return Ok(ApiResponse<PagedResultDto<SegmentListDto>>.SuccessResponse(await _service.GetAllAsync(pagination), "Segments retrieved")); }
            catch (Exception) { return StatusCode(500, ApiResponse<PagedResultDto<SegmentListDto>>.ErrorResponse("Error")); }
        }

        [RequirePermission("ArchiveSegments")]
        [HttpGet("archive")]
        public async Task<ActionResult<ApiResponse<PagedResultDto<SegmentListDto>>>> GetArchived([FromQuery] PaginationDto pagination)
        {
            try { return Ok(ApiResponse<PagedResultDto<SegmentListDto>>.SuccessResponse(await _service.GetArchivedAsync(pagination), "Archived segments retrieved")); }
            catch (Exception) { return StatusCode(500, ApiResponse<PagedResultDto<SegmentListDto>>.ErrorResponse("Error")); }
        }

        [RequirePermission("ViewSegments")]
        [HttpGet("{id:int}")]
        public async Task<ActionResult<ApiResponse<SegmentResponseDto>>> GetById(int id)
        {
            try
            {
                var result = await _service.GetByIdAsync(id);
                if (result == null) return NotFound(ApiResponse<SegmentResponseDto>.ErrorResponse("Segment not found"));
                return Ok(ApiResponse<SegmentResponseDto>.SuccessResponse(result, "Segment retrieved"));
            }
            catch (Exception) { return StatusCode(500, ApiResponse<SegmentResponseDto>.ErrorResponse("Error")); }
        }

        [RequirePermission("ViewSegments")]
        [HttpGet("{id:int}/preview")]
        public async Task<ActionResult<ApiResponse<SegmentPreviewDto>>> Preview(int id)
        {
            try { return Ok(ApiResponse<SegmentPreviewDto>.SuccessResponse(await _service.PreviewAsync(id), "Preview ready")); }
            catch (Exception) { return StatusCode(500, ApiResponse<SegmentPreviewDto>.ErrorResponse("Error")); }
        }

        [RequirePermission("ViewSegments")]
        [HttpGet("field-values")]
        public async Task<ActionResult<ApiResponse<List<string>>>> GetFieldValues([FromQuery] string field)
        {
            try { return Ok(ApiResponse<List<string>>.SuccessResponse(await _service.GetFieldValuesAsync(field), "Field values retrieved")); }
            catch (Exception) { return StatusCode(500, ApiResponse<List<string>>.ErrorResponse("Error")); }
        }

        [RequirePermission("CreateSegments")]
        [HttpPost]
        public async Task<ActionResult<ApiResponse<SegmentResponseDto>>> Create([FromBody] CreateSegmentDto dto)
        {
            try
            {
                var userId = HttpContext.GetCurrentUserId();
                var result = await _service.CreateAsync(dto, userId);
                return CreatedAtAction(nameof(GetById), new { id = result.Id }, ApiResponse<SegmentResponseDto>.SuccessResponse(result, "Segment created"));
            }
            catch (InvalidOperationException ex) { return BadRequest(ApiResponse<SegmentResponseDto>.ErrorResponse(ex.Message)); }
            catch (Exception) { return StatusCode(500, ApiResponse<SegmentResponseDto>.ErrorResponse("Error")); }
        }

        [RequirePermission("UpdateSegments")]
        [HttpPut("{id:int}")]
        public async Task<ActionResult<ApiResponse<SegmentResponseDto>>> Update(int id, [FromBody] UpdateSegmentDto dto)
        {
            try
            {
                var userId = HttpContext.GetCurrentUserId();
                var result = await _service.UpdateAsync(id, dto, userId);
                if (result == null) return NotFound(ApiResponse<SegmentResponseDto>.ErrorResponse("Segment not found"));
                return Ok(ApiResponse<SegmentResponseDto>.SuccessResponse(result, "Segment updated"));
            }
            catch (Exception) { return StatusCode(500, ApiResponse<SegmentResponseDto>.ErrorResponse("Error")); }
        }

        [RequirePermission("DeleteSegments")]
        [HttpDelete("{id:int}")]
        public async Task<ActionResult<ApiResponse<bool>>> Delete(int id)
        {
            try
            {
                var userId = HttpContext.GetCurrentUserId();
                var result = await _service.DeleteAsync(id, userId);
                if (!result) return NotFound(ApiResponse<bool>.ErrorResponse("Segment not found"));
                return Ok(ApiResponse<bool>.SuccessResponse(true, "Segment archived"));
            }
            catch (Exception) { return StatusCode(500, ApiResponse<bool>.ErrorResponse("Error")); }
        }

        [RequirePermission("RestoreSegments")]
        [HttpPut("{id:int}/restore")]
        public async Task<ActionResult<ApiResponse<bool>>> Restore(int id)
        {
            try
            {
                var userId = HttpContext.GetCurrentUserId();
                var result = await _service.RestoreAsync(id, userId);
                if (!result) return NotFound(ApiResponse<bool>.ErrorResponse("Segment not found"));
                return Ok(ApiResponse<bool>.SuccessResponse(true, "Segment restored"));
            }
            catch (Exception) { return StatusCode(500, ApiResponse<bool>.ErrorResponse("Error")); }
        }

        [RequirePermission("PermanentDeleteSegments")]
        [HttpDelete("{id:int}/permanent")]
        public async Task<ActionResult<ApiResponse<bool>>> PermanentDelete(int id)
        {
            try
            {
                var result = await _service.PermanentDeleteAsync(id);
                if (!result) return NotFound(ApiResponse<bool>.ErrorResponse("Segment not found"));
                return Ok(ApiResponse<bool>.SuccessResponse(true, "Segment permanently deleted"));
            }
            catch (Exception) { return StatusCode(500, ApiResponse<bool>.ErrorResponse("Error")); }
        }
    }
}
