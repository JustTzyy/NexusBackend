namespace NexUs.Models.DTO.OperationLogs
{
    public class OperationLogListDto
    {
        public int Id { get; set; }
        public string User { get; set; } = string.Empty;
        public string Action { get; set; } = string.Empty;
        public string Status { get; set; } = string.Empty;
        public string? IpAddress { get; set; }
        public string? Device { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}
