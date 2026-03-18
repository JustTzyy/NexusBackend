namespace NexUs.Models.DTO.Marketing
{
    public class CreateSuppressionDto
    {
        public string Email { get; set; } = string.Empty;
        public string Reason { get; set; } = "Manual";
        public string Source { get; set; } = "Manual";
        public string? Notes { get; set; }
    }
}
