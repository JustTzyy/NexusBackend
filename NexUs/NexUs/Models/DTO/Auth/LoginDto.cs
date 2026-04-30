using System.ComponentModel.DataAnnotations;

namespace NexUs.Models.DTO.Auth;

public class LoginDto
{
    [Required]
    [EmailAddress]
    public string Email { get; set; } = string.Empty;

    [Required]
    public string Password { get; set; } = string.Empty;

    public bool RememberMe { get; set; } = false;

    public string? CaptchaToken { get; set; }
}

public class GoogleLoginDto
{
    public string? Credential { get; set; }
    public string? AccessToken { get; set; }
}

public class LoginResponseDto
{
    public string Token { get; set; } = string.Empty;
    public int UserId { get; set; }
    public string FullName { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public List<string> Roles { get; set; } = new();
    public List<string> Permissions { get; set; } = new();
    public bool IsNewUser { get; set; } = false;
    public bool IsPasswordChangeRequired { get; set; } = false;
}
