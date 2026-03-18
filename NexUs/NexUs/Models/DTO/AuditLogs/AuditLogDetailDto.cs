namespace NexUs.Models.DTO.AuditLogs
{
    public class AuditLogDetailDto
    {
        public int Id { get; set; }
        public string User { get; set; } = string.Empty;
        public string Module { get; set; } = string.Empty;
        public string Action { get; set; } = string.Empty;
        public string Details { get; set; } = string.Empty;
        public DateTime CreatedAt { get; set; }
        public int? UserId { get; set; }
    }
}
