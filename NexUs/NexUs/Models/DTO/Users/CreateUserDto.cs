namespace NexUs.Models.DTO.Users
{
    public class CreateUserDto
    {
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public string? MiddleName { get; set; }
        public string? Suffix { get; set; }
        public DateTime? DateOfBirth { get; set; }
        public string? Gender { get; set; }
        public string? Nationality { get; set; }
        public string Email { get; set; } = string.Empty;
        public string? Phone { get; set; }
        public int? AddressId { get; set; }
        public List<int>? RoleIds { get; set; }
    }
}
