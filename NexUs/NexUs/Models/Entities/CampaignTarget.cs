namespace NexUs.Models.Entities
{
    // Append-only log — no soft delete, inherits only audit timestamps
    public class CampaignTarget
    {
        public int Id { get; set; }
        public int CampaignId { get; set; }
        public int? UserId { get; set; }
        public string Email { get; set; } = string.Empty;
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string Status { get; set; } = "Queued"; // Queued | Sent | Failed | Suppressed | Skipped
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;

        // Navigation
        public Campaign? Campaign { get; set; }
        public User? User { get; set; }
    }
}
