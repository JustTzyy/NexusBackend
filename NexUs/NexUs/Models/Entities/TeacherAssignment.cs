namespace NexUs.Models.Entities
{
    public class TeacherAssignment : BaseEntity
    {
        public int TeacherId { get; set; }
        public int BuildingId { get; set; }
        public int DepartmentId { get; set; }

        // Navigation Properties
        public User Teacher { get; set; } = null!;
        public Building Building { get; set; } = null!;
        public Department Department { get; set; } = null!;
    }
}
