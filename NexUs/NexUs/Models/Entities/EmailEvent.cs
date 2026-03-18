namespace NexUs.Models.Entities
{
    // Append-only delivery event log — no soft delete, no update
    public class EmailEvent
    {
        public int Id { get; set; }
        public int EmailMessageId { get; set; }
        public string EventType { get; set; } = string.Empty; // Queued | Sending | Sent | Failed | Retrying | Cancelled
        public string? Notes { get; set; }
        public DateTime OccurredAt { get; set; } = DateTime.UtcNow;
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

        // Navigation
        public EmailMessage? EmailMessage { get; set; }
    }
}
