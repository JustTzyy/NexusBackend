using NexUs.Models.DTO.Common;
using NexUs.Models.DTO.Roles;

namespace NexUs.Models.DTO.Users
{
    public class UserResponseDto
    {
        public int Id { get; set; }
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public string? MiddleName { get; set; }
        public string? Suffix { get; set; }
        public string FullName => $"{FirstName} {MiddleName} {LastName} {Suffix}".Replace("  ", " ").Trim();
        public DateTime? DateOfBirth { get; set; }
        public string? Gender { get; set; }
        public string? Nationality { get; set; }
        public string Email { get; set; } = string.Empty;
        public string? Phone { get; set; }
        public AddressDto? Address { get; set; }
        public int? PreferredBuildingId { get; set; }
        public string? PreferredBuildingName { get; set; }
        public List<RoleListDto> Roles { get; set; } = new List<RoleListDto>();
        public string? CreatedByName { get; set; }
        public string? UpdatedByName { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public DateTime? DeletedAt { get; set; }
    }
}
