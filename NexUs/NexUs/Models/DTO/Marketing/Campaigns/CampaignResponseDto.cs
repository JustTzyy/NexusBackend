namespace NexUs.Models.DTO.Marketing
{
    public class CampaignResponseDto
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Subject { get; set; } = string.Empty;
        public int? EmailTemplateId { get; set; }
        public string? EmailTemplateName { get; set; }
        public int? SegmentId { get; set; }
        public string? SegmentName { get; set; }
        public string Status { get; set; } = string.Empty;
        public DateTime? ScheduledAt { get; set; }
        public DateTime? SentAt { get; set; }
        public int TotalTargets { get; set; }
        public int SentCount { get; set; }
        public int FailedCount { get; set; }
        public int SuppressedCount { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public string? CreatedByName { get; set; }
        public string? UpdatedByName { get; set; }
    }
}
