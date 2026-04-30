using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using NexUs.Models.DTO.Common;
using NexUs.Services.Interfaces;

namespace NexUs.Controllers
{
    [Route("api/address")]
    [ApiController]
    [Authorize]
    public class AddressesController : ControllerBase
    {
        private readonly IAddressService _addressService;

        public AddressesController(IAddressService addressService)
        {
            _addressService = addressService;
        }

        [HttpPost]
        public async Task<ActionResult<ApiResponse<int>>> CreateAddress([FromBody] CreateAddressDto dto)
        {
            try
            {
                var id = await _addressService.CreateAddressAsync(dto);
                return CreatedAtAction(nameof(CreateAddress), new { id }, ApiResponse<int>.SuccessResponse(id, "Address created successfully"));
            }
            catch (Exception)
            {
                return StatusCode(500, ApiResponse<int>.ErrorResponse("An unexpected error occurred"));
            }
        }
    }
}
