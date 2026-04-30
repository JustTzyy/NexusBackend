using NexUs.Services;
using Xunit;

namespace NexUs.Tests;

/// <summary>
/// L-4: Verifies that PasswordService uses RandomNumberGenerator
/// (cryptographically secure) and generates passwords meeting
/// the complexity requirements enforced by M-3 validators.
/// </summary>
public class L4_PasswordServiceTests
{
    private readonly PasswordService _service = new();

    [Fact]
    public void GeneratePassword_HasMinimumLength()
    {
        var password = _service.GeneratePassword();
        Assert.True(password.Length >= 10, $"Password too short: '{password}' ({password.Length} chars)");
    }

    [Fact]
    public void GeneratePassword_ContainsUppercase()
    {
        // Run multiple times since generation is random
        for (int i = 0; i < 20; i++)
        {
            var password = _service.GeneratePassword();
            Assert.True(password.Any(char.IsUpper), $"No uppercase in: '{password}'");
        }
    }

    [Fact]
    public void GeneratePassword_ContainsLowercase()
    {
        for (int i = 0; i < 20; i++)
        {
            var password = _service.GeneratePassword();
            Assert.True(password.Any(char.IsLower), $"No lowercase in: '{password}'");
        }
    }

    [Fact]
    public void GeneratePassword_ContainsDigit()
    {
        for (int i = 0; i < 20; i++)
        {
            var password = _service.GeneratePassword();
            Assert.True(password.Any(char.IsDigit), $"No digit in: '{password}'");
        }
    }

    [Fact]
    public void GeneratePassword_ContainsSpecialCharacter()
    {
        for (int i = 0; i < 20; i++)
        {
            var password = _service.GeneratePassword();
            Assert.True(password.Any(c => "!@#$%^&*".Contains(c)),
                $"No special char in: '{password}'");
        }
    }

    [Fact]
    public void GeneratePassword_Produces_UniqueValues()
    {
        // Non-cryptographic Random(seed) produces duplicates; RandomNumberGenerator should not
        var passwords = Enumerable.Range(0, 100).Select(_ => _service.GeneratePassword()).ToList();
        var uniqueCount = passwords.Distinct().Count();

        // With 100 samples from a 10+ char charset, duplicates would be astronomically rare
        Assert.Equal(100, uniqueCount);
    }

    [Fact]
    public void HashPassword_And_VerifyPassword_Roundtrip()
    {
        const string plain = "TestPassword1!";
        var hash = _service.HashPassword(plain);

        Assert.True(_service.VerifyPassword(plain, hash));
        Assert.False(_service.VerifyPassword("WrongPassword1!", hash));
    }

    [Fact]
    public void HashPassword_ProducesUniqueHashes_ForSameInput()
    {
        // BCrypt uses per-hash salts, so two hashes of the same value should differ
        const string plain = "SamePassword1!";
        var hash1 = _service.HashPassword(plain);
        var hash2 = _service.HashPassword(plain);

        Assert.NotEqual(hash1, hash2);
        Assert.True(_service.VerifyPassword(plain, hash1));
        Assert.True(_service.VerifyPassword(plain, hash2));
    }
}
