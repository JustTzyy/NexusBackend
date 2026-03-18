using NexUs.Services.Interfaces;
using BCrypt.Net;

namespace NexUs.Services
{
    public class PasswordService : IPasswordService
    {
        private const string PasswordChars = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789!@#$%^&*";
        private readonly Random _random = new Random();

        public string GeneratePassword()
        {
            // Generate password between 8-12 characters
            int length = _random.Next(8, 13);
            var password = new char[length];

            // Ensure at least one of each type
            password[0] = "abcdefghijklmnopqrstuvwxyz"[_random.Next(26)]; // lowercase
            password[1] = "ABCDEFGHIJKLMNOPQRSTUVWXYZ"[_random.Next(26)]; // uppercase
            password[2] = "0123456789"[_random.Next(10)]; // digit
            password[3] = "!@#$%^&*"[_random.Next(8)]; // special char

            // Fill remaining with random characters
            for (int i = 4; i < length; i++)
            {
                password[i] = PasswordChars[_random.Next(PasswordChars.Length)];
            }

            // Shuffle the password
            return new string(password.OrderBy(x => _random.Next()).ToArray());
        }

        public string HashPassword(string password)
        {
            // Use BCrypt with work factor of 12 (recommended)
            return BCrypt.Net.BCrypt.HashPassword(password, 12);
        }

        public bool VerifyPassword(string password, string hash)
        {
            try
            {
                return BCrypt.Net.BCrypt.Verify(password, hash);
            }
            catch
            {
                return false;
            }
        }
    }
}
