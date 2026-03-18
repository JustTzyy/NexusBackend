namespace NexUs.Models.Entities
{
    public class Customer : BaseEntity
    {
        public int UserId { get; set; }
        public int? LeadId { get; set; }
        public int? FirstTutoringRequestId { get; set; }
        public string? Notes { get; set; }

        // Navigation
        public User? User { get; set; }
        public Lead? Lead { get; set; }
        public TutoringRequest? FirstTutoringRequest { get; set; }
    }
}
