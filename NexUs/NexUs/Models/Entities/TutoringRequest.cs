namespace NexUs.Models.Entities
{
    public class TutoringRequest : BaseEntity
    {
        public int? StudentId { get; set; }
        public int BuildingId { get; set; }
        public int DepartmentId { get; set; }
        public int SubjectId { get; set; }
        public string Message { get; set; } = string.Empty;
        public string Priority { get; set; } = "Normal";
        public string Status { get; set; } = "Pending Teacher Interest";
        public bool IsAdminCreated { get; set; } = false;

        // Assigned by admin
        public int? AssignedTeacherId { get; set; }
        public int? RoomId { get; set; }
        public int? AvailableDayId { get; set; }
        public int? AvailableTimeSlotId { get; set; }

        // Timestamps
        public DateTime? ScheduledAt { get; set; }
        public DateTime? ConfirmedAt { get; set; }
        public DateTime? CancelledAt { get; set; }
        public string? CancelledBy { get; set; }
        public DateTime? ReminderSentAt { get; set; }

        // Navigation Properties
        public User? Student { get; set; }
        public Building Building { get; set; } = null!;
        public Department Department { get; set; } = null!;
        public Subject Subject { get; set; } = null!;
        public User? AssignedTeacher { get; set; }
        public Room? Room { get; set; }
        public AvailableDay? AvailableDay { get; set; }
        public AvailableTimeSlot? AvailableTimeSlot { get; set; }

        // Collection
        public ICollection<TeacherInterest> TeacherInterests { get; set; } = new List<TeacherInterest>();
    }
}
