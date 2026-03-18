namespace NexUs.Models.DTO.Marketing
{
    public class AutomationRuleListDto
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string TriggerType { get; set; } = string.Empty;
        public bool IsActive { get; set; }
        public int ActionsCount { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public string? CreatedByName { get; set; }
        public string? UpdatedByName { get; set; }
    }
}
