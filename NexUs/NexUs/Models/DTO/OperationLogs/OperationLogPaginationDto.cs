using NexUs.Models.DTO.Common;

namespace NexUs.Models.DTO.OperationLogs
{
    public class OperationLogPaginationDto : PaginationDto
    {
        public string? Action { get; set; }
        public string? Status { get; set; }
        public DateTime? FromDate { get; set; }
        public DateTime? ToDate { get; set; }
    }
}
