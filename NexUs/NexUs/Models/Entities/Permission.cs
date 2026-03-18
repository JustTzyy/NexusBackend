namespace NexUs.Models.Entities
{
    public class Permission : BaseEntity
    {
        public string Name { get; set; } = string.Empty;
        public string Module { get; set; } = string.Empty;
        public string? Description { get; set; }

        // Navigation Properties
        public ICollection<RolePermission> RolePermissions { get; set; } = new List<RolePermission>();
    }
}
