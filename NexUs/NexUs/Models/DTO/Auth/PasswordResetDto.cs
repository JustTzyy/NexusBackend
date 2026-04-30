namespace NexUs.Models.DTO.Auth
{
    public record ForgotPasswordDto(string Email, string? CaptchaToken);
    
    public record ResetPasswordDto(string Token, string NewPassword);
    
    public record ValidateTokenResponseDto(bool IsValid);
}
