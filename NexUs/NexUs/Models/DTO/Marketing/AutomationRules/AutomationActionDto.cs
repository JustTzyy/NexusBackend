namespace NexUs.Models.DTO.Marketing
{
    public class AutomationActionDto
    {
        public int Id { get; set; }
        public int AutomationRuleId { get; set; }
        public string ActionType { get; set; } = string.Empty;
        public int? EmailTemplateId { get; set; }
        public string? EmailTemplateName { get; set; }
        public int DelayMinutes { get; set; }
        public int SortOrder { get; set; }
        public bool IsActive { get; set; }
    }
}
