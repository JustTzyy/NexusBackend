namespace NexUs.Models.Entities
{
    public class AuditLog
    {
        public int Id { get; set; }
        public string Module { get; set; } = string.Empty;
        public string Action { get; set; } = string.Empty;
        public string Details { get; set; } = string.Empty;
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

        // Foreign Key
        public int? UserId { get; set; }

        // Navigation Property
        public User? User { get; set; }
    }
}