namespace NexUs.Models.DTO.Dashboard
{
    public class StudentDashboardDto
    {
        public int TotalRequestsCount { get; set; }
        public int PendingCount { get; set; }
        public int InProgressCount { get; set; }
        public int ConfirmedCount { get; set; }
        public int CancelledCount { get; set; }
        public List<DashboardRequestItemDto> RecentRequests { get; set; } = new();
        public List<DashboardSessionItemDto> UpcomingSessions { get; set; } = new();
    }
}
