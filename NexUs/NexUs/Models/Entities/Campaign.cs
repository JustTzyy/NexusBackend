namespace NexUs.Models.Entities
{
    public class Campaign : BaseEntity
    {
        public string Name { get; set; } = string.Empty;
        public string Subject { get; set; } = string.Empty;
        public int? EmailTemplateId { get; set; }
        public int? SegmentId { get; set; }
        public string Status { get; set; } = "Draft"; // Draft | Scheduled | Sending | Sent | Paused | Cancelled
        public DateTime? ScheduledAt { get; set; }
        public DateTime? SentAt { get; set; }
        public int TotalTargets { get; set; } = 0;
        public int SentCount { get; set; } = 0;
        public int FailedCount { get; set; } = 0;
        public int SuppressedCount { get; set; } = 0;

        // Navigation
        public EmailTemplate? EmailTemplate { get; set; }
        public Segment? Segment { get; set; }
        public ICollection<CampaignTarget> CampaignTargets { get; set; } = [];
        public ICollection<EmailMessage> EmailMessages { get; set; } = [];
    }
}
