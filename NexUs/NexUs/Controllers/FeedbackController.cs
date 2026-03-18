using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using NexUs.Extensions;
using NexUs.Models.DTO.Common;
using NexUs.Models.DTO.Feedbacks;
using NexUs.Services.Interfaces;

namespace NexUs.Controllers
{
    [Route("api/feedback")]
    [ApiController]
    [Authorize]
    public class FeedbackController : ControllerBase
    {
        private readonly IFeedbackService _service;

        public FeedbackController(IFeedbackService service)
        {
            _service = service;
        }

        /// <summary>
        /// Get all feedback (admin view) or current user's feedback
        /// </summary>
        [HttpGet]
        public async Task<ActionResult<ApiResponse<PagedResultDto<FeedbackListDto>>>> GetAll([FromQuery] PaginationDto pagination)
        {
            try
            {
                var isAdmin = User.IsInRole("Super Admin") || User.IsInRole("Admin");
                if (isAdmin)
                {
                    var result = await _service.GetAllAsync(pagination);
                    return Ok(ApiResponse<PagedResultDto<FeedbackListDto>>.SuccessResponse(result, "Feedback retrieved"));
                }
                else
                {
                    var userId = HttpContext.GetCurrentUserId();
                    if (userId == null) return Unauthorized(ApiResponse<PagedResultDto<FeedbackListDto>>.ErrorResponse("User not authenticated"));
                    var result = await _service.GetByCustomerAsync(userId.Value, pagination);
                    return Ok(ApiResponse<PagedResultDto<FeedbackListDto>>.SuccessResponse(result, "Feedback retrieved"));
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, ApiResponse<PagedResultDto<FeedbackListDto>>.ErrorResponse("Error", new List<string> { ex.Message }));
            }
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult<ApiResponse<FeedbackResponseDto>>> GetById(int id)
        {
            try
            {
                var result = await _service.GetByIdAsync(id);
                if (result == null) return NotFound(ApiResponse<FeedbackResponseDto>.ErrorResponse("Feedback not found"));
                return Ok(ApiResponse<FeedbackResponseDto>.SuccessResponse(result, "Feedback retrieved"));
            }
            catch (Exception ex)
            {
                return StatusCode(500, ApiResponse<FeedbackResponseDto>.ErrorResponse("Error", new List<string> { ex.Message }));
            }
        }

        /// <summary>
        /// Check if current user can submit feedback for a session log
        /// </summary>
        [HttpGet("can-submit/{sessionLogId:int}")]
        public async Task<ActionResult<ApiResponse<bool>>> CanSubmit(int sessionLogId)
        {
            try
            {
                var userId = HttpContext.GetCurrentUserId();
                if (userId == null) return Unauthorized(ApiResponse<bool>.ErrorResponse("User not authenticated"));
                var canSubmit = await _service.CanSubmitFeedbackAsync(userId.Value, sessionLogId);
                return Ok(ApiResponse<bool>.SuccessResponse(canSubmit, canSubmit ? "You can submit feedback" : "Feedback not available"));
            }
            catch (Exception ex)
            {
                return StatusCode(500, ApiResponse<bool>.ErrorResponse("Error", new List<string> { ex.Message }));
            }
        }

        [HttpPost]
        public async Task<ActionResult<ApiResponse<FeedbackResponseDto>>> Create([FromBody] CreateFeedbackDto dto)
        {
            try
            {
                var userId = HttpContext.GetCurrentUserId();
                if (userId == null) return Unauthorized(ApiResponse<FeedbackResponseDto>.ErrorResponse("User not authenticated"));
                var result = await _service.CreateAsync(dto, userId.Value);
                return CreatedAtAction(nameof(GetById), new { id = result.Id },
                    ApiResponse<FeedbackResponseDto>.SuccessResponse(result, "Feedback submitted successfully"));
            }
            catch (InvalidOperationException ex)
            {
                return BadRequest(ApiResponse<FeedbackResponseDto>.ErrorResponse(ex.Message));
            }
            catch (Exception ex)
            {
                return StatusCode(500, ApiResponse<FeedbackResponseDto>.ErrorResponse("Error", new List<string> { ex.Message }));
            }
        }

        [HttpPut("{id:int}")]
        public async Task<ActionResult<ApiResponse<FeedbackResponseDto>>> Update(int id, [FromBody] UpdateFeedbackDto dto)
        {
            try
            {
                var userId = HttpContext.GetCurrentUserId();
                if (userId == null) return Unauthorized(ApiResponse<FeedbackResponseDto>.ErrorResponse("User not authenticated"));
                var result = await _service.UpdateAsync(id, dto, userId.Value);
                if (result == null) return NotFound(ApiResponse<FeedbackResponseDto>.ErrorResponse("Feedback not found"));
                return Ok(ApiResponse<FeedbackResponseDto>.SuccessResponse(result, "Feedback updated"));
            }
            catch (Exception ex)
            {
                return StatusCode(500, ApiResponse<FeedbackResponseDto>.ErrorResponse("Error", new List<string> { ex.Message }));
            }
        }

        [HttpDelete("{id:int}")]
        public async Task<ActionResult<ApiResponse<bool>>> Delete(int id)
        {
            try
            {
                var userId = HttpContext.GetCurrentUserId();
                if (userId == null) return Unauthorized(ApiResponse<bool>.ErrorResponse("User not authenticated"));
                var result = await _service.DeleteAsync(id, userId.Value);
                if (!result) return NotFound(ApiResponse<bool>.ErrorResponse("Feedback not found"));
                return Ok(ApiResponse<bool>.SuccessResponse(true, "Feedback deleted"));
            }
            catch (Exception ex)
            {
                return StatusCode(500, ApiResponse<bool>.ErrorResponse("Error", new List<string> { ex.Message }));
            }
        }
    }
}
