namespace NexUs.Models.DTO.TutoringRequests
{
    /// <summary>
    /// Student-safe view of a tutoring request.
    /// Hides internal workflow (interested teachers, admin actions).
    /// Schedule info only visible when status >= "Waiting for Teacher Approval".
    /// </summary>
    public class TutoringRequestStudentDto
    {
        public int Id { get; set; }
        public string BuildingName { get; set; } = string.Empty;
        public string DepartmentName { get; set; } = string.Empty;
        public string SubjectName { get; set; } = string.Empty;
        public string Message { get; set; } = string.Empty;
        public string Priority { get; set; } = string.Empty;
        public string Status { get; set; } = string.Empty;

        public bool IsAdminCreated { get; set; }

        // Visible from "Teacher Assigned" onward
        public string? AssignedTeacherName { get; set; }

        // Visible from "Waiting for Teacher Approval" onward
        public string? RoomName { get; set; }
        public string? DayName { get; set; }
        public string? TimeSlotLabel { get; set; }

        // Timestamps
        public DateTime CreatedAt { get; set; }
        public DateTime? ConfirmedAt { get; set; }
        public DateTime? CancelledAt { get; set; }
        public string? CancelledBy { get; set; }
    }
}
