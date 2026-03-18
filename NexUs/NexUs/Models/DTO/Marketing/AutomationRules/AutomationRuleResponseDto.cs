namespace NexUs.Models.DTO.Marketing
{
    public class AutomationRuleResponseDto
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string TriggerType { get; set; } = string.Empty;
        public string? ConditionsJson { get; set; }
        public bool IsActive { get; set; }
        public List<AutomationActionDto> Actions { get; set; } = [];
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public string? CreatedByName { get; set; }
        public string? UpdatedByName { get; set; }
    }
}
