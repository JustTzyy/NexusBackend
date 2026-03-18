namespace NexUs.Models.DTO.Marketing
{
    public class EmailEventDto
    {
        public int Id { get; set; }
        public string EventType { get; set; } = string.Empty;
        public string? Notes { get; set; }
        public DateTime OccurredAt { get; set; }
    }
}
