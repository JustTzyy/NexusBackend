namespace NexUs.Models.Entities
{
    public class StudentAssignment : BaseEntity
    {
        public int StudentId { get; set; }
        public int? PreferredBuildingId { get; set; }
        public string? Notes { get; set; }

        // Navigation Properties
        public User Student { get; set; } = null!;
        public Building? PreferredBuilding { get; set; }
    }
}
