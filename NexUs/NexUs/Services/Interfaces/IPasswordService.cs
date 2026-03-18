namespace NexUs.Services.Interfaces
{
    public interface IPasswordService
    {
        /// <summary>
        /// Generates a random secure password (8-12 characters)
        /// </summary>
        string GeneratePassword();

        /// <summary>
        /// Hashes a password using BCrypt
        /// </summary>
        string HashPassword(string password);

        /// <summary>
        /// Verifies a password against a BCrypt hash
        /// </summary>
        bool VerifyPassword(string password, string hash);
    }
}
