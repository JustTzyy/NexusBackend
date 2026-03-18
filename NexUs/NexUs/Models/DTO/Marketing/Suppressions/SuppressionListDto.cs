namespace NexUs.Models.DTO.Marketing
{
    public class SuppressionListDto
    {
        public int Id { get; set; }
        public string Email { get; set; } = string.Empty;
        public string Reason { get; set; } = string.Empty;
        public string Source { get; set; } = string.Empty;
        public string? Notes { get; set; }
        public DateTime CreatedAt { get; set; }
        public string? CreatedByName { get; set; }
    }
}
