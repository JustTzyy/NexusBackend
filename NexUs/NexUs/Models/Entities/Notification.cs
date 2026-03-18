namespace NexUs.Models.Entities
{
    public class Notification : BaseEntity
    {
        // Recipient — either a specific user or a role
        public int? RecipientUserId { get; set; }
        public string? RecipientRole { get; set; }

        // Content
        public string Title { get; set; } = string.Empty;
        public string Message { get; set; } = string.Empty;
        public string Type { get; set; } = "General"; // Tutoring | Marketing | Scheduling | General
        public string Priority { get; set; } = "Normal"; // Low | Normal | High | Urgent
        public string Status { get; set; } = "Unread"; // Unread | Read | Dismissed
        public DateTime? ReadAt { get; set; }

        // Reference to related entity
        public int? ReferenceId { get; set; }
        public string? ReferenceType { get; set; } // TutoringRequest | Campaign | Lead | SessionLog

        // Navigation
        public User? Recipient { get; set; }
    }
}
