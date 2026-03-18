namespace NexUs.Models.DTO.TutoringRequests
{
    public class TutoringRequestStatusHistoryDto
    {
        public int Id { get; set; }
        public int TutoringRequestId { get; set; }
        public string SubjectName { get; set; } = string.Empty;
        public string? StudentName { get; set; }
        public string BuildingName { get; set; } = string.Empty;
        public bool IsAdminCreated { get; set; }
        public string FromStatus { get; set; } = string.Empty;
        public string ToStatus { get; set; } = string.Empty;
        public string ChangedByRole { get; set; } = string.Empty;
        public string? ChangedByName { get; set; }
        public DateTime ChangedAt { get; set; }
    }
}
