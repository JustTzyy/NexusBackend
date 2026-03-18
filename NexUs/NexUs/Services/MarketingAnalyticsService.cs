using Microsoft.EntityFrameworkCore;
using NexUs.Data;
using NexUs.Models.DTO.Marketing;
using NexUs.Services.Interfaces;

namespace NexUs.Services
{
    public class MarketingAnalyticsService : IMarketingAnalyticsService
    {
        private readonly ApplicationDbContext _context;

        public MarketingAnalyticsService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<MarketingOverviewDto> GetOverviewAsync(DateTime? fromDate = null, DateTime? toDate = null)
        {
            var hasDateFilter = fromDate.HasValue || toDate.HasValue;
            var rangeStart = fromDate?.Date ?? DateTime.MinValue;
            var rangeEnd = toDate.HasValue ? toDate.Value.Date.AddDays(1).AddTicks(-1) : DateTime.MaxValue;

            var totalLeads = hasDateFilter
                ? await _context.Leads.CountAsync(l => l.DeletedAt == null && l.CreatedAt >= rangeStart && l.CreatedAt <= rangeEnd)
                : await _context.Leads.CountAsync(l => l.DeletedAt == null);
            var totalCustomers = hasDateFilter
                ? await _context.Customers.CountAsync(c => c.DeletedAt == null && c.CreatedAt >= rangeStart && c.CreatedAt <= rangeEnd)
                : await _context.Customers.CountAsync(c => c.DeletedAt == null);
            var totalCampaigns = hasDateFilter
                ? await _context.Campaigns.CountAsync(c => c.DeletedAt == null && c.CreatedAt >= rangeStart && c.CreatedAt <= rangeEnd)
                : await _context.Campaigns.CountAsync(c => c.DeletedAt == null);
            var emailQuery = _context.EmailMessages.Where(m => m.Status == "Sent" || m.Status == "Failed");
            if (hasDateFilter) emailQuery = emailQuery.Where(m => m.CreatedAt >= rangeStart && m.CreatedAt <= rangeEnd);
            var totalSent = await emailQuery.CountAsync(m => m.Status == "Sent");
            var totalFailed = await emailQuery.CountAsync(m => m.Status == "Failed");
            var totalProcessed = totalSent + totalFailed;

            return new MarketingOverviewDto
            {
                TotalLeads = totalLeads,
                TotalCustomers = totalCustomers,
                ConversionRate = totalLeads > 0 ? Math.Round((double)totalCustomers / totalLeads * 100, 1) : 0,
                TotalCampaigns = totalCampaigns,
                TotalEmailsSent = totalSent,
                TotalEmailsFailed = totalFailed,
                SendSuccessRate = totalProcessed > 0 ? Math.Round((double)totalSent / totalProcessed * 100, 1) : 0
            };
        }

        public async Task<List<CampaignStatsDto>> GetCampaignStatsAsync()
        {
            return await _context.Campaigns
                .Where(c => c.DeletedAt == null)
                .OrderByDescending(c => c.CreatedAt)
                .Select(c => new CampaignStatsDto
                {
                    Id = c.Id,
                    Name = c.Name,
                    Status = c.Status,
                    TotalTargets = c.TotalTargets,
                    SentCount = c.SentCount,
                    FailedCount = c.FailedCount,
                    SuppressedCount = c.SuppressedCount,
                    SentAt = c.SentAt
                })
                .ToListAsync();
        }

        public async Task<List<EmailPerformanceDto>> GetEmailPerformanceAsync(DateTime? fromDate, DateTime? toDate, string groupBy = "day")
        {
            var query = _context.EmailMessages.AsQueryable();
            if (fromDate.HasValue) query = query.Where(m => m.CreatedAt >= fromDate.Value);
            if (toDate.HasValue) query = query.Where(m => m.CreatedAt <= toDate.Value);

            var messages = await query.Where(m => m.Status == "Sent" || m.Status == "Failed")
                .Select(m => new { m.CreatedAt, m.Status })
                .ToListAsync();

            IEnumerable<EmailPerformanceDto> result;

            if (groupBy == "week")
            {
                result = messages
                    .GroupBy(m => $"{m.CreatedAt.Year}-W{System.Globalization.ISOWeek.GetWeekOfYear(m.CreatedAt):D2}")
                    .Select(g => new EmailPerformanceDto
                    {
                        Period = g.Key,
                        Sent = g.Count(x => x.Status == "Sent"),
                        Failed = g.Count(x => x.Status == "Failed")
                    });
            }
            else
            {
                result = messages
                    .GroupBy(m => m.CreatedAt.ToString("yyyy-MM-dd"))
                    .Select(g => new EmailPerformanceDto
                    {
                        Period = g.Key,
                        Sent = g.Count(x => x.Status == "Sent"),
                        Failed = g.Count(x => x.Status == "Failed")
                    });
            }

            return result.OrderBy(r => r.Period).ToList();
        }

        public async Task<List<LeadPipelineDto>> GetLeadPipelineAsync()
        {
            return await _context.Leads
                .Where(l => l.DeletedAt == null)
                .GroupBy(l => l.Status)
                .Select(g => new LeadPipelineDto { Status = g.Key, Count = g.Count() })
                .ToListAsync();
        }
    }
}
