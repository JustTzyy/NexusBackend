namespace NexUs.Models.DTO.Buildings
{
    public class BuildingListDto
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public bool IsActive { get; set; }
        public string? ManagerName { get; set; }
        public string? AddressLine { get; set; }
        public string? CityMunicipality { get; set; }
        public string? Province { get; set; }
        public string? Region { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
    }
}
