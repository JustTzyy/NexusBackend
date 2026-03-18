namespace NexUs.Models.Entities
{
    // Append-only — no soft delete
    public class EmailMessage
    {
        public int Id { get; set; }
        public int? CampaignId { get; set; }
        public int? AutomationRuleId { get; set; }
        public int? EmailTemplateId { get; set; }
        public int? RecipientUserId { get; set; }
        public string RecipientEmail { get; set; } = string.Empty;
        public string? RecipientName { get; set; }
        public string Subject { get; set; } = string.Empty;
        public string Body { get; set; } = string.Empty;
        public string? VariablesJson { get; set; } // JSON dict of extra {{Token}} replacements for the template
        public string Status { get; set; } = "Queued"; // Queued | Sending | Sent | Failed | Cancelled
        public DateTime QueuedAt { get; set; } = DateTime.UtcNow;
        public DateTime? SentAt { get; set; }
        public DateTime? FailedAt { get; set; }
        public string? ErrorMessage { get; set; }
        public int RetryCount { get; set; } = 0;
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;

        // Navigation
        public Campaign? Campaign { get; set; }
        public AutomationRule? AutomationRule { get; set; }
        public EmailTemplate? EmailTemplate { get; set; }
        public User? RecipientUser { get; set; }
        public ICollection<EmailEvent> EmailEvents { get; set; } = [];
    }
}
