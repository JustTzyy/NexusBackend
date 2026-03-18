using NexUs.Models.DTO.Common;
using NexUs.Models.DTO.Marketing;

namespace NexUs.Services.Interfaces
{
    public interface IAutomationService
    {
        Task<PagedResultDto<AutomationRuleListDto>> GetAllAsync(PaginationDto pagination);
        Task<AutomationRuleResponseDto?> GetByIdAsync(int id);
        Task<AutomationRuleResponseDto> CreateAsync(CreateAutomationRuleDto dto, int? currentUserId);
        Task<AutomationRuleResponseDto?> UpdateAsync(int id, UpdateAutomationRuleDto dto, int? currentUserId);
        Task<bool> DeleteAsync(int id, int? currentUserId);
        Task<PagedResultDto<AutomationRuleListDto>> GetArchivedAsync(PaginationDto pagination);
        Task<bool> RestoreAsync(int id, int? currentUserId);
        Task<bool> PermanentDeleteAsync(int id);
        Task<bool> ActivateAsync(int id, int? currentUserId);
        Task<bool> DeactivateAsync(int id, int? currentUserId);
        Task<AutomationActionDto> AddActionAsync(int ruleId, CreateAutomationActionDto dto, int? currentUserId);
        Task<AutomationActionDto?> UpdateActionAsync(int ruleId, int actionId, CreateAutomationActionDto dto, int? currentUserId);
        Task<bool> DeleteActionAsync(int ruleId, int actionId);
        Task TriggerAsync(string triggerType, Dictionary<string, object> context);
        /// <summary>Queues email(s) for the trigger AND sends them immediately — no background queue wait.</summary>
        Task<bool> TriggerAndSendImmediatelyAsync(string triggerType, Dictionary<string, object> context);
    }
}
