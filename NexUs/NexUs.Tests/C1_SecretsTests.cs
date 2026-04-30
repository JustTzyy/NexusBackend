using System.Text.Json;
using Xunit;

namespace NexUs.Tests;

/// <summary>
/// C-1: Verifies that appsettings.json contains no real credentials.
/// If any of these tests fail the production config file has been accidentally
/// re-populated with secrets that must be moved to environment variables.
/// </summary>
public class C1_SecretsTests
{
    private static readonly string AppSettingsPath = Path.Combine(
        AppContext.BaseDirectory, "..", "..", "..", "..", "NexUs", "appsettings.json");

    private JsonDocument LoadAppSettings()
    {
        var path = Path.GetFullPath(AppSettingsPath);
        Assert.True(File.Exists(path), $"appsettings.json not found at: {path}");
        return JsonDocument.Parse(File.ReadAllText(path));
    }

    [Fact]
    public void ConnectionString_DoesNotContain_RealPassword()
    {
        var doc = LoadAppSettings();
        var conn = doc.RootElement
            .GetProperty("ConnectionStrings")
            .GetProperty("DefaultConnection")
            .GetString() ?? "";

        Assert.DoesNotContain("Password=", conn, StringComparison.OrdinalIgnoreCase);
        Assert.StartsWith("SET_VIA_ENV", conn);
    }

    [Fact]
    public void JwtSettings_SecretKey_IsPlaceholder()
    {
        var doc = LoadAppSettings();
        var key = doc.RootElement
            .GetProperty("JwtSettings")
            .GetProperty("SecretKey")
            .GetString() ?? "";

        Assert.StartsWith("SET_VIA_ENV", key);
        Assert.DoesNotContain("NexUs-Super-Secret", key);
    }

    [Fact]
    public void EmailSettings_SenderPassword_IsPlaceholder()
    {
        var doc = LoadAppSettings();
        var pwd = doc.RootElement
            .GetProperty("EmailSettings")
            .GetProperty("SenderPassword")
            .GetString() ?? "";

        Assert.StartsWith("SET_VIA_ENV", pwd);
    }

    [Fact]
    public void RememberMe_Expiration_Is_AtMost_1440_Minutes()
    {
        // M-5: "Remember Me" JWT must not exceed 24 hours (1440 min)
        var doc = LoadAppSettings();
        var expiry = doc.RootElement
            .GetProperty("JwtSettings")
            .GetProperty("RememberMeExpirationInMinutes")
            .GetInt32();

        Assert.True(expiry <= 1440, $"RememberMeExpirationInMinutes={expiry} exceeds 24-hour maximum (1440)");
    }
}
