using Microsoft.EntityFrameworkCore;
using NexUs.Data;
using NexUs.Models.DTO.Common;
using NexUs.Models.DTO.Marketing;
using NexUs.Services.Interfaces;

namespace NexUs.Services
{
    public class EmailMessageService : IEmailMessageService
    {
        private readonly ApplicationDbContext _context;

        public EmailMessageService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<PagedResultDto<EmailMessageListDto>> GetAllAsync(PaginationDto pagination, string? statusFilter = null, int? campaignId = null)
        {
            var query = _context.EmailMessages
                .Include(m => m.Campaign)
                .Include(m => m.AutomationRule)
                .AsQueryable();

            if (!string.IsNullOrEmpty(statusFilter) && statusFilter != "all")
                query = query.Where(m => m.Status == statusFilter);

            if (campaignId.HasValue)
                query = query.Where(m => m.CampaignId == campaignId);

            if (pagination.FromDate.HasValue)
                query = query.Where(m => m.CreatedAt >= pagination.FromDate.Value);

            if (pagination.ToDate.HasValue)
                query = query.Where(m => m.CreatedAt <= pagination.ToDate.Value);

            if (!string.IsNullOrEmpty(pagination.SearchTerm))
            {
                var term = pagination.SearchTerm.ToLower();
                query = query.Where(m => m.RecipientEmail.ToLower().Contains(term) || m.Subject.ToLower().Contains(term));
            }

            var totalCount = await query.CountAsync();
            var items = await query.OrderByDescending(m => m.CreatedAt)
                .Skip((pagination.PageNumber - 1) * pagination.PageSize)
                .Take(pagination.PageSize)
                .ToListAsync();

            return new PagedResultDto<EmailMessageListDto>
            {
                Items = items.Select(m => new EmailMessageListDto
                {
                    Id = m.Id,
                    CampaignId = m.CampaignId,
                    CampaignName = m.Campaign?.Name,
                    AutomationRuleId = m.AutomationRuleId,
                    AutomationRuleName = m.AutomationRule?.Name,
                    RecipientEmail = m.RecipientEmail,
                    RecipientName = m.RecipientName,
                    Subject = m.Subject,
                    Status = m.Status,
                    QueuedAt = m.QueuedAt,
                    SentAt = m.SentAt,
                    FailedAt = m.FailedAt,
                    ErrorMessage = m.ErrorMessage,
                    RetryCount = m.RetryCount,
                    CreatedAt = m.CreatedAt
                }).ToList(),
                TotalCount = totalCount,
                PageNumber = pagination.PageNumber,
                PageSize = pagination.PageSize
            };
        }

        public async Task<EmailMessageResponseDto?> GetByIdAsync(int id)
        {
            var m = await _context.EmailMessages
                .Include(x => x.Campaign)
                .Include(x => x.AutomationRule)
                .Include(x => x.EmailEvents)
                .FirstOrDefaultAsync(x => x.Id == id);

            if (m == null) return null;

            return new EmailMessageResponseDto
            {
                Id = m.Id,
                CampaignId = m.CampaignId,
                CampaignName = m.Campaign?.Name,
                AutomationRuleId = m.AutomationRuleId,
                AutomationRuleName = m.AutomationRule?.Name,
                RecipientEmail = m.RecipientEmail,
                RecipientName = m.RecipientName,
                Subject = m.Subject,
                Status = m.Status,
                QueuedAt = m.QueuedAt,
                SentAt = m.SentAt,
                FailedAt = m.FailedAt,
                ErrorMessage = m.ErrorMessage,
                RetryCount = m.RetryCount,
                CreatedAt = m.CreatedAt,
                Events = m.EmailEvents.OrderBy(e => e.OccurredAt).Select(e => new EmailEventDto
                {
                    Id = e.Id,
                    EventType = e.EventType,
                    Notes = e.Notes,
                    OccurredAt = e.OccurredAt
                }).ToList()
            };
        }

        public async Task<List<EmailEventDto>> GetEventsAsync(int emailMessageId)
        {
            return await _context.EmailEvents
                .Where(e => e.EmailMessageId == emailMessageId)
                .OrderBy(e => e.OccurredAt)
                .Select(e => new EmailEventDto { Id = e.Id, EventType = e.EventType, Notes = e.Notes, OccurredAt = e.OccurredAt })
                .ToListAsync();
        }
    }
}
