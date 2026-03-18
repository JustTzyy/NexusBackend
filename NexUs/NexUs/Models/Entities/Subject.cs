namespace NexUs.Models.Entities
{
    public class Subject : BaseEntity
    {
        public string Name { get; set; } = string.Empty;
        public string? Description { get; set; }
        public bool IsActive { get; set; } = true;

        // Foreign Keys
        public int DepartmentId { get; set; }

        // Navigation Properties
        public Department Department { get; set; } = null!;
    }
}
