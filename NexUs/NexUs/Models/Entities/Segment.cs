namespace NexUs.Models.Entities
{
    public class Segment : BaseEntity
    {
        public string Name { get; set; } = string.Empty;
        public string? Description { get; set; }
        public string Type { get; set; } = "Dynamic"; // Dynamic | Static
        public string? RulesJson { get; set; }
        public bool IsActive { get; set; } = true;

        // Navigation
        public ICollection<Campaign> Campaigns { get; set; } = [];
    }
}
