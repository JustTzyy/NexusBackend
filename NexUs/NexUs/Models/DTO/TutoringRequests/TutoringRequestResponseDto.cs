using NexUs.Models.DTO.TeacherInterests;

namespace NexUs.Models.DTO.TutoringRequests
{
    public class TutoringRequestResponseDto
    {
        public int Id { get; set; }
        public int? StudentId { get; set; }
        public string? StudentName { get; set; }
        public int BuildingId { get; set; }
        public string BuildingName { get; set; } = string.Empty;
        public int DepartmentId { get; set; }
        public string DepartmentName { get; set; } = string.Empty;
        public int SubjectId { get; set; }
        public string SubjectName { get; set; } = string.Empty;
        public string Message { get; set; } = string.Empty;
        public string Priority { get; set; } = string.Empty;
        public string Status { get; set; } = string.Empty;
        public bool IsAdminCreated { get; set; }

        // Assigned schedule (admin-set)
        public int? AssignedTeacherId { get; set; }
        public string? AssignedTeacherName { get; set; }
        public int? RoomId { get; set; }
        public string? RoomName { get; set; }
        public int? AvailableDayId { get; set; }
        public string? DayName { get; set; }
        public int? AvailableTimeSlotId { get; set; }
        public string? TimeSlotLabel { get; set; }

        // Timestamps
        public DateTime CreatedAt { get; set; }
        public DateTime? ScheduledAt { get; set; }
        public DateTime? ConfirmedAt { get; set; }
        public DateTime? FirstClassDate { get; set; }
        public DateTime? CancelledAt { get; set; }
        public string? CancelledBy { get; set; }
        public DateTime? DeletedAt { get; set; }

        // Audit
        public int? CreatedBy { get; set; }
        public int? UpdatedBy { get; set; }
        public string? CreatedByName { get; set; }
        public string? UpdatedByName { get; set; }

        // Admin-only: interested teachers
        public List<TeacherInterestResponseDto> InterestedTeachers { get; set; } = new();
    }
}
