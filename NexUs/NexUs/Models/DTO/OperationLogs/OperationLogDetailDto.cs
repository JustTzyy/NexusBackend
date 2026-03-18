namespace NexUs.Models.DTO.OperationLogs
{
    public class OperationLogDetailDto
    {
        public int Id { get; set; }
        public string User { get; set; } = string.Empty;
        public string Action { get; set; } = string.Empty;
        public string Status { get; set; } = string.Empty;
        public string? IpAddress { get; set; }
        public string? Device { get; set; }
        public string? Location { get; set; }
        public DateTime CreatedAt { get; set; }
        public int? UserId { get; set; }
    }
}
