using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using NexUs.Attributes;
using NexUs.Extensions;
using NexUs.Models.DTO.Common;
using NexUs.Models.DTO.Marketing;
using NexUs.Services.Interfaces;

namespace NexUs.Controllers
{
    [Route("api/suppression")]
    [ApiController]
    [Authorize]
    public class SuppressionController : ControllerBase
    {
        private readonly ISuppressionService _service;
        public SuppressionController(ISuppressionService service) => _service = service;

        [RequirePermission("ViewSuppressions")]
        [HttpGet]
        public async Task<ActionResult<ApiResponse<PagedResultDto<SuppressionListDto>>>> GetAll([FromQuery] PaginationDto pagination)
        {
            try { return Ok(ApiResponse<PagedResultDto<SuppressionListDto>>.SuccessResponse(await _service.GetAllAsync(pagination), "Suppressions retrieved")); }
            catch (Exception ex) { return StatusCode(500, ApiResponse<PagedResultDto<SuppressionListDto>>.ErrorResponse("Error", new List<string> { ex.Message })); }
        }

        [RequirePermission("ViewSuppressions")]
        [HttpGet("{id:int}")]
        public async Task<ActionResult<ApiResponse<SuppressionListDto>>> GetById(int id)
        {
            try
            {
                var result = await _service.GetByIdAsync(id);
                if (result == null) return NotFound(ApiResponse<SuppressionListDto>.ErrorResponse("Suppression not found"));
                return Ok(ApiResponse<SuppressionListDto>.SuccessResponse(result, "Suppression retrieved"));
            }
            catch (Exception ex) { return StatusCode(500, ApiResponse<SuppressionListDto>.ErrorResponse("Error", new List<string> { ex.Message })); }
        }

        [RequirePermission("ManageSuppressions")]
        [HttpPost]
        public async Task<ActionResult<ApiResponse<SuppressionListDto>>> Create([FromBody] CreateSuppressionDto dto)
        {
            try
            {
                var userId = HttpContext.GetCurrentUserId();
                var result = await _service.CreateAsync(dto, userId);
                return Ok(ApiResponse<SuppressionListDto>.SuccessResponse(result, "Suppression added"));
            }
            catch (InvalidOperationException ex) { return BadRequest(ApiResponse<SuppressionListDto>.ErrorResponse(ex.Message)); }
            catch (Exception ex) { return StatusCode(500, ApiResponse<SuppressionListDto>.ErrorResponse("Error", new List<string> { ex.Message })); }
        }

        [RequirePermission("ManageSuppressions")]
        [HttpDelete("{id:int}")]
        public async Task<ActionResult<ApiResponse<bool>>> Delete(int id)
        {
            try
            {
                if (!await _service.DeleteAsync(id)) return NotFound(ApiResponse<bool>.ErrorResponse("Suppression not found"));
                return Ok(ApiResponse<bool>.SuccessResponse(true, "Suppression removed"));
            }
            catch (Exception ex) { return StatusCode(500, ApiResponse<bool>.ErrorResponse("Error", new List<string> { ex.Message })); }
        }

        [HttpPost("check")]
        [AllowAnonymous]
        public async Task<ActionResult<ApiResponse<SuppressionCheckResultDto>>> Check([FromBody] SuppressionCheckDto dto)
        {
            try
            {
                var suppressed = await _service.IsSuppressedAsync(dto.Email);
                return Ok(ApiResponse<SuppressionCheckResultDto>.SuccessResponse(
                    new SuppressionCheckResultDto { Suppressed = suppressed }, "Check complete"));
            }
            catch (Exception ex) { return StatusCode(500, ApiResponse<SuppressionCheckResultDto>.ErrorResponse("Error", new List<string> { ex.Message })); }
        }

        [HttpGet("unsubscribe")]
        [AllowAnonymous]
        public async Task<IActionResult> Unsubscribe([FromQuery] string email, [FromQuery] string token, [FromServices] IConfiguration config)
        {
            try
            {
                var secret = config["ApplicationSettings:UnsubscribeSecret"] ?? "nexus-unsubscribe-secret";
                var expected = ComputeHmac(email, secret);
                if (!string.Equals(token, expected, StringComparison.OrdinalIgnoreCase))
                    return BadRequest("Invalid unsubscribe token.");

                await _service.EnsureSuppressedAsync(email, "Unsubscribed", "Link");
                return Ok("You have been successfully unsubscribed.");
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Unsubscribe failed: {ex.Message}");
            }
        }

        private static string ComputeHmac(string data, string key)
        {
            using var hmac = new System.Security.Cryptography.HMACSHA256(
                System.Text.Encoding.UTF8.GetBytes(key));
            var hash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(data));
            return Convert.ToHexString(hash).ToLower();
        }
    }
}
