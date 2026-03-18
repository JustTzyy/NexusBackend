namespace NexUs.Models.DTO.Dashboard;

public class DashboardSummaryDto
{
    public int TotalUsers { get; set; }
    public int ActiveUsers { get; set; }
    public int TotalRoles { get; set; }
    public int TotalPermissions { get; set; }
    public List<RecentUserDto> RecentUsers { get; set; } = new();
    public List<RoleDistributionDto> RoleDistribution { get; set; } = new();
    public List<int> RegistrationTrends { get; set; } = new();

    // Tutoring setup counts
    public int TotalDepartments { get; set; }
    public int TotalSubjects { get; set; }
    public int TotalBuildings { get; set; }
    public int TotalRooms { get; set; }
    public int TotalAvailableDays { get; set; }
    public int TotalTimeSlots { get; set; }
    public int TotalTeacherAssignments { get; set; }

    // Tutoring setup breakdowns
    public List<NameCountDto> SubjectsPerDepartment { get; set; } = new();
    public List<NameCountDto> RoomsPerBuilding { get; set; } = new();
    public List<NameCountDto> AssignmentsPerDepartment { get; set; } = new();

    // Tutoring overview
    public int TotalRequests { get; set; }
    public int ConfirmedSessions { get; set; }
    public int ActiveRequests { get; set; }
    public int CancelledRequests { get; set; }
    public List<StatusCountDto> StatusDistribution { get; set; } = new();
    public List<PriorityCountDto> PriorityDistribution { get; set; } = new();
    public List<int> AdminRequestTrends { get; set; } = new();
    public List<int> StudentRequestTrends { get; set; } = new();
}

public class RecentUserDto
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public string Role { get; set; } = string.Empty;
    public string Status { get; set; } = string.Empty;
    public string JoinedDate { get; set; } = string.Empty;
}

public class RoleDistributionDto
{
    public string Role { get; set; } = string.Empty;
    public int Count { get; set; }
    public int Percentage { get; set; }
}

public class StatusCountDto
{
    public string Status { get; set; } = string.Empty;
    public int Count { get; set; }
}

public class PriorityCountDto
{
    public string Priority { get; set; } = string.Empty;
    public int Count { get; set; }
}

public class NameCountDto
{
    public string Name { get; set; } = string.Empty;
    public int Count { get; set; }
}
