using NexUs.Models.DTO.Common;

namespace NexUs.Models.DTO.Users
{
    public class UpdateUserDto
    {
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? MiddleName { get; set; }
        public string? Suffix { get; set; }
        public DateTime? DateOfBirth { get; set; }
        public string? Gender { get; set; }
        public string? Nationality { get; set; }
        public string? Email { get; set; }
        public string? Phone { get; set; }
        public int? AddressId { get; set; }
        public CreateAddressDto? Address { get; set; }
        public List<int>? RoleIds { get; set; }
    }
}
