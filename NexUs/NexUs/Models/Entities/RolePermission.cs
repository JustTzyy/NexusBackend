namespace NexUs.Models.Entities
{
    public class RolePermission
    {
        public int Id { get; set; }

        // Foreign Keys
        public int RoleId { get; set; }
        public int PermissionId { get; set; }

        // Navigation Properties
        public Role Role { get; set; } = null!;
        public Permission Permission { get; set; } = null!;
    }
}