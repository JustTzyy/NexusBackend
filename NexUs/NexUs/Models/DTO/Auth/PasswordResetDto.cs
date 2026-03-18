namespace NexUs.Models.DTO.Auth
{
    public record ForgotPasswordDto(string Email);
    
    public record ResetPasswordDto(string Token, string NewPassword);
    
    public record ValidateTokenResponseDto(bool IsValid, string? Email);
}
