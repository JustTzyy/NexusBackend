using Microsoft.EntityFrameworkCore;
using NexUs.Data;
using NexUs.Models.DTO.Common;
using NexUs.Models.DTO.Marketing;
using NexUs.Models.DTO.Notifications;
using NexUs.Models.Entities;
using NexUs.Services.Interfaces;
using NexUs.Utilities;

namespace NexUs.Services
{
    public class CampaignService : ICampaignService
    {
        private readonly ApplicationDbContext _context;
        private readonly ISegmentService _segmentService;
        private readonly ISuppressionService _suppressionService;
        private readonly IEmailTemplateService _emailTemplateService;
        private readonly INotificationService _notificationService;

        public CampaignService(
            ApplicationDbContext context,
            ISegmentService segmentService,
            ISuppressionService suppressionService,
            IEmailTemplateService emailTemplateService,
            INotificationService notificationService)
        {
            _context = context;
            _segmentService = segmentService;
            _suppressionService = suppressionService;
            _emailTemplateService = emailTemplateService;
            _notificationService = notificationService;
        }

        private static CampaignListDto ToListDto(Campaign c) => new()
        {
            Id = c.Id, Name = c.Name, Subject = c.Subject,
            EmailTemplateId = c.EmailTemplateId, EmailTemplateName = c.EmailTemplate?.Name,
            SegmentId = c.SegmentId, SegmentName = c.Segment?.Name,
            Status = c.Status, ScheduledAt = c.ScheduledAt, SentAt = c.SentAt,
            TotalTargets = c.TotalTargets, SentCount = c.SentCount,
            FailedCount = c.FailedCount, SuppressedCount = c.SuppressedCount,
            CreatedAt = c.CreatedAt, UpdatedAt = c.UpdatedAt,
            CreatedByName = c.CreatedByUser != null ? $"{c.CreatedByUser.FirstName} {c.CreatedByUser.LastName}".Trim() : null,
            UpdatedByName = c.UpdatedByUser != null ? $"{c.UpdatedByUser.FirstName} {c.UpdatedByUser.LastName}".Trim() : null
        };

        private IQueryable<Campaign> BaseQuery() => _context.Campaigns
            .Include(c => c.EmailTemplate).Include(c => c.Segment)
            .Include(c => c.CreatedByUser).Include(c => c.UpdatedByUser);

        public async Task<PagedResultDto<CampaignListDto>> GetAllAsync(PaginationDto pagination, string? statusFilter = null)
        {
            var query = BaseQuery().Where(c => c.DeletedAt == null);
            if (!string.IsNullOrEmpty(statusFilter) && statusFilter != "all")
                query = query.Where(c => c.Status == statusFilter);
            if (!string.IsNullOrEmpty(pagination.SearchTerm))
            {
                var term = pagination.SearchTerm.ToLower();
                query = query.Where(c => c.Name.ToLower().Contains(term));
            }
            var totalCount = await query.CountAsync();
            var items = await query.OrderByDescending(c => c.CreatedAt)
                .Skip((pagination.PageNumber - 1) * pagination.PageSize).Take(pagination.PageSize).ToListAsync();
            return new PagedResultDto<CampaignListDto> { Items = items.Select(ToListDto).ToList(), TotalCount = totalCount, PageNumber = pagination.PageNumber, PageSize = pagination.PageSize };
        }

        public async Task<PagedResultDto<CampaignListDto>> GetArchivedAsync(PaginationDto pagination)
        {
            var query = BaseQuery().Where(c => c.DeletedAt != null);
            var totalCount = await query.CountAsync();
            var items = await query.OrderByDescending(c => c.DeletedAt)
                .Skip((pagination.PageNumber - 1) * pagination.PageSize).Take(pagination.PageSize).ToListAsync();
            return new PagedResultDto<CampaignListDto> { Items = items.Select(ToListDto).ToList(), TotalCount = totalCount, PageNumber = pagination.PageNumber, PageSize = pagination.PageSize };
        }

        public async Task<CampaignResponseDto?> GetByIdAsync(int id)
        {
            var c = await BaseQuery().FirstOrDefaultAsync(x => x.Id == id && x.DeletedAt == null);
            if (c == null) return null;
            var dto = ToListDto(c);
            return new CampaignResponseDto { Id = dto.Id, Name = dto.Name, Subject = dto.Subject, EmailTemplateId = dto.EmailTemplateId, EmailTemplateName = dto.EmailTemplateName, SegmentId = dto.SegmentId, SegmentName = dto.SegmentName, Status = dto.Status, ScheduledAt = dto.ScheduledAt, SentAt = dto.SentAt, TotalTargets = dto.TotalTargets, SentCount = dto.SentCount, FailedCount = dto.FailedCount, SuppressedCount = dto.SuppressedCount, CreatedAt = dto.CreatedAt, UpdatedAt = dto.UpdatedAt, CreatedByName = dto.CreatedByName, UpdatedByName = dto.UpdatedByName };
        }

        public async Task<CampaignResponseDto> CreateAsync(CreateCampaignDto dto, int? currentUserId)
        {
            var entity = new Campaign { Name = dto.Name, Subject = dto.Subject ?? string.Empty, EmailTemplateId = dto.EmailTemplateId, SegmentId = dto.SegmentId, Status = "Draft", CreatedBy = currentUserId, UpdatedBy = currentUserId };
            _context.Campaigns.Add(entity);
            await _context.SaveChangesAsync();
            return await GetByIdAsync(entity.Id) ?? throw new Exception("Failed to load campaign.");
        }

        public async Task<CampaignResponseDto?> UpdateAsync(int id, UpdateCampaignDto dto, int? currentUserId)
        {
            var entity = await _context.Campaigns.FindAsync(id);
            if (entity == null || entity.DeletedAt != null) return null;
            if (entity.Status != "Draft" && entity.Status != "Paused")
                throw new InvalidOperationException("Can only update Draft or Paused campaigns.");
            entity.Name = dto.Name; entity.Subject = dto.Subject ?? string.Empty; entity.EmailTemplateId = dto.EmailTemplateId; entity.SegmentId = dto.SegmentId; entity.UpdatedBy = currentUserId;
            await _context.SaveChangesAsync();
            return await GetByIdAsync(id);
        }

        public async Task<bool> DeleteAsync(int id, int? currentUserId)
        {
            var entity = await _context.Campaigns.FindAsync(id);
            if (entity == null || entity.DeletedAt != null) return false;
            entity.DeletedAt = DateTimeHelper.PhilippineNow; entity.UpdatedBy = currentUserId;
            await _context.SaveChangesAsync(); return true;
        }

        public async Task<bool> RestoreAsync(int id, int? currentUserId)
        {
            var entity = await _context.Campaigns.FindAsync(id);
            if (entity == null || entity.DeletedAt == null) return false;
            entity.DeletedAt = null; entity.UpdatedBy = currentUserId;
            await _context.SaveChangesAsync(); return true;
        }

        public async Task<bool> PermanentDeleteAsync(int id)
        {
            var entity = await _context.Campaigns.FindAsync(id);
            if (entity == null) return false;
            _context.Campaigns.Remove(entity); await _context.SaveChangesAsync(); return true;
        }

        public async Task<BuildTargetsResultDto> BuildTargetsAsync(int campaignId, int? currentUserId)
        {
            var campaign = await _context.Campaigns.FindAsync(campaignId)
                ?? throw new KeyNotFoundException("Campaign not found.");

            // Remove previous queued targets
            var existingTargets = await _context.CampaignTargets
                .Where(t => t.CampaignId == campaignId && t.Status == "Queued")
                .ToListAsync();
            _context.CampaignTargets.RemoveRange(existingTargets);

            List<(int? UserId, string Email, string FirstName, string LastName)> recipients;

            if (campaign.SegmentId.HasValue)
            {
                recipients = await _segmentService.EvaluateAsync(campaign.SegmentId.Value);
            }
            else
            {
                // All active users (leads + customers)
                var users = await _context.Users
                    .Where(u => u.DeletedAt == null)
                    .Include(u => u.UserRoles).ThenInclude(ur => ur.Role)
                    .Where(u => u.UserRoles.Any(ur => ur.Role.Name == "Lead" || ur.Role.Name == "Customer"))
                    .ToListAsync();
                recipients = users.Select(u => ((int?)u.Id, u.Email, u.FirstName, u.LastName)).ToList();
            }

            // Remove recipients with no email, then deduplicate
            recipients = recipients
                .Where(r => !string.IsNullOrWhiteSpace(r.Email))
                .GroupBy(r => r.Email.ToLower())
                .Select(g => g.First())
                .ToList();

            // Emails that already received a Sent message for this campaign — prevent duplicates
            var alreadySentEmails = (await _context.EmailMessages
                .Where(m => m.CampaignId == campaignId && m.Status == "Sent")
                .Select(m => m.RecipientEmail.ToLower())
                .ToListAsync()).ToHashSet();

            int suppressedCount = 0;
            int alreadySentCount = 0;
            int queuedCount = 0;
            var now = DateTime.UtcNow;

            foreach (var r in recipients)
            {
                var email = r.Email.ToLower();

                // Already received this campaign — auto-exclude (duplicate prevention)
                if (alreadySentEmails.Contains(email))
                {
                    _context.CampaignTargets.Add(new CampaignTarget
                    {
                        CampaignId = campaignId, UserId = r.UserId,
                        Email = email, FirstName = r.FirstName, LastName = r.LastName,
                        Status = "Sent", CreatedAt = now, UpdatedAt = now
                    });
                    alreadySentCount++;
                    continue;
                }

                var suppressed = await _suppressionService.IsSuppressedAsync(r.Email);
                _context.CampaignTargets.Add(new CampaignTarget
                {
                    CampaignId = campaignId,
                    UserId = r.UserId,
                    Email = email,
                    FirstName = r.FirstName,
                    LastName = r.LastName,
                    Status = suppressed ? "Suppressed" : "Queued",
                    CreatedAt = now,
                    UpdatedAt = now
                });
                if (suppressed) suppressedCount++;
                else queuedCount++;
            }

            campaign.TotalTargets = recipients.Count;
            campaign.SuppressedCount = suppressedCount;
            campaign.UpdatedBy = currentUserId;
            await _context.SaveChangesAsync();

            return new BuildTargetsResultDto { TotalTargets = recipients.Count, SuppressedCount = suppressedCount, AlreadySentCount = alreadySentCount, QueuedCount = queuedCount };
        }

        public async Task<bool> SendAsync(int campaignId, int? currentUserId)
        {
            var campaign = await _context.Campaigns.FindAsync(campaignId);
            if (campaign == null || campaign.DeletedAt != null) return false;

            campaign.Status = "Sending";
            campaign.UpdatedBy = currentUserId;

            // Immediately queue EmailMessages from targets so the background service
            // only needs to do the SMTP step — no waiting for the next 2-minute poll.
            var queuedTargets = await _context.CampaignTargets
                .Where(t => t.CampaignId == campaignId && t.Status == "Queued")
                .ToListAsync();

            var template = campaign.EmailTemplateId.HasValue
                ? await _context.EmailTemplates.FindAsync(campaign.EmailTemplateId.Value)
                : null;

            var now = DateTimeHelper.PhilippineNow;

            foreach (var target in queuedTargets)
            {
                var suppressed = await _suppressionService.IsSuppressedAsync(target.Email);
                if (suppressed)
                {
                    target.Status = "Suppressed";
                    target.UpdatedAt = now;
                    campaign.SuppressedCount++;
                    continue;
                }

                string subject = !string.IsNullOrEmpty(campaign.Subject)
                    ? campaign.Subject
                    : (template?.Subject ?? "");
                string body = $"[Template:{template?.FileName ?? ""}]";

                _context.EmailMessages.Add(new EmailMessage
                {
                    CampaignId = campaign.Id,
                    EmailTemplateId = campaign.EmailTemplateId,
                    RecipientUserId = target.UserId,
                    RecipientEmail = target.Email,
                    RecipientName = $"{target.FirstName} {target.LastName}".Trim(),
                    Subject = subject,
                    Body = body,
                    Status = "Queued",
                    QueuedAt = now,
                    CreatedAt = now,
                    UpdatedAt = now
                });

                target.Status = "Sending";
                target.UpdatedAt = now;
            }

            await _context.SaveChangesAsync();

            // Notify Marketing Manager: campaign is sending
            await _notificationService.CreateAsync(new CreateNotificationDto
            {
                RecipientRole = "Marketing Manager",
                Title = "Campaign Sending",
                Message = $"Campaign \"{campaign.Name}\" is now being sent to {queuedTargets.Count} recipients.",
                Type = "Marketing",
                Priority = "High",
                ReferenceId = campaignId,
                ReferenceType = "Campaign"
            }, currentUserId);

            return true;
        }

        public async Task<bool> ScheduleAsync(int campaignId, ScheduleCampaignDto dto, int? currentUserId)
        {
            var campaign = await _context.Campaigns.FindAsync(campaignId);
            if (campaign == null || campaign.DeletedAt != null) return false;
            campaign.Status = "Scheduled";
            campaign.ScheduledAt = dto.ScheduledAt;
            campaign.UpdatedBy = currentUserId;
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> CancelAsync(int campaignId, int? currentUserId)
        {
            var campaign = await _context.Campaigns.FindAsync(campaignId);
            if (campaign == null || campaign.DeletedAt != null) return false;
            campaign.Status = "Cancelled";
            campaign.UpdatedBy = currentUserId;
            await _context.SaveChangesAsync();

            // Notify Marketing Manager: campaign cancelled
            await _notificationService.CreateAsync(new CreateNotificationDto
            {
                RecipientRole = "Marketing Manager",
                Title = "Campaign Cancelled",
                Message = $"Campaign \"{campaign.Name}\" has been cancelled.",
                Type = "Marketing",
                Priority = "Normal",
                ReferenceId = campaignId,
                ReferenceType = "Campaign"
            }, currentUserId);

            return true;
        }

        public async Task<PagedResultDto<CampaignTargetListDto>> GetTargetsAsync(int campaignId, PaginationDto pagination)
        {
            var query = _context.CampaignTargets.Where(t => t.CampaignId == campaignId).AsQueryable();
            var totalCount = await query.CountAsync();
            var items = await query.OrderByDescending(t => t.CreatedAt)
                .Skip((pagination.PageNumber - 1) * pagination.PageSize).Take(pagination.PageSize).ToListAsync();

            return new PagedResultDto<CampaignTargetListDto>
            {
                Items = items.Select(t => new CampaignTargetListDto { Id = t.Id, CampaignId = t.CampaignId, UserId = t.UserId, Email = t.Email, FirstName = t.FirstName, LastName = t.LastName, Status = t.Status, CreatedAt = t.CreatedAt, UpdatedAt = t.UpdatedAt }).ToList(),
                TotalCount = totalCount, PageNumber = pagination.PageNumber, PageSize = pagination.PageSize
            };
        }
    }
}
