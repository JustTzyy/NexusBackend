namespace NexUs.Models.Entities
{
    public class Room : BaseEntity
    {
        public string Name { get; set; } = string.Empty;
        public int Capacity { get; set; }
        public bool IsActive { get; set; } = true;

        // Foreign Keys
        public int BuildingId { get; set; }

        // Navigation Properties
        public Building Building { get; set; } = null!;
    }
}
