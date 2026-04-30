using System.Text.RegularExpressions;
using Xunit;
using Xunit.Abstractions;

namespace NexUs.Tests;

/// <summary>
/// H-2: Verifies Swagger is gated behind IsDevelopment().
/// H-6: Verifies Google OAuth auto-registration block is removed.
/// Also checks frontend source for hardcoded OAuth client IDs.
/// </summary>
public class H2H6_InfrastructureTests(ITestOutputHelper output)
{
    private static string ReadBackend(string relativePath)
    {
        var path = Path.GetFullPath(
            Path.Combine(AppContext.BaseDirectory, "..", "..", "..", "..", "NexUs", relativePath));
        Assert.True(File.Exists(path), $"File not found: {path}");
        return File.ReadAllText(path);
    }

    private static string ReadFrontend(string relativePath)
    {
        var path = Path.GetFullPath(
            Path.Combine(AppContext.BaseDirectory, "..", "..", "..", "..", "..",
                "JussTzyLearnFLow", "src", relativePath));
        return File.Exists(path) ? File.ReadAllText(path) : string.Empty;
    }

    // --- H-2: Swagger gating ---

    [Fact]
    public void Program_SwaggerUI_IsWrapped_InIsDevelopment()
    {
        var source = ReadBackend("Program.cs");

        // Verify Swagger is inside an IsDevelopment block
        var devBlock = Regex.Match(source,
            @"IsDevelopment\(\)[\s\S]+?UseSwaggerUI",
            RegexOptions.Singleline);

        Assert.True(devBlock.Success,
            "Swagger is not gated behind IsDevelopment() — it would be exposed in production.");
    }

    [Fact]
    public void Program_SwaggerUI_IsNotUnconditional()
    {
        var source = ReadBackend("Program.cs");
        var lines = source.Split('\n');

        // Find every line that calls UseSwaggerUI() and check the nearest preceding
        // non-blank line contains IsDevelopment or is an open-brace from such a block.
        for (int i = 0; i < lines.Length; i++)
        {
            if (!lines[i].Contains("app.UseSwaggerUI()")) continue;

            // Walk backwards to find the enclosing if condition
            bool foundDevGuard = false;
            for (int j = i - 1; j >= 0 && j >= i - 10; j--)
            {
                if (lines[j].Contains("IsDevelopment()"))
                {
                    foundDevGuard = true;
                    break;
                }
            }
            Assert.True(foundDevGuard,
                $"app.UseSwaggerUI() on line {i + 1} is not inside an IsDevelopment() block.");
        }
    }

    // --- H-6: No OAuth auto-registration ---

    [Fact]
    public void AuthService_DoesNotAutoCreate_GoogleUser()
    {
        var source = ReadBackend("Services/AuthService.cs");

        // The removed auto-registration block created a new User entity for unknown Google emails.
        // After the fix, there should be no "Create new user" comment or similar pattern
        // for the Google flow.
        Assert.DoesNotContain("Create new user", source, StringComparison.OrdinalIgnoreCase);
        Assert.DoesNotContain("auto-register", source, StringComparison.OrdinalIgnoreCase);
    }

    [Fact]
    public void AuthService_GoogleLogin_ReturnsNull_ForUnknownUser()
    {
        var source = ReadBackend("Services/AuthService.cs");

        // Verify the logic that returns null when user is not found (no auto-creation)
        Assert.Contains("Google login failed: No account for", source);
        Assert.Contains("return null;", source);
    }

    // --- M-6: No hardcoded OAuth client IDs in frontend source ---

    [Fact]
    public void MainJsx_DoesNotContain_HardcodedGoogleClientId()
    {
        var source = ReadFrontend("main.jsx");
        if (string.IsNullOrEmpty(source)) return; // frontend may not be present in CI

        Assert.DoesNotContain("119831744946", source);
        Assert.Contains("import.meta.env.VITE_GOOGLE_CLIENT_ID", source);
    }

    [Fact]
    public void AuthConfigJs_DoesNotContain_HardcodedAzureClientId()
    {
        var source = ReadFrontend("authConfig.js");
        if (string.IsNullOrEmpty(source)) return;

        Assert.DoesNotContain("51169adc-9edc-4f6e-9534-29019ca7ed6e", source);
        Assert.Contains("import.meta.env.VITE_AZURE_CLIENT_ID", source);
    }

    // --- M-1: No localStorage for JWT tokens in AuthContext ---

    [Fact]
    public void AuthContext_TokenStorage_NeverWritesToLocalStorage()
    {
        var source = ReadFrontend("contexts/AuthContext.jsx");
        if (string.IsNullOrEmpty(source)) return;

        // The only localStorage calls that should remain are removeItem (cleanup on logout/expiry).
        // No login path should write the JWT to localStorage.
        var setItemLines = source
            .Split('\n')
            .Select((line, idx) => (line, idx))
            .Where(x => x.line.Contains("localStorage.setItem") && x.line.Contains("accessToken"))
            .ToList();

        if (setItemLines.Any())
        {
            output.WriteLine("localStorage.setItem('accessToken') found on these lines:");
            setItemLines.ForEach(x => output.WriteLine($"  {x.idx + 1}: {x.line.Trim()}"));
        }

        Assert.Empty(setItemLines);
    }
}
