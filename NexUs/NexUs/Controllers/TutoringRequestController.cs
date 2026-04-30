using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using NexUs.Attributes;
using NexUs.Extensions;
using NexUs.Models.DTO.Common;
using NexUs.Models.DTO.TeacherInterests;
using NexUs.Models.DTO.TutoringRequests;
using NexUs.Services.Interfaces;

namespace NexUs.Controllers
{
    [Route("api/tutoring-request")]
    [ApiController]
    [Authorize]
    public class TutoringRequestController : ControllerBase
    {
        private readonly ITutoringRequestService _tutoringRequestService;

        public TutoringRequestController(ITutoringRequestService tutoringRequestService)
        {
            _tutoringRequestService = tutoringRequestService;
        }

        // ==================== Student Endpoints ====================

        [HttpGet("my-requests")]
        public async Task<ActionResult<ApiResponse<PagedResultDto<TutoringRequestListDto>>>> GetMyRequests([FromQuery] PaginationDto pagination)
        {
            try
            {
                var userId = HttpContext.GetCurrentUserId();
                if (userId == null) return Unauthorized(ApiResponse<object>.ErrorResponse("User not authenticated"));

                var result = await _tutoringRequestService.GetStudentRequestsAsync(userId.Value, pagination);
                return Ok(ApiResponse<PagedResultDto<TutoringRequestListDto>>.SuccessResponse(result, "Requests retrieved successfully"));
            }
            catch (Exception)
            {
                return StatusCode(500, ApiResponse<PagedResultDto<TutoringRequestListDto>>.ErrorResponse("An error occurred while retrieving requests"));
            }
        }

        [HttpGet("{id:int}/student-view")]
        public async Task<ActionResult<ApiResponse<TutoringRequestStudentDto>>> GetStudentView(int id)
        {
            try
            {
                var userId = HttpContext.GetCurrentUserId();
                if (userId == null) return Unauthorized(ApiResponse<object>.ErrorResponse("User not authenticated"));

                var result = await _tutoringRequestService.GetStudentRequestByIdAsync(id, userId.Value);
                if (result == null) return NotFound(ApiResponse<TutoringRequestStudentDto>.ErrorResponse("Request not found"));

                return Ok(ApiResponse<TutoringRequestStudentDto>.SuccessResponse(result, "Request retrieved successfully"));
            }
            catch (Exception)
            {
                return StatusCode(500, ApiResponse<TutoringRequestStudentDto>.ErrorResponse("An error occurred"));
            }
        }

        [HttpPost]
        public async Task<ActionResult<ApiResponse<TutoringRequestResponseDto>>> CreateRequest([FromBody] CreateTutoringRequestDto dto)
        {
            try
            {
                var userId = HttpContext.GetCurrentUserId();
                if (userId == null) return Unauthorized(ApiResponse<object>.ErrorResponse("User not authenticated"));

                var result = await _tutoringRequestService.CreateRequestAsync(dto, userId.Value);
                return CreatedAtAction(nameof(GetStudentView), new { id = result.Id },
                    ApiResponse<TutoringRequestResponseDto>.SuccessResponse(result, "Request created successfully"));
            }
            catch (InvalidOperationException ex)
            {
                return BadRequest(ApiResponse<TutoringRequestResponseDto>.ErrorResponse(ex.Message));
            }
            catch (Exception)
            {
                return StatusCode(500, ApiResponse<TutoringRequestResponseDto>.ErrorResponse("An error occurred while creating request"));
            }
        }

        [HttpPut("{id:int}")]
        public async Task<ActionResult<ApiResponse<TutoringRequestResponseDto>>> UpdateRequest(int id, [FromBody] UpdateTutoringRequestDto dto)
        {
            try
            {
                var userId = HttpContext.GetCurrentUserId();
                if (userId == null) return Unauthorized(ApiResponse<object>.ErrorResponse("User not authenticated"));

                var result = await _tutoringRequestService.UpdateRequestAsync(id, dto, userId.Value);
                if (result == null) return NotFound(ApiResponse<TutoringRequestResponseDto>.ErrorResponse("Request not found"));

                return Ok(ApiResponse<TutoringRequestResponseDto>.SuccessResponse(result, "Request updated successfully"));
            }
            catch (InvalidOperationException ex)
            {
                return BadRequest(ApiResponse<TutoringRequestResponseDto>.ErrorResponse(ex.Message));
            }
            catch (Exception)
            {
                return StatusCode(500, ApiResponse<TutoringRequestResponseDto>.ErrorResponse("An error occurred while updating request"));
            }
        }

        [HttpPut("{id:int}/cancel")]
        public async Task<ActionResult<ApiResponse<object>>> CancelRequest(int id)
        {
            try
            {
                var userId = HttpContext.GetCurrentUserId();
                if (userId == null) return Unauthorized(ApiResponse<object>.ErrorResponse("User not authenticated"));

                var result = await _tutoringRequestService.CancelRequestAsync(id, userId.Value);
                if (!result) return NotFound(ApiResponse<object>.ErrorResponse("Request not found"));

                return Ok(ApiResponse<object>.SuccessResponse(null, "Request cancelled successfully"));
            }
            catch (InvalidOperationException ex)
            {
                return BadRequest(ApiResponse<object>.ErrorResponse(ex.Message));
            }
            catch (Exception)
            {
                return StatusCode(500, ApiResponse<object>.ErrorResponse("An error occurred while cancelling request"));
            }
        }

        // ==================== Student Enrollment (for admin-created sessions) ====================

        [HttpGet("my-enrolled-sessions")]
        public async Task<ActionResult<ApiResponse<PagedResultDto<TutoringRequestListDto>>>> GetMyEnrolledSessions([FromQuery] PaginationDto pagination)
        {
            try
            {
                var userId = HttpContext.GetCurrentUserId();
                if (userId == null) return Unauthorized(ApiResponse<object>.ErrorResponse("User not authenticated"));

                var result = await _tutoringRequestService.GetMyEnrolledSessionsAsync(userId.Value, pagination);
                return Ok(ApiResponse<PagedResultDto<TutoringRequestListDto>>.SuccessResponse(result, "Enrolled sessions retrieved successfully"));
            }
            catch (Exception)
            {
                return StatusCode(500, ApiResponse<PagedResultDto<TutoringRequestListDto>>.ErrorResponse("An error occurred"));
            }
        }

        [HttpGet("available-sessions")]
        public async Task<ActionResult<ApiResponse<PagedResultDto<TutoringRequestListDto>>>> GetAvailableSessions([FromQuery] PaginationDto pagination)
        {
            try
            {
                var userId = HttpContext.GetCurrentUserId();
                if (userId == null) return Unauthorized(ApiResponse<object>.ErrorResponse("User not authenticated"));

                var result = await _tutoringRequestService.GetAvailableSessionsForStudentAsync(userId.Value, pagination);
                return Ok(ApiResponse<PagedResultDto<TutoringRequestListDto>>.SuccessResponse(result, "Available sessions retrieved successfully"));
            }
            catch (Exception)
            {
                return StatusCode(500, ApiResponse<PagedResultDto<TutoringRequestListDto>>.ErrorResponse("An error occurred"));
            }
        }

        [HttpPost("{id:int}/enroll")]
        public async Task<ActionResult<ApiResponse<object>>> EnrollInSession(int id)
        {
            try
            {
                var userId = HttpContext.GetCurrentUserId();
                if (userId == null) return Unauthorized(ApiResponse<object>.ErrorResponse("User not authenticated"));

                await _tutoringRequestService.StudentEnrollAsync(id, userId.Value);
                return Ok(ApiResponse<object>.SuccessResponse(null, "Successfully enrolled in session"));
            }
            catch (InvalidOperationException ex)
            {
                return BadRequest(ApiResponse<object>.ErrorResponse(ex.Message));
            }
            catch (Exception)
            {
                return StatusCode(500, ApiResponse<object>.ErrorResponse("An error occurred"));
            }
        }

        // ==================== Teacher Endpoints ====================

        [RequirePermission("ViewTutoringRequests")]
        [HttpGet("available")]
        public async Task<ActionResult<ApiResponse<PagedResultDto<TutoringRequestListDto>>>> GetAvailableRequests([FromQuery] PaginationDto pagination)
        {
            try
            {
                var userId = HttpContext.GetCurrentUserId();
                if (userId == null) return Unauthorized(ApiResponse<object>.ErrorResponse("User not authenticated"));

                var result = await _tutoringRequestService.GetAvailableRequestsForTeacherAsync(userId.Value, pagination);
                return Ok(ApiResponse<PagedResultDto<TutoringRequestListDto>>.SuccessResponse(result, "Available requests retrieved successfully"));
            }
            catch (Exception)
            {
                return StatusCode(500, ApiResponse<PagedResultDto<TutoringRequestListDto>>.ErrorResponse("An error occurred"));
            }
        }

        [RequirePermission("UpdateTutoringRequests")]
        [HttpPost("{id:int}/express-interest")]
        public async Task<ActionResult<ApiResponse<object>>> ExpressInterest(int id, [FromBody] CreateTeacherInterestDto dto)
        {
            try
            {
                var userId = HttpContext.GetCurrentUserId();
                if (userId == null) return Unauthorized(ApiResponse<object>.ErrorResponse("User not authenticated"));

                await _tutoringRequestService.ExpressInterestAsync(id, userId.Value, dto);
                return Ok(ApiResponse<object>.SuccessResponse(null, "Interest expressed successfully"));
            }
            catch (InvalidOperationException ex)
            {
                return BadRequest(ApiResponse<object>.ErrorResponse(ex.Message));
            }
            catch (Exception)
            {
                return StatusCode(500, ApiResponse<object>.ErrorResponse("An error occurred"));
            }
        }

        [RequirePermission("ViewTutoringRequests")]
        [HttpGet("my-interests")]
        public async Task<ActionResult<ApiResponse<PagedResultDto<TutoringRequestListDto>>>> GetMyInterests([FromQuery] PaginationDto pagination)
        {
            try
            {
                var userId = HttpContext.GetCurrentUserId();
                if (userId == null) return Unauthorized(ApiResponse<object>.ErrorResponse("User not authenticated"));

                var result = await _tutoringRequestService.GetTeacherInterestHistoryAsync(userId.Value, pagination);
                return Ok(ApiResponse<PagedResultDto<TutoringRequestListDto>>.SuccessResponse(result, "Interest history retrieved successfully"));
            }
            catch (Exception)
            {
                return StatusCode(500, ApiResponse<PagedResultDto<TutoringRequestListDto>>.ErrorResponse("An error occurred"));
            }
        }

        [RequirePermission("UpdateTutoringRequests")]
        [HttpPut("{id:int}/confirm")]
        public async Task<ActionResult<ApiResponse<object>>> ConfirmSession(int id, [FromBody] ConfirmSessionDto dto)
        {
            try
            {
                var userId = HttpContext.GetCurrentUserId();
                if (userId == null) return Unauthorized(ApiResponse<object>.ErrorResponse("User not authenticated"));

                await _tutoringRequestService.ConfirmSessionAsync(id, userId.Value, dto.Accepted);
                var message = dto.Accepted ? "Session confirmed successfully" : "Session declined";
                return Ok(ApiResponse<object>.SuccessResponse(null, message));
            }
            catch (InvalidOperationException ex)
            {
                return BadRequest(ApiResponse<object>.ErrorResponse(ex.Message));
            }
            catch (Exception)
            {
                return StatusCode(500, ApiResponse<object>.ErrorResponse("An error occurred"));
            }
        }

        [HttpPut("{id:int}/student-withdraw")]
        public async Task<ActionResult<ApiResponse<object>>> StudentWithdrawFromSession(int id)
        {
            try
            {
                var userId = HttpContext.GetCurrentUserId();
                if (userId == null) return Unauthorized(ApiResponse<object>.ErrorResponse("User not authenticated"));

                var result = await _tutoringRequestService.StudentWithdrawAsync(id, userId.Value);
                if (!result) return NotFound(ApiResponse<object>.ErrorResponse("Request not found"));

                return Ok(ApiResponse<object>.SuccessResponse(null, "Successfully withdrawn from the session."));
            }
            catch (InvalidOperationException ex)
            {
                return BadRequest(ApiResponse<object>.ErrorResponse(ex.Message));
            }
            catch (Exception)
            {
                return StatusCode(500, ApiResponse<object>.ErrorResponse("An error occurred"));
            }
        }

        [RequirePermission("UpdateTutoringRequests")]
        [HttpPut("{id:int}/withdraw")]
        public async Task<ActionResult<ApiResponse<object>>> WithdrawFromSession(int id)
        {
            try
            {
                var userId = HttpContext.GetCurrentUserId();
                if (userId == null) return Unauthorized(ApiResponse<object>.ErrorResponse("User not authenticated"));

                var result = await _tutoringRequestService.TeacherWithdrawAsync(id, userId.Value);
                if (!result) return NotFound(ApiResponse<object>.ErrorResponse("Request not found"));

                return Ok(ApiResponse<object>.SuccessResponse(null, "Successfully withdrawn from session. Admin will be notified."));
            }
            catch (InvalidOperationException ex)
            {
                return BadRequest(ApiResponse<object>.ErrorResponse(ex.Message));
            }
            catch (Exception)
            {
                return StatusCode(500, ApiResponse<object>.ErrorResponse("An error occurred"));
            }
        }

        // ==================== Admin Endpoints ====================

        [RequirePermission("CreateTutoringRequests")]
        [HttpPost("admin-create")]
        public async Task<ActionResult<ApiResponse<TutoringRequestResponseDto>>> AdminCreateRequest([FromBody] CreateAdminTutoringRequestDto dto)
        {
            try
            {
                var userId = HttpContext.GetCurrentUserId();
                if (userId == null) return Unauthorized(ApiResponse<object>.ErrorResponse("User not authenticated"));

                var result = await _tutoringRequestService.CreateAdminRequestAsync(dto, userId.Value);
                return CreatedAtAction(nameof(GetRequestById), new { id = result.Id },
                    ApiResponse<TutoringRequestResponseDto>.SuccessResponse(result, "Admin request created successfully"));
            }
            catch (InvalidOperationException ex)
            {
                return BadRequest(ApiResponse<TutoringRequestResponseDto>.ErrorResponse(ex.Message));
            }
            catch (Exception)
            {
                return StatusCode(500, ApiResponse<TutoringRequestResponseDto>.ErrorResponse("An error occurred while creating request"));
            }
        }

        [RequirePermission("ViewTutoringRequests")]
        [HttpGet("conflict-check")]
        [Authorize(Roles = "Super Admin,Admin")]
        public async Task<IActionResult> GetConflictCheck([FromQuery] int teacherId, [FromQuery] int excludeRequestId = 0)
        {
            try
            {
                var result = await _tutoringRequestService.GetConflictDataAsync(teacherId, excludeRequestId);
                return Ok(ApiResponse<ConflictCheckResultDto>.SuccessResponse(result, "Conflict data retrieved successfully"));
            }
            catch (Exception)
            {
                return StatusCode(500, ApiResponse<ConflictCheckResultDto>.ErrorResponse("An error occurred"));
            }
        }

        [RequirePermission("ViewTutoringRequests")]
        [HttpGet("status-history")]
        [Authorize(Roles = "Super Admin,Admin")]
        public async Task<IActionResult> GetStatusHistory()
        {
            try
            {
                var history = await _tutoringRequestService.GetAllStatusHistoryAsync();
                return Ok(ApiResponse<List<TutoringRequestStatusHistoryDto>>.SuccessResponse(history, "Status history retrieved successfully"));
            }
            catch (Exception)
            {
                return StatusCode(500, ApiResponse<List<TutoringRequestStatusHistoryDto>>.ErrorResponse("An error occurred"));
            }
        }

        [RequirePermission("ViewTutoringRequests")]
        [HttpGet]
        public async Task<ActionResult<ApiResponse<PagedResultDto<TutoringRequestListDto>>>> GetAllRequests([FromQuery] PaginationDto pagination)
        {
            try
            {
                var result = await _tutoringRequestService.GetAllRequestsAsync(pagination);
                return Ok(ApiResponse<PagedResultDto<TutoringRequestListDto>>.SuccessResponse(result, "Requests retrieved successfully"));
            }
            catch (Exception)
            {
                return StatusCode(500, ApiResponse<PagedResultDto<TutoringRequestListDto>>.ErrorResponse("An error occurred"));
            }
        }

        [RequirePermission("ViewTutoringRequests")]
        [HttpGet("{id:int}")]
        public async Task<ActionResult<ApiResponse<TutoringRequestResponseDto>>> GetRequestById(int id)
        {
            try
            {
                var result = await _tutoringRequestService.GetRequestByIdAsync(id);
                if (result == null) return NotFound(ApiResponse<TutoringRequestResponseDto>.ErrorResponse("Request not found"));

                return Ok(ApiResponse<TutoringRequestResponseDto>.SuccessResponse(result, "Request retrieved successfully"));
            }
            catch (Exception)
            {
                return StatusCode(500, ApiResponse<TutoringRequestResponseDto>.ErrorResponse("An error occurred"));
            }
        }

        [RequirePermission("UpdateTutoringRequests")]
        [HttpPut("{id:int}/assign-teacher")]
        public async Task<ActionResult<ApiResponse<object>>> AssignTeacher(int id, [FromBody] AssignTeacherDto dto)
        {
            try
            {
                var userId = HttpContext.GetCurrentUserId();
                if (userId == null) return Unauthorized(ApiResponse<object>.ErrorResponse("User not authenticated"));

                await _tutoringRequestService.AssignTeacherAsync(id, dto.TeacherId, userId.Value);
                return Ok(ApiResponse<object>.SuccessResponse(null, "Teacher assigned successfully"));
            }
            catch (InvalidOperationException ex)
            {
                return BadRequest(ApiResponse<object>.ErrorResponse(ex.Message));
            }
            catch (Exception)
            {
                return StatusCode(500, ApiResponse<object>.ErrorResponse("An error occurred"));
            }
        }

        [RequirePermission("UpdateTutoringRequests")]
        [HttpPut("{id:int}/schedule")]
        public async Task<ActionResult<ApiResponse<TutoringRequestResponseDto>>> ScheduleSession(int id, [FromBody] ScheduleSessionDto dto)
        {
            try
            {
                var userId = HttpContext.GetCurrentUserId();
                if (userId == null) return Unauthorized(ApiResponse<object>.ErrorResponse("User not authenticated"));

                var result = await _tutoringRequestService.ScheduleSessionAsync(id, dto, userId.Value);
                if (result == null) return NotFound(ApiResponse<TutoringRequestResponseDto>.ErrorResponse("Request not found"));

                return Ok(ApiResponse<TutoringRequestResponseDto>.SuccessResponse(result, "Session scheduled successfully"));
            }
            catch (InvalidOperationException ex)
            {
                return BadRequest(ApiResponse<TutoringRequestResponseDto>.ErrorResponse(ex.Message));
            }
            catch (Exception)
            {
                return StatusCode(500, ApiResponse<TutoringRequestResponseDto>.ErrorResponse("An error occurred"));
            }
        }

        [RequirePermission("UpdateTutoringRequests")]
        [HttpPut("{id:int}/admin-cancel")]
        public async Task<ActionResult<ApiResponse<object>>> AdminCancelRequest(int id, [FromBody] AdminCancelRequestDto dto)
        {
            try
            {
                var userId = HttpContext.GetCurrentUserId();
                if (userId == null) return Unauthorized(ApiResponse<object>.ErrorResponse("User not authenticated"));

                var result = await _tutoringRequestService.AdminCancelRequestAsync(id, userId.Value, dto.CancellationReason);
                if (!result) return NotFound(ApiResponse<object>.ErrorResponse("Request not found"));

                return Ok(ApiResponse<object>.SuccessResponse(null, "Request cancelled by admin successfully"));
            }
            catch (InvalidOperationException ex)
            {
                return BadRequest(ApiResponse<object>.ErrorResponse(ex.Message));
            }
            catch (Exception)
            {
                return StatusCode(500, ApiResponse<object>.ErrorResponse("An error occurred"));
            }
        }

        [RequirePermission("UpdateTutoringRequests")]
        [HttpPut("{id:int}/admin-restore")]
        public async Task<ActionResult<ApiResponse<object>>> AdminRestoreRequest(int id)
        {
            try
            {
                var userId = HttpContext.GetCurrentUserId();
                if (userId == null) return Unauthorized(ApiResponse<object>.ErrorResponse("User not authenticated"));

                var result = await _tutoringRequestService.AdminRestoreRequestAsync(id, userId.Value);
                if (!result) return NotFound(ApiResponse<object>.ErrorResponse("Request not found"));

                return Ok(ApiResponse<object>.SuccessResponse(null, "Request restored successfully"));
            }
            catch (InvalidOperationException ex)
            {
                return BadRequest(ApiResponse<object>.ErrorResponse(ex.Message));
            }
            catch (Exception)
            {
                return StatusCode(500, ApiResponse<object>.ErrorResponse("An error occurred"));
            }
        }

        [RequirePermission("DeleteTutoringRequests")]
        [HttpDelete("{id:int}")]
        public async Task<ActionResult<ApiResponse<object>>> DeleteRequest(int id)
        {
            try
            {
                var userId = HttpContext.GetCurrentUserId();
                var result = await _tutoringRequestService.DeleteRequestAsync(id, userId);
                if (!result) return NotFound(ApiResponse<object>.ErrorResponse("Request not found"));

                return Ok(ApiResponse<object>.SuccessResponse(null, "Request deleted successfully"));
            }
            catch (Exception)
            {
                return StatusCode(500, ApiResponse<object>.ErrorResponse("An error occurred"));
            }
        }

        [RequirePermission("RestoreTutoringRequests")]
        [HttpPut("{id:int}/restore")]
        public async Task<ActionResult<ApiResponse<object>>> RestoreRequest(int id)
        {
            try
            {
                var userId = HttpContext.GetCurrentUserId();
                var result = await _tutoringRequestService.RestoreRequestAsync(id, userId);
                if (!result) return NotFound(ApiResponse<object>.ErrorResponse("Request not found in archive"));

                return Ok(ApiResponse<object>.SuccessResponse(null, "Request restored successfully"));
            }
            catch (Exception)
            {
                return StatusCode(500, ApiResponse<object>.ErrorResponse("An error occurred"));
            }
        }
    }
}
