namespace NexUs.Models.Entities
{
    public class AutomationAction : BaseEntity
    {
        public int AutomationRuleId { get; set; }
        public string ActionType { get; set; } = "SendEmail"; // SendEmail (extendable)
        public int? EmailTemplateId { get; set; }
        public int DelayMinutes { get; set; } = 0;
        public int SortOrder { get; set; } = 0;
        public bool IsActive { get; set; } = true;

        // Navigation
        public AutomationRule? AutomationRule { get; set; }
        public EmailTemplate? EmailTemplate { get; set; }
    }
}
