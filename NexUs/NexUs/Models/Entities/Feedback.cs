namespace NexUs.Models.Entities
{
    public class Feedback : BaseEntity
    {
        public int TutoringRequestId { get; set; }
        public int SessionLogId { get; set; }
        public int CustomerId { get; set; }
        public int TeacherId { get; set; }

        public int Rating { get; set; } // 1-5
        public string? Comment { get; set; }

        // Navigation
        public TutoringRequest TutoringRequest { get; set; } = null!;
        public SessionLog SessionLog { get; set; } = null!;
        public User Customer { get; set; } = null!;
        public User Teacher { get; set; } = null!;
    }
}
