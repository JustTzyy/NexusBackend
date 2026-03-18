using NexUs.Models.DTO.Permissions;

namespace NexUs.Models.DTO.Roles
{
    public class RoleListDto
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public DateTime CreatedAt { get; set; }
        public DateTime? DeletedAt { get; set; }
        public List<PermissionListDto> Permissions { get; set; } = new List<PermissionListDto>();
    }
}
