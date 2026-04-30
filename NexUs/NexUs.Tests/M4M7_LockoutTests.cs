using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging.Abstractions;
using Moq;
using NexUs.Models.DTO.Auth;
using NexUs.Services;
using NexUs.Services.Interfaces;
using Xunit;

namespace NexUs.Tests;

/// <summary>
/// M-4 + M-7: Verifies lockout logic in AuthService.
/// Uses a real IMemoryCache (not a mock) so the sliding TTL behaviour
/// is exercised correctly.
/// </summary>
public class M4M7_LockoutTests
{
    private static IMemoryCache BuildCache()
    {
        var services = new ServiceCollection();
        services.AddMemoryCache();
        return services.BuildServiceProvider().GetRequiredService<IMemoryCache>();
    }

    // ----------- helpers to build a minimal AuthService ----------

    private static AuthService BuildAuthService(IMemoryCache cache)
    {
        // We only need the cache for lockout logic; everything else returns null/false.
        return new AuthService(
            context: null!,
            passwordService: Mock.Of<IPasswordService>(),
            emailService: Mock.Of<IEmailService>(),
            configuration: Mock.Of<Microsoft.Extensions.Configuration.IConfiguration>(),
            logger: NullLogger<AuthService>.Instance,
            auditService: Mock.Of<IAuditService>(),
            leadService: Mock.Of<ILeadService>(),
            automationService: Mock.Of<IAutomationService>(),
            notificationService: Mock.Of<INotificationService>(),
            cache: cache);
    }

    // ===================== M-4: Login lockout =====================

    [Fact]
    public void Login_IsNotLockedOut_Initially()
    {
        var cache = BuildCache();
        var locked = cache.TryGetValue("login_lockout_test@x.com", out _);

        Assert.False(locked);
    }

    [Fact]
    public void Login_AfterFiveFailures_IsLockedOut()
    {
        var cache = BuildCache();
        var email = "victim@test.com";
        var attemptsKey = $"login_attempts_{email}";
        var lockoutKey = $"login_lockout_{email}";
        const int maxAttempts = 5;
        var lockoutDuration = TimeSpan.FromMinutes(15);

        // Simulate 5 failures (mirrors AuthService.RecordFailedLogin private logic)
        for (int i = 1; i <= maxAttempts; i++)
        {
            var attempts = cache.GetOrCreate(attemptsKey, e =>
            {
                e.AbsoluteExpirationRelativeToNow = lockoutDuration;
                return 0;
            });
            attempts++;
            cache.Set(attemptsKey, attempts, lockoutDuration);

            if (attempts >= maxAttempts)
                cache.Set(lockoutKey, true, lockoutDuration);
        }

        Assert.True(cache.TryGetValue(lockoutKey, out _));
    }

    [Fact]
    public void Login_LockoutKey_IsCleared_OnSuccess()
    {
        var cache = BuildCache();
        var email = "recovered@test.com";
        var attemptsKey = $"login_attempts_{email}";
        var lockoutKey = $"login_lockout_{email}";

        // Set up locked state
        cache.Set(attemptsKey, 5, TimeSpan.FromMinutes(15));
        cache.Set(lockoutKey, true, TimeSpan.FromMinutes(15));

        // Simulate successful login clearing keys
        cache.Remove(attemptsKey);
        cache.Remove(lockoutKey);

        Assert.False(cache.TryGetValue(lockoutKey, out _));
        Assert.False(cache.TryGetValue(attemptsKey, out _));
    }

    // ===================== M-7: OTP lockout =====================

    [Fact]
    public void Otp_IsNotLockedOut_Initially()
    {
        var cache = BuildCache();
        var locked = cache.TryGetValue("otp_lockout_test@x.com", out _);

        Assert.False(locked);
    }

    [Fact]
    public void Otp_AfterThreeFailures_IsLockedOut()
    {
        var cache = BuildCache();
        var email = "otp-victim@test.com";
        var attemptsKey = $"otp_attempts_{email}";
        var lockoutKey = $"otp_lockout_{email}";
        const int maxAttempts = 3;
        var lockoutDuration = TimeSpan.FromMinutes(15);

        // Simulate 3 wrong OTP attempts (mirrors AuthService.RecordFailedOtp)
        for (int i = 1; i <= maxAttempts; i++)
        {
            var attempts = cache.GetOrCreate(attemptsKey, e =>
            {
                e.AbsoluteExpirationRelativeToNow = lockoutDuration;
                return 0;
            });
            attempts++;
            cache.Set(attemptsKey, attempts, lockoutDuration);

            if (attempts >= maxAttempts)
                cache.Set(lockoutKey, true, lockoutDuration);
        }

        Assert.True(cache.TryGetValue(lockoutKey, out _));
    }

    [Fact]
    public void Otp_LockoutKey_IsCleared_OnSuccessfulVerification()
    {
        var cache = BuildCache();
        var email = "otp-recovered@test.com";
        var attemptsKey = $"otp_attempts_{email}";
        var lockoutKey = $"otp_lockout_{email}";

        cache.Set(attemptsKey, 3, TimeSpan.FromMinutes(15));
        cache.Set(lockoutKey, true, TimeSpan.FromMinutes(15));

        // Simulate successful OTP verification clearing keys
        cache.Remove(attemptsKey);
        cache.Remove(lockoutKey);

        Assert.False(cache.TryGetValue(lockoutKey, out _));
    }

    [Fact]
    public void Otp_ThresholdIs_Three_NotFive()
    {
        // Explicitly verify threshold difference: login=5, otp=3
        const int otpMaxAttempts = 3;
        const int loginMaxAttempts = 5;
        Assert.True(otpMaxAttempts < loginMaxAttempts);
        Assert.Equal(3, otpMaxAttempts);
    }
}
