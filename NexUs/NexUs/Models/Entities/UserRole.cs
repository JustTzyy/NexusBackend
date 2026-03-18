namespace NexUs.Models.Entities
{
    public class UserRole
    {
        public int Id { get; set; }

        // Foreign Keys
        public int UserId { get; set; }
        public int RoleId { get; set; }

        // Navigation Properties
        public User User { get; set; } = null!;
        public Role Role { get; set; } = null!;
    }
}