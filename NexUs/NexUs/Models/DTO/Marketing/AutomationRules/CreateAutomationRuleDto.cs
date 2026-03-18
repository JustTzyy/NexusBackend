namespace NexUs.Models.DTO.Marketing
{
    public class CreateAutomationRuleDto
    {
        public string Name { get; set; } = string.Empty;
        public string TriggerType { get; set; } = string.Empty;
        public string? ConditionsJson { get; set; }
        public bool IsActive { get; set; } = true;
        public List<CreateAutomationActionDto> Actions { get; set; } = [];
    }
}
