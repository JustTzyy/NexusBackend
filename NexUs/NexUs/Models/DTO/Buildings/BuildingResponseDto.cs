using NexUs.Models.DTO.Common;

namespace NexUs.Models.DTO.Buildings
{
    public class BuildingResponseDto
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public bool IsActive { get; set; }
        public int? ManagedBy { get; set; }
        public string? ManagerName { get; set; }
        public int? AddressId { get; set; }
        public AddressDto? Address { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public DateTime? DeletedAt { get; set; }
        public int? CreatedBy { get; set; }
        public int? UpdatedBy { get; set; }
        public string? CreatedByName { get; set; }
        public string? UpdatedByName { get; set; }
    }
}
