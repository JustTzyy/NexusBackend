using System.Text.RegularExpressions;
using Xunit;
using Xunit.Abstractions;

namespace NexUs.Tests;

/// <summary>
/// H-3: Verifies that no controller catch block leaks internal exception
/// details to the client via ex.Message in error response lists.
/// </summary>
public class H3_ExceptionLeakTests(ITestOutputHelper output)
{
    private static readonly string ControllersDir = Path.GetFullPath(
        Path.Combine(AppContext.BaseDirectory, "..", "..", "..", "..", "NexUs", "Controllers"));

    // Detects the unsafe pattern: ErrorResponse("...", new List<string> { ex.Message })
    private static readonly Regex LeakPattern = new(
        @"new\s+List<string>\s*\{\s*ex\.Message\s*\}",
        RegexOptions.Compiled);

    // Detects catch blocks that still capture the exception variable as 'ex'
    // but are not for expected business exceptions (InvalidOperationException, UnauthorizedAccessException)
    private static readonly Regex UnsafeCatchPattern = new(
        @"catch\s*\(\s*Exception\s+ex\s*\)",
        RegexOptions.Compiled);

    [Fact]
    public void NoController_Has_ExMessage_In_ErrorResponse()
    {
        var files = Directory.GetFiles(ControllersDir, "*.cs");
        Assert.NotEmpty(files);

        var violations = new List<string>();
        foreach (var file in files)
        {
            var source = File.ReadAllText(file);
            var matches = LeakPattern.Matches(source);
            foreach (Match match in matches)
            {
                var lineNumber = source[..match.Index].Count(c => c == '\n') + 1;
                violations.Add($"{Path.GetFileName(file)}:{lineNumber}");
            }
        }

        if (violations.Any())
        {
            output.WriteLine("Controllers still leaking ex.Message:");
            violations.ForEach(output.WriteLine);
        }

        Assert.Empty(violations);
    }

    [Fact]
    public void NoController_CatchesException_WithVariable_ex()
    {
        var files = Directory.GetFiles(ControllersDir, "*.cs");

        var violations = new List<string>();
        foreach (var file in files)
        {
            var source = File.ReadAllText(file);
            var matches = UnsafeCatchPattern.Matches(source);
            foreach (Match match in matches)
            {
                var lineNumber = source[..match.Index].Count(c => c == '\n') + 1;
                violations.Add($"{Path.GetFileName(file)}:{lineNumber} — catch(Exception ex) found, message may be exposed");
            }
        }

        if (violations.Any())
        {
            output.WriteLine("Controllers still using 'catch (Exception ex)':");
            violations.ForEach(output.WriteLine);
        }

        Assert.Empty(violations);
    }
}
