namespace NexUs.Models.Entities
{
    public class AutomationRule : BaseEntity
    {
        public string Name { get; set; } = string.Empty;
        public string TriggerType { get; set; } = string.Empty; // LeadCreated | LeadConverted | SessionBooked | SessionConfirmed | SessionReminder | LeadStatusChanged
        public string? ConditionsJson { get; set; }
        public bool IsActive { get; set; } = true;

        // Navigation
        public ICollection<AutomationAction> Actions { get; set; } = [];
        public ICollection<EmailMessage> EmailMessages { get; set; } = [];
    }
}
