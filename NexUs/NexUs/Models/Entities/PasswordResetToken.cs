namespace NexUs.Models.Entities
{
    public class PasswordResetToken : BaseEntity
    {
        public string Token { get; set; } = string.Empty;
        public int UserId { get; set; }
        public DateTime ExpiresAt { get; set; }
        public bool IsUsed { get; set; }

        // Navigation
        public User? User { get; set; }
    }
}
