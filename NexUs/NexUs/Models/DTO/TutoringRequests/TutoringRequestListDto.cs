namespace NexUs.Models.DTO.TutoringRequests
{
    public class TutoringRequestListDto
    {
        public int Id { get; set; }
        public string? StudentName { get; set; }
        public int BuildingId { get; set; }
        public string BuildingName { get; set; } = string.Empty;
        public string DepartmentName { get; set; } = string.Empty;
        public string SubjectName { get; set; } = string.Empty;
        public string Priority { get; set; } = string.Empty;
        public string Status { get; set; } = string.Empty;
        public string? AssignedTeacherName { get; set; }
        public bool IsAdminCreated { get; set; }
        public DateTime CreatedAt { get; set; }

        // Schedule info (populated for admin-created sessions)
        public string? RoomName { get; set; }
        public string? DayName { get; set; }
        public string? TimeSlotLabel { get; set; }
        public string? StartTime { get; set; }
        public string? EndTime { get; set; }

        // Teacher-specific (only populated for teacher interest history)
        public string? MyInterestStatus { get; set; }

        // Confirmation & first class date (only set when Status == "Confirmed")
        public DateTime? ConfirmedAt { get; set; }
        public DateTime? FirstClassDate { get; set; }
    }
}
