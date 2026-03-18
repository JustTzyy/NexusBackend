namespace NexUs.Models.Entities
{
    public class TutoringRequestStatusHistory : BaseEntity
    {
        public int TutoringRequestId { get; set; }
        public string FromStatus { get; set; } = string.Empty;
        public string ToStatus { get; set; } = string.Empty;
        public string ChangedByRole { get; set; } = string.Empty; // "Student", "Teacher", "Admin"

        // Navigation
        public TutoringRequest TutoringRequest { get; set; } = null!;
    }
}
