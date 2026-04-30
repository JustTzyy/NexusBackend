using System.Text.Json;
using NexUs.Services.Interfaces;

namespace NexUs.Services;

public class RecaptchaService(IHttpClientFactory httpClientFactory, IConfiguration configuration) : IRecaptchaService
{
    private const double MinScore = 0.5;

    public async Task<bool> VerifyAsync(string token, string action)
    {
        if (string.IsNullOrWhiteSpace(token)) return false;

        var secretKey = configuration["RecaptchaSettings:SecretKey"];
        var client = httpClientFactory.CreateClient();

        var response = await client.PostAsync(
            $"https://www.google.com/recaptcha/api/siteverify?secret={secretKey}&response={token}",
            null);

        if (!response.IsSuccessStatusCode) return false;

        var json = await response.Content.ReadAsStringAsync();
        using var doc = JsonDocument.Parse(json);
        var root = doc.RootElement;

        var success = root.TryGetProperty("success", out var s) && s.GetBoolean();
        var score = root.TryGetProperty("score", out var sc) ? sc.GetDouble() : 0;

        return success && score >= MinScore;
    }
}
