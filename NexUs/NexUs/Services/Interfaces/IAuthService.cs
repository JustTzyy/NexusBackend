using NexUs.Models.DTO.Auth;

namespace NexUs.Services.Interfaces;

public interface IAuthService
{
    Task<LoginResponseDto?> LoginAsync(LoginDto dto);
    Task<LoginResponseDto> RegisterAsync(RegisterDto dto);
    Task<LoginResponseDto?> GoogleLoginAsync(string? credential, string? accessToken);
    Task<List<string>> GetUserPermissionsAsync(int userId);
    Task<bool> ChangePasswordAsync(int userId, string currentPassword, string newPassword);
    Task<bool> DeactivateAccountAsync(int userId);
    Task<bool> RequestPasswordResetAsync(string email);
    Task<bool> ResetPasswordAsync(string token, string newPassword);
    Task<ValidateTokenResponseDto?> ValidateResetTokenAsync(string token);
    Task<bool> SendOtpAsync(string email);
    Task<bool> VerifyOtpAsync(string email, string code);
    Task<bool> EmailExistsAsync(string email);
}

