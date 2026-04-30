using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using NexUs.Attributes;
using NexUs.Extensions;
using NexUs.Models.DTO.Common;
using NexUs.Models.DTO.StudentAssignments;
using NexUs.Services.Interfaces;

namespace NexUs.Controllers
{
    [Route("api/student-assignment")]
    [ApiController]
    [Authorize]
    public class StudentAssignmentController : ControllerBase
    {
        private readonly IStudentAssignmentService _service;

        public StudentAssignmentController(IStudentAssignmentService service)
        {
            _service = service;
        }

        /// <summary>
        /// Get all active student assignments (admin)
        /// </summary>
        [RequirePermission("ViewStudentAssignments")]
        [HttpGet]
        public async Task<ActionResult<ApiResponse<PagedResultDto<StudentAssignmentListDto>>>> GetAll([FromQuery] PaginationDto pagination)
        {
            try
            {
                var result = await _service.GetAllAsync(pagination);
                return Ok(ApiResponse<PagedResultDto<StudentAssignmentListDto>>.SuccessResponse(result, "Student assignments retrieved successfully"));
            }
            catch (Exception)
            {
                return StatusCode(500, ApiResponse<PagedResultDto<StudentAssignmentListDto>>.ErrorResponse("An error occurred"));
            }
        }

        /// <summary>
        /// Get archived student assignments (admin)
        /// </summary>
        [RequirePermission("ViewStudentAssignments")]
        [HttpGet("archive")]
        public async Task<ActionResult<ApiResponse<PagedResultDto<StudentAssignmentListDto>>>> GetArchived([FromQuery] PaginationDto pagination)
        {
            try
            {
                var result = await _service.GetArchivedAsync(pagination);
                return Ok(ApiResponse<PagedResultDto<StudentAssignmentListDto>>.SuccessResponse(result, "Archived student assignments retrieved successfully"));
            }
            catch (Exception)
            {
                return StatusCode(500, ApiResponse<PagedResultDto<StudentAssignmentListDto>>.ErrorResponse("An error occurred"));
            }
        }

        /// <summary>
        /// Get current user's student assignment
        /// </summary>
        [HttpGet("me")]
        public async Task<ActionResult<ApiResponse<StudentAssignmentResponseDto?>>> GetMine()
        {
            try
            {
                var currentUserId = HttpContext.GetCurrentUserId();
                if (currentUserId == null)
                    return Unauthorized(ApiResponse<StudentAssignmentResponseDto?>.ErrorResponse("Unauthorized"));

                var result = await _service.GetByStudentIdAsync(currentUserId.Value);
                return Ok(ApiResponse<StudentAssignmentResponseDto?>.SuccessResponse(result, "Student assignment retrieved"));
            }
            catch (Exception)
            {
                return StatusCode(500, ApiResponse<StudentAssignmentResponseDto?>.ErrorResponse("An error occurred"));
            }
        }

        /// <summary>
        /// Upsert current user's student assignment
        /// </summary>
        [HttpPut("me")]
        public async Task<ActionResult<ApiResponse<StudentAssignmentResponseDto>>> UpsertMine([FromBody] UpdateStudentAssignmentDto dto)
        {
            try
            {
                var currentUserId = HttpContext.GetCurrentUserId();
                if (currentUserId == null)
                    return Unauthorized(ApiResponse<StudentAssignmentResponseDto>.ErrorResponse("Unauthorized"));

                var result = await _service.UpsertByStudentIdAsync(currentUserId.Value, dto, currentUserId);
                return Ok(ApiResponse<StudentAssignmentResponseDto>.SuccessResponse(result, "Student assignment updated"));
            }
            catch (Exception)
            {
                return StatusCode(500, ApiResponse<StudentAssignmentResponseDto>.ErrorResponse("An error occurred"));
            }
        }

        /// <summary>
        /// Get student assignment by ID (admin)
        /// </summary>
        [RequirePermission("ViewStudentAssignments")]
        [HttpGet("{id:int}")]
        public async Task<ActionResult<ApiResponse<StudentAssignmentResponseDto>>> GetById(int id)
        {
            try
            {
                var result = await _service.GetByIdAsync(id);
                if (result == null)
                    return NotFound(ApiResponse<StudentAssignmentResponseDto>.ErrorResponse("Student assignment not found"));

                return Ok(ApiResponse<StudentAssignmentResponseDto>.SuccessResponse(result, "Student assignment retrieved"));
            }
            catch (Exception)
            {
                return StatusCode(500, ApiResponse<StudentAssignmentResponseDto>.ErrorResponse("An error occurred"));
            }
        }

        /// <summary>
        /// Update student assignment by ID (admin)
        /// </summary>
        [RequirePermission("UpdateStudentAssignments")]
        [HttpPut("{id:int}")]
        public async Task<ActionResult<ApiResponse<StudentAssignmentResponseDto>>> Update(int id, [FromBody] UpdateStudentAssignmentDto dto)
        {
            try
            {
                var currentUserId = HttpContext.GetCurrentUserId();
                var result = await _service.UpdateAsync(id, dto, currentUserId);
                if (result == null)
                    return NotFound(ApiResponse<StudentAssignmentResponseDto>.ErrorResponse("Student assignment not found"));

                return Ok(ApiResponse<StudentAssignmentResponseDto>.SuccessResponse(result, "Student assignment updated"));
            }
            catch (Exception)
            {
                return StatusCode(500, ApiResponse<StudentAssignmentResponseDto>.ErrorResponse("An error occurred"));
            }
        }

        /// <summary>
        /// Soft delete a student assignment
        /// </summary>
        [RequirePermission("DeleteStudentAssignments")]
        [HttpDelete("{id:int}")]
        public async Task<ActionResult<ApiResponse<object>>> Delete(int id)
        {
            try
            {
                var currentUserId = HttpContext.GetCurrentUserId();
                var result = await _service.DeleteAsync(id, currentUserId);
                if (!result)
                    return NotFound(ApiResponse<object>.ErrorResponse("Student assignment not found"));

                return Ok(ApiResponse<object>.SuccessResponse(null, "Student assignment deleted"));
            }
            catch (Exception)
            {
                return StatusCode(500, ApiResponse<object>.ErrorResponse("An error occurred"));
            }
        }

        /// <summary>
        /// Restore a soft-deleted student assignment
        /// </summary>
        [RequirePermission("RestoreStudentAssignments")]
        [HttpPut("{id:int}/restore")]
        public async Task<ActionResult<ApiResponse<object>>> Restore(int id)
        {
            try
            {
                var currentUserId = HttpContext.GetCurrentUserId();
                var result = await _service.RestoreAsync(id, currentUserId);
                if (!result)
                    return NotFound(ApiResponse<object>.ErrorResponse("Student assignment not found in archive"));

                return Ok(ApiResponse<object>.SuccessResponse(null, "Student assignment restored"));
            }
            catch (Exception)
            {
                return StatusCode(500, ApiResponse<object>.ErrorResponse("An error occurred"));
            }
        }

        /// <summary>
        /// Permanently delete a student assignment
        /// </summary>
        [RequirePermission("PermanentDeleteStudentAssignments")]
        [HttpDelete("{id:int}/permanent")]
        public async Task<ActionResult<ApiResponse<object>>> PermanentDelete(int id)
        {
            try
            {
                var currentUserId = HttpContext.GetCurrentUserId();
                var result = await _service.PermanentDeleteAsync(id, currentUserId);
                if (!result)
                    return NotFound(ApiResponse<object>.ErrorResponse("Student assignment not found in archive"));

                return Ok(ApiResponse<object>.SuccessResponse(null, "Student assignment permanently deleted"));
            }
            catch (Exception)
            {
                return StatusCode(500, ApiResponse<object>.ErrorResponse("An error occurred"));
            }
        }
    }
}
