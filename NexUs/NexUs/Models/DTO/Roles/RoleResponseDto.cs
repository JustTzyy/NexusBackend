using NexUs.Models.DTO.Permissions;

namespace NexUs.Models.DTO.Roles
{
    public class RoleResponseDto
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public List<PermissionListDto> Permissions { get; set; } = new List<PermissionListDto>();
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public DateTime? DeletedAt { get; set; }
        public string? CreatedByName { get; set; }
        public string? UpdatedByName { get; set; }
    }
}
