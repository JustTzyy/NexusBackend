using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.RateLimiting;
using NexUs.Exceptions;
using NexUs.Models.DTO.Auth;
using NexUs.Models.DTO.Common;
using NexUs.Services.Interfaces;
using System.Security.Claims;

namespace NexUs.Controllers;

[Route("api/[controller]")]
[ApiController]
public class AuthController : ControllerBase
{
    private readonly IAuthService _authService;
    private readonly IOperationLogService _operationLogService;
    private readonly IAuditService _auditService;
    private readonly IRecaptchaService _recaptcha;

    public AuthController(IAuthService authService, IOperationLogService operationLogService, IAuditService auditService, IRecaptchaService recaptcha)
    {
        _authService = authService;
        _operationLogService = operationLogService;
        _auditService = auditService;
        _recaptcha = recaptcha;
    }

    /// <summary>
    /// Register a new user (automatically assigned Lead role)
    /// </summary>
    [HttpPost("register")]
    [EnableRateLimiting("auth")]
    public async Task<ActionResult<ApiResponse<LoginResponseDto>>> Register([FromBody] RegisterDto dto)
    {
        try
        {
            if (!await _recaptcha.VerifyAsync(dto.CaptchaToken ?? "", "register"))
                return BadRequest(ApiResponse<LoginResponseDto>.ErrorResponse("CAPTCHA verification failed. Please try again."));

            var result = await _authService.RegisterAsync(dto);

            var ip = HttpContext.Connection.RemoteIpAddress?.ToString();
            var device = Request.Headers["User-Agent"].ToString();

            await _operationLogService.LogAuthActivityAsync(result.UserId, "register", "success", ip, device, null);

            return Ok(ApiResponse<LoginResponseDto>.SuccessResponse(result, "Registration successful"));
        }
        catch (InvalidOperationException ex)
        {
            return BadRequest(ApiResponse<LoginResponseDto>.ErrorResponse(ex.Message));
        }
        catch (Exception)
        {
            return StatusCode(500, ApiResponse<LoginResponseDto>.ErrorResponse("An error occurred during registration"));
        }
    }

    /// <summary>
    /// Check if an email is already registered
    /// </summary>
    [HttpGet("check-email")]
    public async Task<ActionResult<ApiResponse<object>>> CheckEmail([FromQuery] string email)
    {
        try
        {
            var exists = await _authService.EmailExistsAsync(email);
            return Ok(ApiResponse<object>.SuccessResponse(new { exists }, exists ? "Email is already registered" : "Email is available"));
        }
        catch (Exception)
        {
            return StatusCode(500, ApiResponse<object>.ErrorResponse("An error occurred"));
        }
    }

    /// <summary>
    /// Send OTP verification code to email
    /// </summary>
    [HttpPost("send-otp")]
    [EnableRateLimiting("auth")]
    public async Task<ActionResult<ApiResponse<object>>> SendOtp([FromBody] SendOtpDto dto)
    {
        try
        {
            await _authService.SendOtpAsync(dto.Email);
            return Ok(ApiResponse<object>.SuccessResponse(null, "If this email is valid, a verification code has been sent."));
        }
        catch (Exception)
        {
            return StatusCode(500, ApiResponse<object>.ErrorResponse("An error occurred while sending verification code"));
        }
    }

    /// <summary>
    /// Verify OTP code
    /// </summary>
    [HttpPost("verify-otp")]
    public async Task<ActionResult<ApiResponse<object>>> VerifyOtp([FromBody] VerifyOtpDto dto)
    {
        try
        {
            var result = await _authService.VerifyOtpAsync(dto.Email, dto.Code);

            if (!result)
            {
                return BadRequest(ApiResponse<object>.ErrorResponse("Invalid or expired verification code"));
            }

            return Ok(ApiResponse<object>.SuccessResponse(null, "Email verified successfully"));
        }
        catch (AccountLockedException ex)
        {
            return StatusCode(423, new { success = false, message = ex.Message, data = new { remainingMinutes = ex.RemainingMinutes } });
        }
        catch (Exception)
        {
            return StatusCode(500, ApiResponse<object>.ErrorResponse("An error occurred during verification"));
        }
    }

    /// <summary>
    /// Login with email and password
    /// </summary>
    [HttpPost("login")]
    [EnableRateLimiting("auth")]
    public async Task<ActionResult<ApiResponse<LoginResponseDto>>> Login([FromBody] LoginDto dto)
    {
        try
        {
            if (!await _recaptcha.VerifyAsync(dto.CaptchaToken ?? "", "login"))
                return BadRequest(ApiResponse<LoginResponseDto>.ErrorResponse("CAPTCHA verification failed. Please try again."));

            var ip = HttpContext.Connection.RemoteIpAddress?.ToString();
            var device = Request.Headers["User-Agent"].ToString();

            var result = await _authService.LoginAsync(dto);

            if (result == null)
            {
                await _operationLogService.LogAuthActivityAsync(null, "failed_login", "failed", ip, device, null);
                return Unauthorized(ApiResponse<LoginResponseDto>.ErrorResponse("Invalid email or password"));
            }

            await _operationLogService.LogAuthActivityAsync(result.UserId, "login", "success", ip, device, null);
            return Ok(ApiResponse<LoginResponseDto>.SuccessResponse(result, "Login successful"));
        }
        catch (AccountLockedException ex)
        {
            return StatusCode(423, new { success = false, message = ex.Message, data = new { remainingMinutes = ex.RemainingMinutes } });
        }
        catch (Exception)
        {
            return StatusCode(500, ApiResponse<LoginResponseDto>.ErrorResponse("An error occurred during login"));
        }
    }

    /// <summary>
    /// Login with Google credential (existing users only)
    /// </summary>
    [HttpPost("google-login")]
    [EnableRateLimiting("auth")]
    public async Task<ActionResult<ApiResponse<LoginResponseDto>>> GoogleLogin([FromBody] GoogleLoginDto dto)
    {
        try
        {
            var ip = HttpContext.Connection.RemoteIpAddress?.ToString();
            var device = Request.Headers["User-Agent"].ToString();

            var result = await _authService.GoogleLoginAsync(dto.Credential, dto.AccessToken);

            if (result == null)
            {
                await _operationLogService.LogAuthActivityAsync(null, "failed_login", "failed", ip, device, null);
                return Unauthorized(ApiResponse<LoginResponseDto>.ErrorResponse("No account found for this Google email. Please contact your administrator."));
            }

            await _operationLogService.LogAuthActivityAsync(result.UserId, "login", "success", ip, device, null);
            return Ok(ApiResponse<LoginResponseDto>.SuccessResponse(result, "Google login successful"));
        }
        catch (Exception)
        {
            return StatusCode(500, ApiResponse<LoginResponseDto>.ErrorResponse("An error occurred during Google login"));
        }
    }

    /// <summary>
    /// Logout current authenticated user
    /// </summary>
    [HttpPost("logout")]
    [Authorize]
    public async Task<ActionResult<ApiResponse<object>>> Logout()
    {
        try
        {
            var userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value
                      ?? User.FindFirst("userId")?.Value;
            var parsedUserId = int.TryParse(userId, out var id) ? id : (int?)null;

            var ip = HttpContext.Connection.RemoteIpAddress?.ToString();
            var device = Request.Headers["User-Agent"].ToString();

            await _operationLogService.LogAuthActivityAsync(parsedUserId, "logout", "success", ip, device, null);

            // Log to audit log for Login History
            var email = User.FindFirst(ClaimTypes.Email)?.Value ?? "Unknown";
            await _auditService.LogAsync("Auth", "Logout", $"User logged out: {email}", parsedUserId);

            return Ok(ApiResponse<object>.SuccessResponse(null, "Logged out successfully"));
        }
        catch (Exception)
        {
            return StatusCode(500, ApiResponse<object>.ErrorResponse("An error occurred during logout"));
        }
    }

    /// <summary>
    /// Get current authenticated user info
    /// </summary>
    [HttpGet("me")]
    [Authorize]
    public async Task<ActionResult<ApiResponse<LoginResponseDto>>> GetMe()
    {
        try
        {
            var userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value
                      ?? User.FindFirst("userId")?.Value;
            var email = User.FindFirst(ClaimTypes.Email)?.Value ?? "";
            var firstName = User.FindFirst(ClaimTypes.GivenName)?.Value ?? "";
            var lastName = User.FindFirst(ClaimTypes.Surname)?.Value ?? "";
            var roles = User.FindAll(ClaimTypes.Role).Select(c => c.Value).ToList();

            var fullName = $"{firstName} {lastName}".Trim();

            // Fetch permissions from database
            var parsedUserId = int.TryParse(userId, out var id) ? id : 0;
            var permissions = await _authService.GetUserPermissionsAsync(parsedUserId);

            var response = new LoginResponseDto
            {
                Token = "", // Don't return token on /me
                UserId = parsedUserId,
                FullName = fullName,
                Email = email,
                Roles = roles,
                Permissions = permissions
            };

            return Ok(ApiResponse<LoginResponseDto>.SuccessResponse(response, "User info retrieved"));
        }
        catch (Exception)
        {
            return StatusCode(500, ApiResponse<LoginResponseDto>.ErrorResponse("An error occurred"));
        }
    }

    /// <summary>
    /// Change password for current authenticated user
    /// </summary>
    [HttpPost("change-password")]
    [Authorize]
    public async Task<ActionResult<ApiResponse<object>>> ChangePassword([FromBody] ChangePasswordDto dto)
    {
        try
        {
            var userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value
                      ?? User.FindFirst("userId")?.Value;
            var parsedUserId = int.TryParse(userId, out var id) ? id : 0;

            if (parsedUserId == 0)
            {
                return Unauthorized(ApiResponse<object>.ErrorResponse("User not authenticated"));
            }

            var result = await _authService.ChangePasswordAsync(parsedUserId, dto.CurrentPassword, dto.NewPassword);

            if (!result)
            {
                return BadRequest(ApiResponse<object>.ErrorResponse("Invalid current password"));
            }

            return Ok(ApiResponse<object>.SuccessResponse(null, "Password changed successfully"));
        }
        catch (Exception)
        {
            return StatusCode(500, ApiResponse<object>.ErrorResponse("An error occurred while changing password"));
        }
    }

    /// <summary>
    /// Deactivate (soft delete) current authenticated user's account
    /// </summary>
    [HttpPost("deactivate")]
    [Authorize]
    public async Task<ActionResult<ApiResponse<object>>> DeactivateAccount()
    {
        try
        {
            var userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value
                      ?? User.FindFirst("userId")?.Value;
            var parsedUserId = int.TryParse(userId, out var id) ? id : 0;

            if (parsedUserId == 0)
            {
                return Unauthorized(ApiResponse<object>.ErrorResponse("User not authenticated"));
            }

            var result = await _authService.DeactivateAccountAsync(parsedUserId);

            if (!result)
            {
                return BadRequest(ApiResponse<object>.ErrorResponse("Failed to deactivate account"));
            }

            return Ok(ApiResponse<object>.SuccessResponse(null, "Account deactivated successfully"));
        }
        catch (Exception)
        {
            return StatusCode(500, ApiResponse<object>.ErrorResponse("An error occurred while deactivating account"));
        }
    }

    /// <summary>
    /// Request password reset email
    /// </summary>
    [HttpPost("forgot-password")]
    [EnableRateLimiting("auth")]
    public async Task<ActionResult<ApiResponse<object>>> ForgotPassword([FromBody] ForgotPasswordDto dto)
    {
        try
        {
            if (!await _recaptcha.VerifyAsync(dto.CaptchaToken ?? "", "forgot_password"))
                return BadRequest(ApiResponse<object>.ErrorResponse("CAPTCHA verification failed. Please try again."));

            var result = await _authService.RequestPasswordResetAsync(dto.Email);
            
            // Always return success to prevent email enumeration
            return Ok(ApiResponse<object>.SuccessResponse(null, "If an account exists with this email, you will receive a password reset link."));
        }
        catch (Exception)
        {
            return StatusCode(500, ApiResponse<object>.ErrorResponse("An error occurred"));
        }
    }

    /// <summary>
    /// Reset password with token
    /// </summary>
    [HttpPost("reset-password")]
    public async Task<ActionResult<ApiResponse<object>>> ResetPassword([FromBody] ResetPasswordDto dto)
    {
        try
        {
            var result = await _authService.ResetPasswordAsync(dto.Token, dto.NewPassword);

            if (!result)
            {
                return BadRequest(ApiResponse<object>.ErrorResponse("Invalid or expired reset token"));
            }

            return Ok(ApiResponse<object>.SuccessResponse(null, "Password reset successfully"));
        }
        catch (Exception)
        {
            return StatusCode(500, ApiResponse<object>.ErrorResponse("An error occurred"));
        }
    }

    /// <summary>
    /// Validate password reset token
    /// </summary>
    [HttpGet("validate-reset-token/{token}")]
    public async Task<ActionResult<ApiResponse<ValidateTokenResponseDto>>> ValidateResetToken(string token)
    {
        try
        {
            var result = await _authService.ValidateResetTokenAsync(token);
            // Always return 200 to prevent token enumeration via status code
            if (result == null || !result.IsValid)
                return Ok(ApiResponse<ValidateTokenResponseDto>.ErrorResponse("Invalid or expired reset token"));
            return Ok(ApiResponse<ValidateTokenResponseDto>.SuccessResponse(result, "Token is valid"));
        }
        catch (Exception)
        {
            return Ok(ApiResponse<ValidateTokenResponseDto>.ErrorResponse("Invalid or expired reset token"));
        }
    }
}

