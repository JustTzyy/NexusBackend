namespace NexUs.Models.DTO.Marketing
{
    public class CreateSegmentDto
    {
        public string Name { get; set; } = string.Empty;
        public string? Description { get; set; }
        public string Type { get; set; } = "Dynamic";
        public string? RulesJson { get; set; }
        public bool IsActive { get; set; } = true;
    }
}
