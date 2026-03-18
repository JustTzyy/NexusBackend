namespace NexUs.Models.DTO.SessionLogs
{
    public class SessionLogResponseDto
    {
        public int Id { get; set; }
        public int TutoringRequestId { get; set; }
        public string? SubjectName { get; set; }
        public DateTime SessionDate { get; set; }
        public string Outcome { get; set; } = string.Empty;
        public string? AbsentParty { get; set; }
        public string? Notes { get; set; }
        public DateTime CreatedAt { get; set; }
        public string? CreatedByName { get; set; }
    }
}
