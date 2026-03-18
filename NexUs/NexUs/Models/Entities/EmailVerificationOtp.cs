namespace NexUs.Models.Entities
{
    public class EmailVerificationOtp : BaseEntity
    {
        public string Email { get; set; } = string.Empty;
        public string Code { get; set; } = string.Empty;
        public DateTime ExpiresAt { get; set; }
        public bool IsUsed { get; set; }
    }
}
