namespace NexUs.Models.Entities
{
    public class Suppression : BaseEntity
    {
        public string Email { get; set; } = string.Empty;
        public string Reason { get; set; } = "Manual"; // Unsubscribed | Bounced | SpamReport | Manual
        public string Source { get; set; } = "Manual"; // Webhook | Manual | Import
        public string? Notes { get; set; }
    }
}
