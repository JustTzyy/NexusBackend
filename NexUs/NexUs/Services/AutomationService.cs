using System.Text.Json;
using Microsoft.EntityFrameworkCore;
using NexUs.Data;
using NexUs.Models.DTO.Common;
using NexUs.Models.DTO.Marketing;
using NexUs.Models.Entities;
using NexUs.Services.Interfaces;
using NexUs.Utilities;

namespace NexUs.Services
{
    public class AutomationService : IAutomationService
    {
        private readonly ApplicationDbContext _context;
        private readonly IEmailTemplateService _emailTemplateService;
        private readonly IMarketingEmailService _marketingEmailService;

        public AutomationService(ApplicationDbContext context, IEmailTemplateService emailTemplateService, IMarketingEmailService marketingEmailService)
        {
            _context = context;
            _emailTemplateService = emailTemplateService;
            _marketingEmailService = marketingEmailService;
        }

        private static AutomationRuleListDto ToListDto(AutomationRule r) => new()
        {
            Id = r.Id, Name = r.Name, TriggerType = r.TriggerType, IsActive = r.IsActive,
            ActionsCount = r.Actions?.Count ?? 0,
            CreatedAt = r.CreatedAt, UpdatedAt = r.UpdatedAt,
            CreatedByName = r.CreatedByUser != null ? $"{r.CreatedByUser.FirstName} {r.CreatedByUser.LastName}".Trim() : null,
            UpdatedByName = r.UpdatedByUser != null ? $"{r.UpdatedByUser.FirstName} {r.UpdatedByUser.LastName}".Trim() : null
        };

        private static AutomationActionDto ToActionDto(AutomationAction a) => new()
        {
            Id = a.Id, AutomationRuleId = a.AutomationRuleId, ActionType = a.ActionType,
            EmailTemplateId = a.EmailTemplateId, EmailTemplateName = a.EmailTemplate?.Name,
            DelayMinutes = a.DelayMinutes, SortOrder = a.SortOrder, IsActive = a.IsActive
        };

        private static AutomationRuleResponseDto ToResponseDto(AutomationRule r) => new()
        {
            Id = r.Id, Name = r.Name, TriggerType = r.TriggerType, ConditionsJson = r.ConditionsJson,
            IsActive = r.IsActive,
            Actions = r.Actions?.Select(ToActionDto).OrderBy(a => a.SortOrder).ToList() ?? [],
            CreatedAt = r.CreatedAt, UpdatedAt = r.UpdatedAt,
            CreatedByName = r.CreatedByUser != null ? $"{r.CreatedByUser.FirstName} {r.CreatedByUser.LastName}".Trim() : null,
            UpdatedByName = r.UpdatedByUser != null ? $"{r.UpdatedByUser.FirstName} {r.UpdatedByUser.LastName}".Trim() : null
        };

        private IQueryable<AutomationRule> BaseQuery() => _context.AutomationRules
            .Include(r => r.Actions).ThenInclude(a => a.EmailTemplate)
            .Include(r => r.CreatedByUser).Include(r => r.UpdatedByUser);

        public async Task<PagedResultDto<AutomationRuleListDto>> GetAllAsync(PaginationDto pagination)
        {
            var query = BaseQuery().Where(r => r.DeletedAt == null);
            if (!string.IsNullOrEmpty(pagination.SearchTerm))
            {
                var term = pagination.SearchTerm.ToLower();
                query = query.Where(r => r.Name.ToLower().Contains(term));
            }
            var totalCount = await query.CountAsync();
            var items = await query.OrderByDescending(r => r.CreatedAt)
                .Skip((pagination.PageNumber - 1) * pagination.PageSize).Take(pagination.PageSize).ToListAsync();
            return new PagedResultDto<AutomationRuleListDto> { Items = items.Select(ToListDto).ToList(), TotalCount = totalCount, PageNumber = pagination.PageNumber, PageSize = pagination.PageSize };
        }

        public async Task<AutomationRuleResponseDto?> GetByIdAsync(int id)
        {
            var r = await BaseQuery().FirstOrDefaultAsync(x => x.Id == id && x.DeletedAt == null);
            return r == null ? null : ToResponseDto(r);
        }

        public async Task<AutomationRuleResponseDto> CreateAsync(CreateAutomationRuleDto dto, int? currentUserId)
        {
            var entity = new AutomationRule { Name = dto.Name, TriggerType = dto.TriggerType, ConditionsJson = dto.ConditionsJson, IsActive = dto.IsActive, CreatedBy = currentUserId, UpdatedBy = currentUserId };
            _context.AutomationRules.Add(entity);
            await _context.SaveChangesAsync();

            foreach (var actionDto in dto.Actions.OrderBy(a => a.SortOrder))
            {
                _context.AutomationActions.Add(new AutomationAction { AutomationRuleId = entity.Id, ActionType = actionDto.ActionType, EmailTemplateId = actionDto.EmailTemplateId, DelayMinutes = actionDto.DelayMinutes, SortOrder = actionDto.SortOrder, IsActive = actionDto.IsActive, CreatedBy = currentUserId, UpdatedBy = currentUserId });
            }
            if (dto.Actions.Any()) await _context.SaveChangesAsync();

            return await GetByIdAsync(entity.Id) ?? throw new Exception("Failed to load rule.");
        }

        public async Task<AutomationRuleResponseDto?> UpdateAsync(int id, UpdateAutomationRuleDto dto, int? currentUserId)
        {
            var entity = await _context.AutomationRules.FindAsync(id);
            if (entity == null || entity.DeletedAt != null) return null;
            entity.Name = dto.Name; entity.TriggerType = dto.TriggerType; entity.ConditionsJson = dto.ConditionsJson; entity.IsActive = dto.IsActive; entity.UpdatedBy = currentUserId;
            await _context.SaveChangesAsync();
            return await GetByIdAsync(id);
        }

        public async Task<bool> DeleteAsync(int id, int? currentUserId)
        {
            var entity = await _context.AutomationRules.FindAsync(id);
            if (entity == null || entity.DeletedAt != null) return false;
            entity.DeletedAt = DateTimeHelper.PhilippineNow; entity.UpdatedBy = currentUserId;
            await _context.SaveChangesAsync(); return true;
        }

        public async Task<PagedResultDto<AutomationRuleListDto>> GetArchivedAsync(PaginationDto pagination)
        {
            var query = BaseQuery().Where(r => r.DeletedAt != null);
            if (!string.IsNullOrEmpty(pagination.SearchTerm))
            {
                var term = pagination.SearchTerm.ToLower();
                query = query.Where(r => r.Name.ToLower().Contains(term));
            }
            var totalCount = await query.CountAsync();
            var items = await query.OrderByDescending(r => r.DeletedAt)
                .Skip((pagination.PageNumber - 1) * pagination.PageSize).Take(pagination.PageSize).ToListAsync();
            return new PagedResultDto<AutomationRuleListDto> { Items = items.Select(ToListDto).ToList(), TotalCount = totalCount, PageNumber = pagination.PageNumber, PageSize = pagination.PageSize };
        }

        public async Task<bool> RestoreAsync(int id, int? currentUserId)
        {
            var entity = await _context.AutomationRules.FindAsync(id);
            if (entity == null || entity.DeletedAt == null) return false;
            entity.DeletedAt = null; entity.UpdatedBy = currentUserId;
            await _context.SaveChangesAsync(); return true;
        }

        public async Task<bool> PermanentDeleteAsync(int id)
        {
            var entity = await _context.AutomationRules.Include(r => r.Actions).FirstOrDefaultAsync(r => r.Id == id && r.DeletedAt != null);
            if (entity == null) return false;
            _context.AutomationActions.RemoveRange(entity.Actions);
            _context.AutomationRules.Remove(entity);
            await _context.SaveChangesAsync(); return true;
        }

        public async Task<bool> ActivateAsync(int id, int? currentUserId)
        {
            var entity = await _context.AutomationRules.FindAsync(id);
            if (entity == null) return false;
            entity.IsActive = true; entity.UpdatedBy = currentUserId;
            await _context.SaveChangesAsync(); return true;
        }

        public async Task<bool> DeactivateAsync(int id, int? currentUserId)
        {
            var entity = await _context.AutomationRules.FindAsync(id);
            if (entity == null) return false;
            entity.IsActive = false; entity.UpdatedBy = currentUserId;
            await _context.SaveChangesAsync(); return true;
        }

        public async Task<AutomationActionDto> AddActionAsync(int ruleId, CreateAutomationActionDto dto, int? currentUserId)
        {
            var action = new AutomationAction { AutomationRuleId = ruleId, ActionType = dto.ActionType, EmailTemplateId = dto.EmailTemplateId, DelayMinutes = dto.DelayMinutes, SortOrder = dto.SortOrder, IsActive = dto.IsActive, CreatedBy = currentUserId, UpdatedBy = currentUserId };
            _context.AutomationActions.Add(action);
            await _context.SaveChangesAsync();
            var loaded = await _context.AutomationActions.Include(a => a.EmailTemplate).FirstAsync(a => a.Id == action.Id);
            return ToActionDto(loaded);
        }

        public async Task<AutomationActionDto?> UpdateActionAsync(int ruleId, int actionId, CreateAutomationActionDto dto, int? currentUserId)
        {
            var action = await _context.AutomationActions.Include(a => a.EmailTemplate).FirstOrDefaultAsync(a => a.Id == actionId && a.AutomationRuleId == ruleId);
            if (action == null) return null;
            action.ActionType = dto.ActionType; action.EmailTemplateId = dto.EmailTemplateId; action.DelayMinutes = dto.DelayMinutes; action.SortOrder = dto.SortOrder; action.IsActive = dto.IsActive; action.UpdatedBy = currentUserId;
            await _context.SaveChangesAsync();
            return ToActionDto(action);
        }

        public async Task<bool> DeleteActionAsync(int ruleId, int actionId)
        {
            var action = await _context.AutomationActions.FirstOrDefaultAsync(a => a.Id == actionId && a.AutomationRuleId == ruleId);
            if (action == null) return false;
            _context.AutomationActions.Remove(action); await _context.SaveChangesAsync(); return true;
        }

        // Core logic: queue email messages and return their IDs.
        private async Task<List<int>> TriggerCoreAsync(string triggerType, Dictionary<string, object> context)
        {
            var rules = await _context.AutomationRules
                .Where(r => r.TriggerType == triggerType && r.IsActive && r.DeletedAt == null)
                .Include(r => r.Actions.Where(a => a.IsActive))
                .ToListAsync();

            if (!rules.Any()) return [];

            // Extract routing values from context
            context.TryGetValue("Email", out var emailObj);
            context.TryGetValue("RecipientName", out var recipientNameObj);
            context.TryGetValue("FirstName", out var firstNameObj);
            context.TryGetValue("UserId", out var userIdObj);

            string recipientEmail = emailObj?.ToString() ?? string.Empty;
            string recipientName = (recipientNameObj ?? firstNameObj)?.ToString() ?? string.Empty;
            int? recipientUserId = userIdObj != null ? Convert.ToInt32(userIdObj) : null;

            if (recipientUserId.HasValue)
            {
                var user = await _context.Users.FindAsync(recipientUserId.Value);

                // Skip archived/soft-deleted user accounts — they are no longer active
                if (user == null || user.DeletedAt != null) return [];

                if (string.IsNullOrEmpty(recipientEmail))
                    recipientEmail = user.Email;
                if (string.IsNullOrEmpty(recipientName))
                    recipientName = $"{user.FirstName} {user.LastName}".Trim();
            }

            if (string.IsNullOrEmpty(recipientEmail)) return [];

            var suppressed = await _context.Suppressions.AnyAsync(s => s.Email.ToLower() == recipientEmail.ToLower() && s.DeletedAt == null);
            if (suppressed) return [];

            // ── Completed-requirement guards ────────────────────────────────────────
            // LeadCreated: skip if the user has already been converted to a Customer
            if (triggerType == "LeadCreated" && recipientUserId.HasValue)
            {
                var isAlreadyCustomer = await _context.UserRoles
                    .Include(ur => ur.Role)
                    .AnyAsync(ur => ur.UserId == recipientUserId.Value && ur.Role.Name == "Customer");
                if (isAlreadyCustomer) return [];
            }

            // SessionReminder: skip if the tutoring request is already Cancelled or Completed
            if (triggerType == "SessionReminder" && context.TryGetValue("TutoringRequestId", out var trIdObj))
            {
                var trId = Convert.ToInt32(trIdObj);
                var sessionStatus = await _context.TutoringRequests
                    .Where(r => r.Id == trId)
                    .Select(r => r.Status)
                    .FirstOrDefaultAsync();
                if (sessionStatus == "Cancelled by Admin" || sessionStatus == "Cancelled by Student" || sessionStatus == "Completed")
                    return [];
            }
            // ────────────────────────────────────────────────────────────────────────

            // Store all context values as JSON for template token replacement
            var variablesJson = JsonSerializer.Serialize(context.ToDictionary(k => k.Key, v => v.Value?.ToString() ?? ""));

            var messages = new List<EmailMessage>();
            foreach (var rule in rules)
            {
                foreach (var action in rule.Actions.OrderBy(a => a.SortOrder))
                {
                    if (action.ActionType != "SendEmail" || !action.EmailTemplateId.HasValue) continue;

                    var template = await _context.EmailTemplates.FindAsync(action.EmailTemplateId.Value);
                    if (template == null || !template.IsActive) continue;

                    var now = DateTime.UtcNow;
                    var msg = new EmailMessage
                    {
                        AutomationRuleId = rule.Id,
                        EmailTemplateId = template.Id,
                        RecipientUserId = recipientUserId,
                        RecipientEmail = recipientEmail.ToLower(),
                        RecipientName = recipientName,
                        Subject = template.Subject,
                        Body = $"[Template:{template.FileName}]",
                        VariablesJson = variablesJson,
                        Status = "Queued",
                        QueuedAt = now,
                        CreatedAt = now,
                        UpdatedAt = now
                    };
                    _context.EmailMessages.Add(msg);
                    messages.Add(msg);
                }
            }

            if (messages.Count > 0) await _context.SaveChangesAsync();
            return messages.Select(m => m.Id).ToList();
        }

        public async Task TriggerAsync(string triggerType, Dictionary<string, object> context)
            => await TriggerCoreAsync(triggerType, context);

        public async Task<bool> TriggerAndSendImmediatelyAsync(string triggerType, Dictionary<string, object> context)
        {
            var messageIds = await TriggerCoreAsync(triggerType, context);
            if (messageIds.Count == 0) return false;

            bool allSent = true;
            foreach (var id in messageIds)
            {
                var sent = await _marketingEmailService.SendAsync(id);
                if (!sent) allSent = false;
            }
            return allSent;
        }
    }
}
