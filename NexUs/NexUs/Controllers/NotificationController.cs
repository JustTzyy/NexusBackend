using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using NexUs.Extensions;
using NexUs.Models.DTO.Common;
using NexUs.Models.DTO.Notifications;
using NexUs.Services.Interfaces;

namespace NexUs.Controllers
{
    [Route("api/notification")]
    [ApiController]
    [Authorize]
    public class NotificationController : ControllerBase
    {
        private readonly INotificationService _service;
        public NotificationController(INotificationService service) => _service = service;

        [HttpGet]
        public async Task<ActionResult<ApiResponse<PagedResultDto<NotificationListDto>>>> GetAll([FromQuery] PaginationDto pagination, [FromQuery] string? type = null)
        {
            try
            {
                // Always scoped to the current user's own notifications
                var currentUserId = HttpContext.GetCurrentUserId();
                return Ok(ApiResponse<PagedResultDto<NotificationListDto>>.SuccessResponse(await _service.GetAllAsync(pagination, currentUserId, type), "Notifications retrieved"));
            }
            catch (Exception ex) { return StatusCode(500, ApiResponse<PagedResultDto<NotificationListDto>>.ErrorResponse("Error", new List<string> { ex.Message })); }
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult<ApiResponse<NotificationResponseDto>>> GetById(int id)
        {
            try
            {
                var result = await _service.GetByIdAsync(id);
                if (result == null) return NotFound(ApiResponse<NotificationResponseDto>.ErrorResponse("Notification not found"));
                return Ok(ApiResponse<NotificationResponseDto>.SuccessResponse(result, "Notification retrieved"));
            }
            catch (Exception ex) { return StatusCode(500, ApiResponse<NotificationResponseDto>.ErrorResponse("Error", new List<string> { ex.Message })); }
        }

        [HttpGet("unread-count")]
        public async Task<ActionResult<ApiResponse<NotificationCountDto>>> GetUnreadCount()
        {
            try
            {
                var userId = HttpContext.GetCurrentUserId();
                if (userId == null) return Unauthorized(ApiResponse<NotificationCountDto>.ErrorResponse("User not authenticated"));
                return Ok(ApiResponse<NotificationCountDto>.SuccessResponse(await _service.GetUnreadCountAsync(userId.Value), "Unread count retrieved"));
            }
            catch (Exception ex) { return StatusCode(500, ApiResponse<NotificationCountDto>.ErrorResponse("Error", new List<string> { ex.Message })); }
        }

        [HttpPost]
        public async Task<ActionResult<ApiResponse<NotificationResponseDto>>> Create([FromBody] CreateNotificationDto dto)
        {
            try
            {
                var userId = HttpContext.GetCurrentUserId();
                var result = await _service.CreateAsync(dto, userId);
                return CreatedAtAction(nameof(GetById), new { id = result.Id }, ApiResponse<NotificationResponseDto>.SuccessResponse(result, "Notification created"));
            }
            catch (Exception ex) { return StatusCode(500, ApiResponse<NotificationResponseDto>.ErrorResponse("Error", new List<string> { ex.Message })); }
        }

        [HttpPut("{id:int}/read")]
        public async Task<ActionResult<ApiResponse<bool>>> MarkAsRead(int id)
        {
            try
            {
                if (!await _service.MarkAsReadAsync(id)) return NotFound(ApiResponse<bool>.ErrorResponse("Notification not found"));
                return Ok(ApiResponse<bool>.SuccessResponse(true, "Notification marked as read"));
            }
            catch (Exception ex) { return StatusCode(500, ApiResponse<bool>.ErrorResponse("Error", new List<string> { ex.Message })); }
        }

        [HttpPut("read-all")]
        public async Task<ActionResult<ApiResponse<int>>> MarkAllAsRead()
        {
            try
            {
                var userId = HttpContext.GetCurrentUserId();
                if (userId == null) return Unauthorized(ApiResponse<int>.ErrorResponse("User not authenticated"));
                var count = await _service.MarkAllAsReadAsync(userId.Value);
                return Ok(ApiResponse<int>.SuccessResponse(count, $"{count} notifications marked as read"));
            }
            catch (Exception ex) { return StatusCode(500, ApiResponse<int>.ErrorResponse("Error", new List<string> { ex.Message })); }
        }

        [HttpDelete("{id:int}")]
        public async Task<ActionResult<ApiResponse<bool>>> Delete(int id)
        {
            try
            {
                if (!await _service.DeleteAsync(id)) return NotFound(ApiResponse<bool>.ErrorResponse("Notification not found"));
                return Ok(ApiResponse<bool>.SuccessResponse(true, "Notification deleted"));
            }
            catch (Exception ex) { return StatusCode(500, ApiResponse<bool>.ErrorResponse("Error", new List<string> { ex.Message })); }
        }
    }
}
