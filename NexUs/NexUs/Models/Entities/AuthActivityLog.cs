namespace NexUs.Models.Entities
{
    public class AuthActivityLog
    {
        public int Id { get; set; }
        public int? UserId { get; set; }
        public string Action { get; set; } = string.Empty;
        public string Status { get; set; } = string.Empty;
        public string? IpAddress { get; set; }
        public string? Device { get; set; }
        public string? Location { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

        // Navigation
        public User? User { get; set; }
    }
}
