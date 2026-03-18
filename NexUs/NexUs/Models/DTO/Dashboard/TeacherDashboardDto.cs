namespace NexUs.Models.DTO.Dashboard
{
    public class TeacherDashboardDto
    {
        public bool HasAssignment { get; set; }
        public int AvailableRequestsCount { get; set; }
        public int ExpressedInterestCount { get; set; }
        public int PendingApprovalCount { get; set; }
        public int ConfirmedSessionsCount { get; set; }
        public List<DashboardRequestItemDto> RecentAvailable { get; set; } = new();
        public List<DashboardSessionItemDto> UpcomingSessions { get; set; } = new();
    }

    public class DashboardRequestItemDto
    {
        public int Id { get; set; }
        public string SubjectName { get; set; } = string.Empty;
        public string BuildingName { get; set; } = string.Empty;
        public string DepartmentName { get; set; } = string.Empty;
        public string StudentName { get; set; } = string.Empty;
        public string Priority { get; set; } = string.Empty;
        public string Status { get; set; } = string.Empty;
        public DateTime CreatedAt { get; set; }
    }

    public class DashboardSessionItemDto
    {
        public int Id { get; set; }
        public string SubjectName { get; set; } = string.Empty;
        public string StudentName { get; set; } = string.Empty;
        public string BuildingName { get; set; } = string.Empty;
        public string? RoomName { get; set; }
        public string? DayName { get; set; }
        public string? TimeSlotLabel { get; set; }
        public string? AssignedTeacherName { get; set; }
        public DateTime? ConfirmedAt { get; set; }
    }
}
