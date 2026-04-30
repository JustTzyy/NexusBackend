using System.Security.Cryptography;
using NexUs.Services.Interfaces;

namespace NexUs.Services
{
    public class PasswordService : IPasswordService
    {
        private const string LowerChars = "abcdefghijklmnopqrstuvwxyz";
        private const string UpperChars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
        private const string DigitChars = "0123456789";
        private const string SpecialChars = "!@#$%^&*";
        private const string AllChars = LowerChars + UpperChars + DigitChars + SpecialChars;

        public string GeneratePassword()
        {
            int length = RandomNumberGenerator.GetInt32(10, 15);
            var chars = new char[length];

            chars[0] = LowerChars[RandomNumberGenerator.GetInt32(LowerChars.Length)];
            chars[1] = UpperChars[RandomNumberGenerator.GetInt32(UpperChars.Length)];
            chars[2] = DigitChars[RandomNumberGenerator.GetInt32(DigitChars.Length)];
            chars[3] = SpecialChars[RandomNumberGenerator.GetInt32(SpecialChars.Length)];

            for (int i = 4; i < length; i++)
                chars[i] = AllChars[RandomNumberGenerator.GetInt32(AllChars.Length)];

            // Cryptographically shuffle
            for (int i = length - 1; i > 0; i--)
            {
                int j = RandomNumberGenerator.GetInt32(i + 1);
                (chars[i], chars[j]) = (chars[j], chars[i]);
            }

            return new string(chars);
        }

        public string HashPassword(string password)
        {
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
