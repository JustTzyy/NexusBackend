namespace NexUs.Models.Entities
{
    public class TeacherInterest : BaseEntity
    {
        public int TutoringRequestId { get; set; }
        public int TeacherId { get; set; }
        public string Description { get; set; } = string.Empty;
        public string Status { get; set; } = "Interested";

        // Navigation Properties
        public TutoringRequest TutoringRequest { get; set; } = null!;
        public User Teacher { get; set; } = null!;
    }
}
