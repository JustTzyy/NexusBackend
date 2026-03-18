using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NexUs.Attributes;
using NexUs.Data;
using NexUs.Extensions;
using NexUs.Models.DTO.Common;
using NexUs.Models.DTO.TeacherAssignments;
using NexUs.Services.Interfaces;

namespace NexUs.Controllers
{
    [Route("api/teacher-assignment")]
    [ApiController]
    [Authorize]
    public class TeacherAssignmentController : ControllerBase
    {
        private readonly ITeacherAssignmentService _teacherAssignmentService;
        private readonly ApplicationDbContext _context;

        public TeacherAssignmentController(ITeacherAssignmentService teacherAssignmentService, ApplicationDbContext context)
        {
            _teacherAssignmentService = teacherAssignmentService;
            _context = context;
        }

        /// <summary>
        /// Returns whether the currently authenticated teacher has at least one active building/department assignment.
        /// </summary>
        [HttpGet("mine")]
        public async Task<ActionResult<ApiResponse<object>>> GetMine()
        {
            try
            {
                var teacherId = HttpContext.GetCurrentUserId();
                if (teacherId == null)
                    return Unauthorized(ApiResponse<object>.ErrorResponse("User not authenticated"));

                var hasAssignment = await _context.TeacherAssignments
                    .AnyAsync(a => a.TeacherId == teacherId.Value && a.DeletedAt == null);

                return Ok(ApiResponse<object>.SuccessResponse(new { hasAssignment }, "Teacher assignment status retrieved"));
            }
            catch (Exception ex)
            {
                return StatusCode(500, ApiResponse<object>.ErrorResponse(
                    "An error occurred while checking teacher assignments", new List<string> { ex.Message }));
            }
        }

        [RequirePermission("ViewTeacherAssignments")]
        [HttpGet]
        public async Task<ActionResult<ApiResponse<PagedResultDto<TeacherAssignmentListDto>>>> GetAllTeacherAssignments([FromQuery] PaginationDto pagination)
        {
            try
            {
                var result = await _teacherAssignmentService.GetAllTeacherAssignmentsAsync(pagination);
                return Ok(ApiResponse<PagedResultDto<TeacherAssignmentListDto>>.SuccessResponse(result, "Teacher assignments retrieved successfully"));
            }
            catch (Exception ex)
            {
                return StatusCode(500, ApiResponse<PagedResultDto<TeacherAssignmentListDto>>.ErrorResponse("An error occurred while retrieving teacher assignments", new List<string> { ex.Message }));
            }
        }

        [RequirePermission("ArchiveTeacherAssignments")]
        [HttpGet("archive")]
        public async Task<ActionResult<ApiResponse<PagedResultDto<TeacherAssignmentListDto>>>> GetArchivedTeacherAssignments([FromQuery] PaginationDto pagination)
        {
            try
            {
                var result = await _teacherAssignmentService.GetArchivedTeacherAssignmentsAsync(pagination);
                return Ok(ApiResponse<PagedResultDto<TeacherAssignmentListDto>>.SuccessResponse(result, "Archived teacher assignments retrieved successfully"));
            }
            catch (Exception ex)
            {
                return StatusCode(500, ApiResponse<PagedResultDto<TeacherAssignmentListDto>>.ErrorResponse("An error occurred while retrieving archived teacher assignments", new List<string> { ex.Message }));
            }
        }

        [RequirePermission("ViewTeacherAssignments")]
        [HttpGet("{id:int}")]
        public async Task<ActionResult<ApiResponse<TeacherAssignmentResponseDto>>> GetTeacherAssignmentById(int id)
        {
            try
            {
                var assignment = await _teacherAssignmentService.GetTeacherAssignmentByIdAsync(id);
                if (assignment == null)
                {
                    return NotFound(ApiResponse<TeacherAssignmentResponseDto>.ErrorResponse("Teacher assignment not found"));
                }

                return Ok(ApiResponse<TeacherAssignmentResponseDto>.SuccessResponse(assignment, "Teacher assignment retrieved successfully"));
            }
            catch (Exception ex)
            {
                return StatusCode(500, ApiResponse<TeacherAssignmentResponseDto>.ErrorResponse("An error occurred while retrieving teacher assignment", new List<string> { ex.Message }));
            }
        }

        [RequirePermission("CreateTeacherAssignments")]
        [HttpPost]
        public async Task<ActionResult<ApiResponse<TeacherAssignmentResponseDto>>> CreateTeacherAssignment([FromBody] CreateTeacherAssignmentDto dto)
        {
            try
            {
                var currentUserId = HttpContext.GetCurrentUserId();
                var assignment = await _teacherAssignmentService.CreateTeacherAssignmentAsync(dto, currentUserId);
                return CreatedAtAction(nameof(GetTeacherAssignmentById), new { id = assignment.Id },
                    ApiResponse<TeacherAssignmentResponseDto>.SuccessResponse(assignment, "Teacher assignment created successfully"));
            }
            catch (InvalidOperationException ex)
            {
                return BadRequest(ApiResponse<TeacherAssignmentResponseDto>.ErrorResponse(ex.Message));
            }
            catch (Exception ex)
            {
                return StatusCode(500, ApiResponse<TeacherAssignmentResponseDto>.ErrorResponse("An error occurred while creating teacher assignment", new List<string> { ex.Message }));
            }
        }

        [RequirePermission("UpdateTeacherAssignments")]
        [HttpPut("{id}")]
        public async Task<ActionResult<ApiResponse<TeacherAssignmentResponseDto>>> UpdateTeacherAssignment(int id, [FromBody] UpdateTeacherAssignmentDto dto)
        {
            try
            {
                var currentUserId = HttpContext.GetCurrentUserId();
                var assignment = await _teacherAssignmentService.UpdateTeacherAssignmentAsync(id, dto, currentUserId);
                if (assignment == null)
                {
                    return NotFound(ApiResponse<TeacherAssignmentResponseDto>.ErrorResponse("Teacher assignment not found"));
                }

                return Ok(ApiResponse<TeacherAssignmentResponseDto>.SuccessResponse(assignment, "Teacher assignment updated successfully"));
            }
            catch (InvalidOperationException ex)
            {
                return BadRequest(ApiResponse<TeacherAssignmentResponseDto>.ErrorResponse(ex.Message));
            }
            catch (Exception ex)
            {
                return StatusCode(500, ApiResponse<TeacherAssignmentResponseDto>.ErrorResponse("An error occurred while updating teacher assignment", new List<string> { ex.Message }));
            }
        }

        [RequirePermission("DeleteTeacherAssignments")]
        [HttpDelete("{id}")]
        public async Task<ActionResult<ApiResponse<object>>> DeleteTeacherAssignment(int id)
        {
            try
            {
                var currentUserId = HttpContext.GetCurrentUserId();
                var result = await _teacherAssignmentService.DeleteTeacherAssignmentAsync(id, currentUserId);
                if (!result)
                {
                    return NotFound(ApiResponse<object>.ErrorResponse("Teacher assignment not found"));
                }

                return Ok(ApiResponse<object>.SuccessResponse(null, "Teacher assignment deleted successfully"));
            }
            catch (Exception ex)
            {
                return StatusCode(500, ApiResponse<object>.ErrorResponse("An error occurred while deleting teacher assignment", new List<string> { ex.Message }));
            }
        }

        [RequirePermission("RestoreTeacherAssignments")]
        [HttpPut("{id}/restore")]
        public async Task<ActionResult<ApiResponse<object>>> RestoreTeacherAssignment(int id)
        {
            try
            {
                var currentUserId = HttpContext.GetCurrentUserId();
                var result = await _teacherAssignmentService.RestoreTeacherAssignmentAsync(id, currentUserId);
                if (!result)
                {
                    return NotFound(ApiResponse<object>.ErrorResponse("Teacher assignment not found in archive"));
                }

                return Ok(ApiResponse<object>.SuccessResponse(null, "Teacher assignment restored successfully"));
            }
            catch (Exception ex)
            {
                return StatusCode(500, ApiResponse<object>.ErrorResponse("An error occurred while restoring teacher assignment", new List<string> { ex.Message }));
            }
        }

        [RequirePermission("PermanentDeleteTeacherAssignments")]
        [HttpDelete("{id}/permanent")]
        public async Task<ActionResult<ApiResponse<object>>> PermanentDeleteTeacherAssignment(int id)
        {
            try
            {
                var currentUserId = HttpContext.GetCurrentUserId();
                var result = await _teacherAssignmentService.PermanentDeleteTeacherAssignmentAsync(id, currentUserId);
                if (!result)
                {
                    return NotFound(ApiResponse<object>.ErrorResponse("Teacher assignment not found in archive"));
                }

                return Ok(ApiResponse<object>.SuccessResponse(null, "Teacher assignment permanently deleted"));
            }
            catch (Exception ex)
            {
                return StatusCode(500, ApiResponse<object>.ErrorResponse("An error occurred while permanently deleting teacher assignment", new List<string> { ex.Message }));
            }
        }
    }
}
