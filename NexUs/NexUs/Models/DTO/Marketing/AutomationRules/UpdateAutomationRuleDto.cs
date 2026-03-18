namespace NexUs.Models.DTO.Marketing
{
    public class UpdateAutomationRuleDto
    {
        public string Name { get; set; } = string.Empty;
        public string TriggerType { get; set; } = string.Empty;
        public string? ConditionsJson { get; set; }
        public bool IsActive { get; set; } = true;
    }
}
