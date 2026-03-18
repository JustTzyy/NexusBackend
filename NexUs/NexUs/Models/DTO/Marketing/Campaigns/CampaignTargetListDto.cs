namespace NexUs.Models.DTO.Marketing
{
    public class CampaignTargetListDto
    {
        public int Id { get; set; }
        public int CampaignId { get; set; }
        public int? UserId { get; set; }
        public string Email { get; set; } = string.Empty;
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string Status { get; set; } = string.Empty;
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
    }
}
