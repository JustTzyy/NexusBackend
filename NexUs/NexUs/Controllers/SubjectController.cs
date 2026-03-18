using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using NexUs.Attributes;
using NexUs.Extensions;
using NexUs.Models.DTO.Common;
using NexUs.Models.DTO.Subjects;
using NexUs.Services.Interfaces;

namespace NexUs.Controllers
{
    [Route("api/subject")]
    [ApiController]
    [Authorize]
    public class SubjectController : ControllerBase
    {
        private readonly ISubjectService _subjectService;

        public SubjectController(ISubjectService subjectService)
        {
            _subjectService = subjectService;
        }

        [HttpGet("lookup")]
        public async Task<ActionResult<ApiResponse<PagedResultDto<SubjectListDto>>>> GetSubjectLookup()
        {
            try
            {
                var result = await _subjectService.GetAllSubjectsAsync(new PaginationDto { PageSize = 1000 });
                return Ok(ApiResponse<PagedResultDto<SubjectListDto>>.SuccessResponse(result, "Subjects retrieved successfully"));
            }
            catch (Exception ex)
            {
                return StatusCode(500, ApiResponse<PagedResultDto<SubjectListDto>>.ErrorResponse("An error occurred while retrieving subjects", new List<string> { ex.Message }));
            }
        }

        [RequirePermission("ViewSubjects")]
        [HttpGet]
        public async Task<ActionResult<ApiResponse<PagedResultDto<SubjectListDto>>>> GetAllSubjects([FromQuery] PaginationDto pagination)
        {
            try
            {
                var result = await _subjectService.GetAllSubjectsAsync(pagination);
                return Ok(ApiResponse<PagedResultDto<SubjectListDto>>.SuccessResponse(result, "Subjects retrieved successfully"));
            }
            catch (Exception ex)
            {
                return StatusCode(500, ApiResponse<PagedResultDto<SubjectListDto>>.ErrorResponse("An error occurred while retrieving subjects", new List<string> { ex.Message }));
            }
        }

        [RequirePermission("ArchiveSubjects")]
        [HttpGet("archive")]
        public async Task<ActionResult<ApiResponse<PagedResultDto<SubjectListDto>>>> GetArchivedSubjects([FromQuery] PaginationDto pagination)
        {
            try
            {
                var result = await _subjectService.GetArchivedSubjectsAsync(pagination);
                return Ok(ApiResponse<PagedResultDto<SubjectListDto>>.SuccessResponse(result, "Archived subjects retrieved successfully"));
            }
            catch (Exception ex)
            {
                return StatusCode(500, ApiResponse<PagedResultDto<SubjectListDto>>.ErrorResponse("An error occurred while retrieving archived subjects", new List<string> { ex.Message }));
            }
        }

        [RequirePermission("ViewSubjects")]
        [HttpGet("{id:int}")]
        public async Task<ActionResult<ApiResponse<SubjectResponseDto>>> GetSubjectById(int id)
        {
            try
            {
                var subject = await _subjectService.GetSubjectByIdAsync(id);
                if (subject == null)
                {
                    return NotFound(ApiResponse<SubjectResponseDto>.ErrorResponse("Subject not found"));
                }

                return Ok(ApiResponse<SubjectResponseDto>.SuccessResponse(subject, "Subject retrieved successfully"));
            }
            catch (Exception ex)
            {
                return StatusCode(500, ApiResponse<SubjectResponseDto>.ErrorResponse("An error occurred while retrieving subject", new List<string> { ex.Message }));
            }
        }

        [RequirePermission("CreateSubjects")]
        [HttpPost]
        public async Task<ActionResult<ApiResponse<SubjectResponseDto>>> CreateSubject([FromBody] CreateSubjectDto dto)
        {
            try
            {
                var currentUserId = HttpContext.GetCurrentUserId();
                var subject = await _subjectService.CreateSubjectAsync(dto, currentUserId);
                return CreatedAtAction(nameof(GetSubjectById), new { id = subject.Id },
                    ApiResponse<SubjectResponseDto>.SuccessResponse(subject, "Subject created successfully"));
            }
            catch (InvalidOperationException ex)
            {
                return BadRequest(ApiResponse<SubjectResponseDto>.ErrorResponse(ex.Message));
            }
            catch (Exception ex)
            {
                return StatusCode(500, ApiResponse<SubjectResponseDto>.ErrorResponse("An error occurred while creating subject", new List<string> { ex.Message }));
            }
        }

        [RequirePermission("UpdateSubjects")]
        [HttpPut("{id}")]
        public async Task<ActionResult<ApiResponse<SubjectResponseDto>>> UpdateSubject(int id, [FromBody] UpdateSubjectDto dto)
        {
            try
            {
                var currentUserId = HttpContext.GetCurrentUserId();
                var subject = await _subjectService.UpdateSubjectAsync(id, dto, currentUserId);
                if (subject == null)
                {
                    return NotFound(ApiResponse<SubjectResponseDto>.ErrorResponse("Subject not found"));
                }

                return Ok(ApiResponse<SubjectResponseDto>.SuccessResponse(subject, "Subject updated successfully"));
            }
            catch (InvalidOperationException ex)
            {
                return BadRequest(ApiResponse<SubjectResponseDto>.ErrorResponse(ex.Message));
            }
            catch (Exception ex)
            {
                return StatusCode(500, ApiResponse<SubjectResponseDto>.ErrorResponse("An error occurred while updating subject", new List<string> { ex.Message }));
            }
        }

        [RequirePermission("DeleteSubjects")]
        [HttpDelete("{id}")]
        public async Task<ActionResult<ApiResponse<object>>> DeleteSubject(int id)
        {
            try
            {
                var currentUserId = HttpContext.GetCurrentUserId();
                var result = await _subjectService.DeleteSubjectAsync(id, currentUserId);
                if (!result)
                {
                    return NotFound(ApiResponse<object>.ErrorResponse("Subject not found"));
                }

                return Ok(ApiResponse<object>.SuccessResponse(null, "Subject deleted successfully"));
            }
            catch (Exception ex)
            {
                return StatusCode(500, ApiResponse<object>.ErrorResponse("An error occurred while deleting subject", new List<string> { ex.Message }));
            }
        }

        [RequirePermission("RestoreSubjects")]
        [HttpPut("{id}/restore")]
        public async Task<ActionResult<ApiResponse<object>>> RestoreSubject(int id)
        {
            try
            {
                var currentUserId = HttpContext.GetCurrentUserId();
                var result = await _subjectService.RestoreSubjectAsync(id, currentUserId);
                if (!result)
                {
                    return NotFound(ApiResponse<object>.ErrorResponse("Subject not found in archive"));
                }

                return Ok(ApiResponse<object>.SuccessResponse(null, "Subject restored successfully"));
            }
            catch (Exception ex)
            {
                return StatusCode(500, ApiResponse<object>.ErrorResponse("An error occurred while restoring subject", new List<string> { ex.Message }));
            }
        }

        [RequirePermission("PermanentDeleteSubjects")]
        [HttpDelete("{id}/permanent")]
        public async Task<ActionResult<ApiResponse<object>>> PermanentDeleteSubject(int id)
        {
            try
            {
                var currentUserId = HttpContext.GetCurrentUserId();
                var result = await _subjectService.PermanentDeleteSubjectAsync(id, currentUserId);
                if (!result)
                {
                    return NotFound(ApiResponse<object>.ErrorResponse("Subject not found in archive"));
                }

                return Ok(ApiResponse<object>.SuccessResponse(null, "Subject permanently deleted"));
            }
            catch (Exception ex)
            {
                return StatusCode(500, ApiResponse<object>.ErrorResponse("An error occurred while permanently deleting subject", new List<string> { ex.Message }));
            }
        }
    }
}
