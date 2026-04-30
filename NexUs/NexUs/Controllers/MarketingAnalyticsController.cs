using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using NexUs.Models.DTO.Common;
using NexUs.Models.DTO.Marketing;
using NexUs.Services.Interfaces;

namespace NexUs.Controllers
{
    [Route("api/marketing/analytics")]
    [ApiController]
    [Authorize(Roles = "Super Admin,Admin,Marketing Manager,Marketing Staff")]
    public class MarketingAnalyticsController : ControllerBase
    {
        private readonly IMarketingAnalyticsService _service;
        public MarketingAnalyticsController(IMarketingAnalyticsService service) => _service = service;

        [HttpGet("overview")]
        public async Task<ActionResult<ApiResponse<MarketingOverviewDto>>> GetOverview(
            [FromQuery] DateTime? fromDate = null, [FromQuery] DateTime? toDate = null)
        {
            try { return Ok(ApiResponse<MarketingOverviewDto>.SuccessResponse(await _service.GetOverviewAsync(fromDate, toDate), "Overview retrieved")); }
            catch (Exception) { return StatusCode(500, ApiResponse<MarketingOverviewDto>.ErrorResponse("Error")); }
        }

        [HttpGet("campaigns")]
        public async Task<ActionResult<ApiResponse<List<CampaignStatsDto>>>> GetCampaigns()
        {
            try { return Ok(ApiResponse<List<CampaignStatsDto>>.SuccessResponse(await _service.GetCampaignStatsAsync(), "Campaign stats retrieved")); }
            catch (Exception) { return StatusCode(500, ApiResponse<List<CampaignStatsDto>>.ErrorResponse("Error")); }
        }

        [HttpGet("email-performance")]
        public async Task<ActionResult<ApiResponse<List<EmailPerformanceDto>>>> GetEmailPerformance(
            [FromQuery] DateTime? fromDate, [FromQuery] DateTime? toDate, [FromQuery] string groupBy = "day")
        {
            try { return Ok(ApiResponse<List<EmailPerformanceDto>>.SuccessResponse(await _service.GetEmailPerformanceAsync(fromDate, toDate, groupBy), "Performance data retrieved")); }
            catch (Exception) { return StatusCode(500, ApiResponse<List<EmailPerformanceDto>>.ErrorResponse("Error")); }
        }

        [HttpGet("lead-pipeline")]
        public async Task<ActionResult<ApiResponse<List<LeadPipelineDto>>>> GetLeadPipeline()
        {
            try { return Ok(ApiResponse<List<LeadPipelineDto>>.SuccessResponse(await _service.GetLeadPipelineAsync(), "Pipeline data retrieved")); }
            catch (Exception) { return StatusCode(500, ApiResponse<List<LeadPipelineDto>>.ErrorResponse("Error")); }
        }
    }
}
