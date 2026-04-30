using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using NexUs.Attributes;
using NexUs.Models.DTO.Common;
using NexUs.Models.DTO.Marketing;
using NexUs.Services.Interfaces;

namespace NexUs.Controllers
{
    [Route("api/customer")]
    [ApiController]
    [Authorize]
    public class CustomerController : ControllerBase
    {
        private readonly ICustomerService _service;
        public CustomerController(ICustomerService service) => _service = service;

        [RequirePermission("ViewCustomers")]
        [HttpGet]
        public async Task<ActionResult<ApiResponse<PagedResultDto<CustomerListDto>>>> GetAll([FromQuery] PaginationDto pagination)
        {
            try { return Ok(ApiResponse<PagedResultDto<CustomerListDto>>.SuccessResponse(await _service.GetAllAsync(pagination), "Customers retrieved")); }
            catch (Exception) { return StatusCode(500, ApiResponse<PagedResultDto<CustomerListDto>>.ErrorResponse("Error")); }
        }

        [RequirePermission("ViewCustomers")]
        [HttpGet("{id:int}")]
        public async Task<ActionResult<ApiResponse<CustomerResponseDto>>> GetById(int id)
        {
            try
            {
                var result = await _service.GetByIdAsync(id);
                if (result == null) return NotFound(ApiResponse<CustomerResponseDto>.ErrorResponse("Customer not found"));
                return Ok(ApiResponse<CustomerResponseDto>.SuccessResponse(result, "Customer retrieved"));
            }
            catch (Exception) { return StatusCode(500, ApiResponse<CustomerResponseDto>.ErrorResponse("Error")); }
        }
    }
}
