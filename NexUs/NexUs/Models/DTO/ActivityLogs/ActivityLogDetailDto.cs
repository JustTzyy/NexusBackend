namespace NexUs.Models.DTO.ActivityLogs
{
    public class ActivityLogDetailDto
    {
        public int Id { get; set; }
        public string Module { get; set; } = string.Empty;
        public string Action { get; set; } = string.Empty;
        public string Details { get; set; } = string.Empty;
        public DateTime CreatedAt { get; set; }
    }
}
