using NexUs.Models.DTO.Marketing;

namespace NexUs.Services.Interfaces
{
    public interface IMarketingAnalyticsService
    {
        Task<MarketingOverviewDto> GetOverviewAsync(DateTime? fromDate = null, DateTime? toDate = null);
        Task<List<CampaignStatsDto>> GetCampaignStatsAsync();
        Task<List<EmailPerformanceDto>> GetEmailPerformanceAsync(DateTime? fromDate, DateTime? toDate, string groupBy = "day");
        Task<List<LeadPipelineDto>> GetLeadPipelineAsync();
    }
}
