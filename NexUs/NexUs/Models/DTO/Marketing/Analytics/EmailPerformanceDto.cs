namespace NexUs.Models.DTO.Marketing
{
    public class EmailPerformanceDto
    {
        public string Period { get; set; } = string.Empty;
        public int Sent { get; set; }
        public int Failed { get; set; }
    }
}
