namespace NexUs.Models.Entities
{
    public class SessionLog : BaseEntity
    {
        public int TutoringRequestId { get; set; }
        public DateTime SessionDate { get; set; }
        public string Outcome { get; set; } = string.Empty; // "Completed" | "Late" | "Absent"
        public string? AbsentParty { get; set; }            // "Teacher" | "Student" | "Both"
        public string? Notes { get; set; }

        // Navigation
        public TutoringRequest TutoringRequest { get; set; } = null!;
    }
}
