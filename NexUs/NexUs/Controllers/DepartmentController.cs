using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using NexUs.Attributes;
using NexUs.Extensions;
using NexUs.Models.DTO.Common;
using NexUs.Models.DTO.Departments;
using NexUs.Services.Interfaces;

namespace NexUs.Controllers
{
    [Route("api/department")]
    [ApiController]
    [Authorize]
    public class DepartmentController : ControllerBase
    {
        private readonly IDepartmentService _departmentService;

        public DepartmentController(IDepartmentService departmentService)
        {
            _departmentService = departmentService;
        }

        [HttpGet("lookup")]
        public async Task<ActionResult<ApiResponse<PagedResultDto<DepartmentListDto>>>> GetDepartmentLookup()
        {
            try
            {
                var result = await _departmentService.GetAllDepartmentsAsync(new PaginationDto { PageSize = 1000 });
                return Ok(ApiResponse<PagedResultDto<DepartmentListDto>>.SuccessResponse(result, "Departments retrieved successfully"));
            }
            catch (Exception)
            {
                return StatusCode(500, ApiResponse<PagedResultDto<DepartmentListDto>>.ErrorResponse("An error occurred while retrieving departments"));
            }
        }

        [RequirePermission("ViewDepartments")]
        [HttpGet]
        public async Task<ActionResult<ApiResponse<PagedResultDto<DepartmentListDto>>>> GetAllDepartments([FromQuery] PaginationDto pagination)
        {
            try
            {
                var result = await _departmentService.GetAllDepartmentsAsync(pagination);
                return Ok(ApiResponse<PagedResultDto<DepartmentListDto>>.SuccessResponse(result, "Departments retrieved successfully"));
            }
            catch (Exception)
            {
                return StatusCode(500, ApiResponse<PagedResultDto<DepartmentListDto>>.ErrorResponse("An error occurred while retrieving departments"));
            }
        }

        [RequirePermission("ArchiveDepartments")]
        [HttpGet("archive")]
        public async Task<ActionResult<ApiResponse<PagedResultDto<DepartmentListDto>>>> GetArchivedDepartments([FromQuery] PaginationDto pagination)
        {
            try
            {
                var result = await _departmentService.GetArchivedDepartmentsAsync(pagination);
                return Ok(ApiResponse<PagedResultDto<DepartmentListDto>>.SuccessResponse(result, "Archived departments retrieved successfully"));
            }
            catch (Exception)
            {
                return StatusCode(500, ApiResponse<PagedResultDto<DepartmentListDto>>.ErrorResponse("An error occurred while retrieving archived departments"));
            }
        }

        [RequirePermission("ViewDepartments")]
        [HttpGet("{id:int}")]
        public async Task<ActionResult<ApiResponse<DepartmentResponseDto>>> GetDepartmentById(int id)
        {
            try
            {
                var department = await _departmentService.GetDepartmentByIdAsync(id);
                if (department == null)
                {
                    return NotFound(ApiResponse<DepartmentResponseDto>.ErrorResponse("Department not found"));
                }

                return Ok(ApiResponse<DepartmentResponseDto>.SuccessResponse(department, "Department retrieved successfully"));
            }
            catch (Exception)
            {
                return StatusCode(500, ApiResponse<DepartmentResponseDto>.ErrorResponse("An error occurred while retrieving department"));
            }
        }

        [RequirePermission("CreateDepartments")]
        [HttpPost]
        public async Task<ActionResult<ApiResponse<DepartmentResponseDto>>> CreateDepartment([FromBody] CreateDepartmentDto dto)
        {
            try
            {
                var currentUserId = HttpContext.GetCurrentUserId();
                var department = await _departmentService.CreateDepartmentAsync(dto, currentUserId);
                return CreatedAtAction(nameof(GetDepartmentById), new { id = department.Id },
                    ApiResponse<DepartmentResponseDto>.SuccessResponse(department, "Department created successfully"));
            }
            catch (InvalidOperationException ex)
            {
                return BadRequest(ApiResponse<DepartmentResponseDto>.ErrorResponse(ex.Message));
            }
            catch (Exception)
            {
                return StatusCode(500, ApiResponse<DepartmentResponseDto>.ErrorResponse("An error occurred while creating department"));
            }
        }

        [RequirePermission("UpdateDepartments")]
        [HttpPut("{id}")]
        public async Task<ActionResult<ApiResponse<DepartmentResponseDto>>> UpdateDepartment(int id, [FromBody] UpdateDepartmentDto dto)
        {
            try
            {
                var currentUserId = HttpContext.GetCurrentUserId();
                var department = await _departmentService.UpdateDepartmentAsync(id, dto, currentUserId);
                if (department == null)
                {
                    return NotFound(ApiResponse<DepartmentResponseDto>.ErrorResponse("Department not found"));
                }

                return Ok(ApiResponse<DepartmentResponseDto>.SuccessResponse(department, "Department updated successfully"));
            }
            catch (InvalidOperationException ex)
            {
                return BadRequest(ApiResponse<DepartmentResponseDto>.ErrorResponse(ex.Message));
            }
            catch (Exception)
            {
                return StatusCode(500, ApiResponse<DepartmentResponseDto>.ErrorResponse("An error occurred while updating department"));
            }
        }

        [RequirePermission("DeleteDepartments")]
        [HttpDelete("{id}")]
        public async Task<ActionResult<ApiResponse<object>>> DeleteDepartment(int id)
        {
            try
            {
                var currentUserId = HttpContext.GetCurrentUserId();
                var result = await _departmentService.DeleteDepartmentAsync(id, currentUserId);
                if (!result)
                {
                    return NotFound(ApiResponse<object>.ErrorResponse("Department not found"));
                }

                return Ok(ApiResponse<object>.SuccessResponse(null, "Department deleted successfully"));
            }
            catch (Exception)
            {
                return StatusCode(500, ApiResponse<object>.ErrorResponse("An error occurred while deleting department"));
            }
        }

        [RequirePermission("RestoreDepartments")]
        [HttpPut("{id}/restore")]
        public async Task<ActionResult<ApiResponse<object>>> RestoreDepartment(int id)
        {
            try
            {
                var currentUserId = HttpContext.GetCurrentUserId();
                var result = await _departmentService.RestoreDepartmentAsync(id, currentUserId);
                if (!result)
                {
                    return NotFound(ApiResponse<object>.ErrorResponse("Department not found in archive"));
                }

                return Ok(ApiResponse<object>.SuccessResponse(null, "Department restored successfully"));
            }
            catch (Exception)
            {
                return StatusCode(500, ApiResponse<object>.ErrorResponse("An error occurred while restoring department"));
            }
        }

        [RequirePermission("PermanentDeleteDepartments")]
        [HttpDelete("{id}/permanent")]
        public async Task<ActionResult<ApiResponse<object>>> PermanentDeleteDepartment(int id)
        {
            try
            {
                var currentUserId = HttpContext.GetCurrentUserId();
                var result = await _departmentService.PermanentDeleteDepartmentAsync(id, currentUserId);
                if (!result)
                {
                    return NotFound(ApiResponse<object>.ErrorResponse("Department not found in archive"));
                }

                return Ok(ApiResponse<object>.SuccessResponse(null, "Department permanently deleted"));
            }
            catch (Exception)
            {
                return StatusCode(500, ApiResponse<object>.ErrorResponse("An error occurred while permanently deleting department"));
            }
        }
    }
}
