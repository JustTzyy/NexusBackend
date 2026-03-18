namespace NexUs.Models.Entities
{
    public class Lead : BaseEntity
    {
        public int? UserId { get; set; }
        public string Email { get; set; } = string.Empty;
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public string? Phone { get; set; }
        public string Source { get; set; } = "Manual"; // Registration | Manual | Import
        public string Status { get; set; } = "New"; // New | Contacted | Interested | Converted | Closed
        public DateTime? ConvertedAt { get; set; }
        public string? Notes { get; set; }

        // Navigation
        public User? User { get; set; }
        public Customer? Customer { get; set; }
    }
}
