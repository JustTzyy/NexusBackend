namespace NexUs.Models.DTO.Dashboard
{
    public class BuildingManagerDashboardDto
    {
        public bool HasBuilding { get; set; }
        public string BuildingName { get; set; } = string.Empty;
        public string? AddressLine { get; set; }
        public bool IsActive { get; set; }

        public int TotalRooms { get; set; }
        public int AvailableRooms { get; set; }
        public int OccupiedRooms { get; set; }
        public int MaintenanceRooms { get; set; }
        public int TodaySessionsCount { get; set; }

        public List<BuildingManagerRoomDto> Rooms { get; set; } = new();
        public List<DashboardSessionItemDto> TodaySessions { get; set; } = new();
        public List<DashboardSessionItemDto> UpcomingSessions { get; set; } = new();
    }

    public class BuildingManagerRoomDto
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public int Capacity { get; set; }
        public bool IsActive { get; set; }
        public string Status { get; set; } = string.Empty; // Available, Occupied, Maintenance
        public DashboardSessionItemDto? CurrentSession { get; set; }
    }
}
