namespace NexUs.Models.DTO.Marketing
{
    public class CampaignStatsDto
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Status { get; set; } = string.Empty;
        public int TotalTargets { get; set; }
        public int SentCount { get; set; }
        public int FailedCount { get; set; }
        public int SuppressedCount { get; set; }
        public DateTime? SentAt { get; set; }
    }
}
