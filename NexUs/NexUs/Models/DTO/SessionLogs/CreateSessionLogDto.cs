namespace NexUs.Models.DTO.SessionLogs
{
    public class CreateSessionLogDto
    {
        public int TutoringRequestId { get; set; }
        public DateTime SessionDate { get; set; }
        public string Outcome { get; set; } = string.Empty;
        public string? AbsentParty { get; set; }
        public string? Notes { get; set; }
    }
}
