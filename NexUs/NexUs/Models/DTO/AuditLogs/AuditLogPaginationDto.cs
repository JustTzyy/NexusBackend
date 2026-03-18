using NexUs.Models.DTO.Common;

namespace NexUs.Models.DTO.AuditLogs
{
    public class AuditLogPaginationDto : PaginationDto
    {
        public string? Module { get; set; }
        public DateTime? FromDate { get; set; }
        public DateTime? ToDate { get; set; }
    }
}
