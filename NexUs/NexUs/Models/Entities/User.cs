namespace NexUs.Models.Entities
{
    public class User : BaseEntity
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

        // Foreign Keys
        public int? AddressId { get; set; }

        // Navigation Properties
        public Address? Address { get; set; }
        public ICollection<UserRole> UserRoles { get; set; } = new List<UserRole>();
        public ICollection<AuditLog> AuditLogs { get; set; } = new List<AuditLog>();
        public ICollection<AuthActivityLog> AuthActivityLogs { get; set; } = new List<AuthActivityLog>();
    }
}
