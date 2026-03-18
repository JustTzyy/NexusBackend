namespace NexUs.Models.DTO.Marketing
{
    public class EmailMessageListDto
    {
        public int Id { get; set; }
        public int? CampaignId { get; set; }
        public string? CampaignName { get; set; }
        public int? AutomationRuleId { get; set; }
        public string? AutomationRuleName { get; set; }
        public string RecipientEmail { get; set; } = string.Empty;
        public string? RecipientName { get; set; }
        public string Subject { get; set; } = string.Empty;
        public string Status { get; set; } = string.Empty;
        public DateTime QueuedAt { get; set; }
        public DateTime? SentAt { get; set; }
        public DateTime? FailedAt { get; set; }
        public string? ErrorMessage { get; set; }
        public int RetryCount { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}
