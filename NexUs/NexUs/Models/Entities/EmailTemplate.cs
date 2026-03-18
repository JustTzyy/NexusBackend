namespace NexUs.Models.Entities
{
    public class EmailTemplate : BaseEntity
    {
        public string Name { get; set; } = string.Empty;
        public string Subject { get; set; } = string.Empty;
        public string FileName { get; set; } = string.Empty;
        public string? Body { get; set; } // HTML stored in DB — preferred over file on disk
        public string? Variables { get; set; }
        public string? Category { get; set; }
        public bool IsActive { get; set; } = true;

        // Navigation
        public ICollection<Campaign> Campaigns { get; set; } = [];
        public ICollection<AutomationAction> AutomationActions { get; set; } = [];
        public ICollection<EmailMessage> EmailMessages { get; set; } = [];
    }
}
