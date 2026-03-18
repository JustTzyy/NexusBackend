namespace NexUs.Models.Entities
{
    public class UserCredential
    {
        public int Id { get; set; }

        // Foreign Key
        public int UserId { get; set; }

        public string PasswordHash { get; set; } = string.Empty;
        public string? PasswordSalt { get; set; }
        public string? DefaultPassword { get; set; } // Encrypted, for email notification
        public bool IsPasswordChanged { get; set; } = false;
        public DateTime? LastPasswordChange { get; set; }

        // Navigation Property
        public User User { get; set; } = null!;
    }
}