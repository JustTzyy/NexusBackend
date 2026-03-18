namespace NexUs.Models.DTO.Marketing
{
    public class UpdateCampaignDto
    {
        public string Name { get; set; } = string.Empty;
        public string? Subject { get; set; }
        public int? EmailTemplateId { get; set; }
        public int? SegmentId { get; set; }
    }
}
