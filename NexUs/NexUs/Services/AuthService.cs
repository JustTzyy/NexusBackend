using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Text.Json;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using NexUs.Data;
using NexUs.Utilities;
using NexUs.Models.DTO.Auth;
using NexUs.Models.DTO.Notifications;
using NexUs.Services.Interfaces;

namespace NexUs.Services;

public class AuthService : IAuthService
{
    private readonly ApplicationDbContext _context;
    private readonly IPasswordService _passwordService;
    private readonly IEmailService _emailService;
    private readonly IConfiguration _configuration;
    private readonly ILogger<AuthService> _logger;
    private readonly IAuditService _auditService;
    private readonly ILeadService _leadService;
    private readonly IAutomationService _automationService;
    private readonly INotificationService _notificationService;

    public AuthService(
        ApplicationDbContext context,
        IPasswordService passwordService,
        IEmailService emailService,
        IConfiguration configuration,
        ILogger<AuthService> logger,
        IAuditService auditService,
        ILeadService leadService,
        IAutomationService automationService,
        INotificationService notificationService)
    {
        _context = context;
        _passwordService = passwordService;
        _emailService = emailService;
        _configuration = configuration;
        _logger = logger;
        _auditService = auditService;
        _leadService = leadService;
        _automationService = automationService;
        _notificationService = notificationService;
    }

    public async Task<LoginResponseDto?> LoginAsync(LoginDto dto)
    {
        // Find user by email (not soft-deleted)
        var user = await _context.Users
            .Include(u => u.UserRoles)
                .ThenInclude(ur => ur.Role)
                    .ThenInclude(r => r.RolePermissions)
                        .ThenInclude(rp => rp.Permission)
            .FirstOrDefaultAsync(u => u.Email.ToLower() == dto.Email.ToLower() && u.DeletedAt == null);

        if (user == null)
        {
            _logger.LogWarning("Login failed: User not found for email {Email}", dto.Email);
            return null;
        }

        // Get user credentials
        var credential = await _context.Set<NexUs.Models.Entities.UserCredential>()
            .FirstOrDefaultAsync(c => c.UserId == user.Id);

        if (credential == null)
        {
            _logger.LogWarning("Login failed: No credentials found for user {Email}", dto.Email);
            return null;
        }

        // Verify password
        if (!_passwordService.VerifyPassword(dto.Password, credential.PasswordHash))
        {
            _logger.LogWarning("Login failed: Invalid password for user {Email}", dto.Email);
            return null;
        }

        // Get roles
        var roles = user.UserRoles.Select(ur => ur.Role.Name).ToList();

        // Get permissions from user's roles
        var permissions = user.UserRoles
            .SelectMany(ur => ur.Role.RolePermissions)
            .Select(rp => rp.Permission.Name)
            .Distinct()
            .ToList();

        // Generate JWT with expiration based on Remember Me
        var token = GenerateJwtToken(user.Id, user.Email, user.FirstName, user.LastName, roles, dto.RememberMe);

        var fullName = string.Join(" ",
            new[] { user.FirstName, user.MiddleName, user.LastName, user.Suffix }
            .Where(s => !string.IsNullOrWhiteSpace(s)));

        _logger.LogInformation("User {Email} logged in successfully", dto.Email);

        // Log to audit log for Login History
        await _auditService.LogAsync("Auth", "Login", $"User logged in: {dto.Email}", user.Id);

        return new LoginResponseDto
        {
            Token = token,
            UserId = user.Id,
            FullName = fullName,
            Email = user.Email,
            Roles = roles,
            Permissions = permissions,
            IsPasswordChangeRequired = !credential.IsPasswordChanged
        };
    }

    public async Task<LoginResponseDto> RegisterAsync(NexUs.Models.DTO.Auth.RegisterDto dto)
    {
        // Check for duplicate email (including soft-deleted)
        var exists = await _context.Users
            .IgnoreQueryFilters()
            .AnyAsync(u => u.Email.ToLower() == dto.Email.ToLower());

        if (exists)
        {
            throw new InvalidOperationException("An account with this email already exists.");
        }

        // Create the user
        var user = new NexUs.Models.Entities.User
        {
            FirstName = "",
            LastName = "",
            Email = dto.Email
        };

        _context.Users.Add(user);
        await _context.SaveChangesAsync();

        // Hash password and create credential
        var credential = new NexUs.Models.Entities.UserCredential
        {
            UserId = user.Id,
            PasswordHash = _passwordService.HashPassword(dto.Password),
            IsPasswordChanged = true
        };

        _context.Set<NexUs.Models.Entities.UserCredential>().Add(credential);
        await _context.SaveChangesAsync();

        // Find the "Lead" role and assign it
        var leadRole = await _context.Roles
            .FirstOrDefaultAsync(r => r.Name == "Lead" && r.DeletedAt == null);

        if (leadRole != null)
        {
            _context.UserRoles.Add(new NexUs.Models.Entities.UserRole
            {
                UserId = user.Id,
                RoleId = leadRole.Id
            });
            await _context.SaveChangesAsync();
        }

        var roles = leadRole != null ? new List<string> { leadRole.Name } : new List<string>();

        // Get permissions from the Lead role
        var permissions = new List<string>();
        if (leadRole != null)
        {
            permissions = await _context.Set<NexUs.Models.Entities.RolePermission>()
                .Where(rp => rp.RoleId == leadRole.Id)
                .Include(rp => rp.Permission)
                .Select(rp => rp.Permission.Name)
                .Distinct()
                .ToListAsync();
        }

        // Generate JWT token
        var token = GenerateJwtToken(user.Id, user.Email, user.FirstName, user.LastName, roles);

        _logger.LogInformation("New user registered: {Email} with Lead role", dto.Email);
        await _auditService.LogAsync("Auth", "Register", $"New user registered: {dto.Email}", user.Id);

        // Marketing: create Lead record + trigger LeadCreated automation
        // Awaited sequentially — fast DB ops only; Task.Run was removed to prevent concurrent DbContext usage
        try
        {
            await _leadService.CreateFromUserAsync(user.Id, dto.Email, "", "", "Registration");
            await _automationService.TriggerAsync("LeadCreated", new Dictionary<string, object>
            {
                { "UserId", user.Id },
                { "Email", dto.Email },
                { "FirstName", "" }
            });
        }
        catch (Exception ex) { _logger.LogWarning(ex, "Marketing hook failed during registration for {Email}; user was created successfully", dto.Email); }

        // Queue welcome email — background service sends it; TriggerAsync keeps this within the request DbContext safely
        try
        {
            await _automationService.TriggerAsync("UserRegistered", new Dictionary<string, object>
            {
                { "Email", user.Email },
                { "FirstName", "" },
                { "UserName", user.Email },
                { "SetupUrl", _configuration["ApplicationSettings:FrontendUrl"] ?? "http://localhost:5174" }
            });
        }
        catch (Exception ex) { _logger.LogWarning(ex, "UserRegistered automation trigger failed for {Email}; registration completed successfully", user.Email); }

        // Notify Super Admin: new user registered
        try
        {
            await _notificationService.CreateAsync(new CreateNotificationDto
            {
                RecipientRole = "Super Admin",
                Title = "New User Registration",
                Message = $"A new user has registered: {dto.Email}.",
                Type = "General",
                Priority = "Normal",
                ReferenceId = user.Id,
                ReferenceType = "User"
            });
        }
        catch { /* silent */ }

        return new LoginResponseDto
        {
            Token = token,
            UserId = user.Id,
            FullName = "",
            Email = user.Email,
            Roles = roles,
            Permissions = permissions
        };
    }

    public async Task<LoginResponseDto?> GoogleLoginAsync(string? credential, string? accessToken)
    {
        try
        {
            string? email = null;

            if (!string.IsNullOrEmpty(credential))
            {
                // Flow 1: Decode the Google ID token (from GIS One Tap / embedded button)
                var handler = new JwtSecurityTokenHandler();
                var jsonToken = handler.ReadJwtToken(credential);
                email = jsonToken.Claims.FirstOrDefault(c => c.Type == "email")?.Value;
            }
            else if (!string.IsNullOrEmpty(accessToken))
            {
                // Flow 2: Verify access token via Google userinfo API (from popup OAuth flow)
                using var httpClient = new HttpClient();
                httpClient.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", accessToken);
                var response = await httpClient.GetAsync("https://www.googleapis.com/oauth2/v3/userinfo");
                if (response.IsSuccessStatusCode)
                {
                    var json = await response.Content.ReadAsStringAsync();
                    var userInfo = JsonSerializer.Deserialize<JsonElement>(json);
                    email = userInfo.GetProperty("email").GetString();
                }
            }

            if (string.IsNullOrEmpty(email))
            {
                _logger.LogWarning("Google login failed: No email in token");
                return null;
            }

            // Extract name from Google data
            string? googleFirstName = null;
            string? googleLastName = null;

            if (!string.IsNullOrEmpty(credential))
            {
                var handler2 = new JwtSecurityTokenHandler();
                var jsonToken2 = handler2.ReadJwtToken(credential);
                googleFirstName = jsonToken2.Claims.FirstOrDefault(c => c.Type == "given_name")?.Value;
                googleLastName = jsonToken2.Claims.FirstOrDefault(c => c.Type == "family_name")?.Value;
            }
            else if (!string.IsNullOrEmpty(accessToken))
            {
                using var httpClient2 = new HttpClient();
                httpClient2.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", accessToken);
                var resp = await httpClient2.GetAsync("https://www.googleapis.com/oauth2/v3/userinfo");
                if (resp.IsSuccessStatusCode)
                {
                    var json2 = await resp.Content.ReadAsStringAsync();
                    var info = JsonSerializer.Deserialize<JsonElement>(json2);
                    googleFirstName = info.TryGetProperty("given_name", out var gn) ? gn.GetString() : null;
                    googleLastName = info.TryGetProperty("family_name", out var fn) ? fn.GetString() : null;
                }
            }

            // Find existing user by email
            var user = await _context.Users
                .Include(u => u.UserRoles)
                    .ThenInclude(ur => ur.Role)
                        .ThenInclude(r => r.RolePermissions)
                            .ThenInclude(rp => rp.Permission)
                .FirstOrDefaultAsync(u => u.Email.ToLower() == email.ToLower() && u.DeletedAt == null);

            // Auto-register if user doesn't exist
            var isNewUser = user == null;
            if (user == null)
            {
                // Check if email exists as soft-deleted
                var softDeleted = await _context.Users
                    .IgnoreQueryFilters()
                    .AnyAsync(u => u.Email.ToLower() == email.ToLower() && u.DeletedAt != null);

                if (softDeleted)
                {
                    _logger.LogWarning("Google login failed: Account with email {Email} has been deactivated", email);
                    return null;
                }

                // Create new user
                user = new NexUs.Models.Entities.User
                {
                    FirstName = googleFirstName ?? "",
                    LastName = googleLastName ?? "",
                    Email = email
                };

                _context.Users.Add(user);
                await _context.SaveChangesAsync();

                // Create empty credential (Google-only user, no password)
                var cred = new NexUs.Models.Entities.UserCredential
                {
                    UserId = user.Id,
                    PasswordHash = "",
                    IsPasswordChanged = true
                };
                _context.Set<NexUs.Models.Entities.UserCredential>().Add(cred);
                await _context.SaveChangesAsync();

                // Assign Lead role
                var leadRole = await _context.Roles
                    .Include(r => r.RolePermissions)
                        .ThenInclude(rp => rp.Permission)
                    .FirstOrDefaultAsync(r => r.Name == "Lead" && r.DeletedAt == null);

                if (leadRole != null)
                {
                    _context.UserRoles.Add(new NexUs.Models.Entities.UserRole
                    {
                        UserId = user.Id,
                        RoleId = leadRole.Id
                    });
                    await _context.SaveChangesAsync();

                    user.UserRoles = new List<NexUs.Models.Entities.UserRole>
                    {
                        new NexUs.Models.Entities.UserRole { UserId = user.Id, RoleId = leadRole.Id, Role = leadRole }
                    };
                }

                _logger.LogInformation("New user auto-registered via Google: {Email}", email);
                await _auditService.LogAsync("Auth", "GoogleRegister", $"New user registered via Google: {email}", user.Id);

                // Marketing: create Lead record for the new Google user
                try
                {
                    await _leadService.CreateFromUserAsync(user.Id, email, googleFirstName ?? "", googleLastName ?? "", "Registration");
                    await _automationService.TriggerAsync("LeadCreated", new Dictionary<string, object>
                    {
                        { "UserId", user.Id },
                        { "Email", email },
                        { "FirstName", googleFirstName ?? "" }
                    });
                }
                catch (Exception ex) { _logger.LogWarning(ex, "Marketing hook failed during Google registration for {Email}; user was created successfully", email); }

                // Queue welcome email for new Google users
                var googleFullName = $"{googleFirstName} {googleLastName}".Trim();
                try
                {
                    await _automationService.TriggerAsync("UserRegistered", new Dictionary<string, object>
                    {
                        { "Email", email },
                        { "FirstName", googleFullName },
                        { "UserName", string.IsNullOrEmpty(googleFullName) ? email : googleFullName },
                        { "SetupUrl", _configuration["ApplicationSettings:FrontendUrl"] ?? "http://localhost:5174" }
                    });
                }
                catch (Exception ex) { _logger.LogWarning(ex, "UserRegistered automation trigger failed for Google user {Email}; registration completed successfully", email); }
            }

            // Get roles
            var roles = user.UserRoles.Select(ur => ur.Role.Name).ToList();

            // Get permissions from user's roles
            var permissions = user.UserRoles
                .SelectMany(ur => ur.Role.RolePermissions)
                .Select(rp => rp.Permission.Name)
                .Distinct()
                .ToList();

            // Generate JWT
            var token = GenerateJwtToken(user.Id, user.Email, user.FirstName, user.LastName, roles);

            var fullName = string.Join(" ",
                new[] { user.FirstName, user.MiddleName, user.LastName, user.Suffix }
                .Where(s => !string.IsNullOrWhiteSpace(s)));

            _logger.LogInformation("User {Email} logged in via Google successfully", email);

            // Log to audit log for Login History
            await _auditService.LogAsync("Auth", "Login", $"User logged in via Google: {email}", user.Id);

            return new LoginResponseDto
            {
                Token = token,
                UserId = user.Id,
                FullName = fullName,
                Email = user.Email,
                Roles = roles,
                Permissions = permissions,
                IsNewUser = isNewUser
            };
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Google login failed: Error processing Google credential");
            return null;
        }
    }

    private string GenerateJwtToken(int userId, string email, string firstName, string lastName, List<string> roles, bool rememberMe = false)
    {
        var jwtSettings = _configuration.GetSection("JwtSettings");
        var secretKey = jwtSettings["SecretKey"]!;
        var issuer = jwtSettings["Issuer"]!;
        var audience = jwtSettings["Audience"]!;
        var expirationMinutes = rememberMe
            ? int.Parse(jwtSettings["RememberMeExpirationInMinutes"] ?? "10080")
            : int.Parse(jwtSettings["ExpirationInMinutes"] ?? "60");

        var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(secretKey));
        var credentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

        var claims = new List<Claim>
        {
            new Claim(ClaimTypes.NameIdentifier, userId.ToString()),
            new Claim(ClaimTypes.Email, email),
            new Claim(ClaimTypes.GivenName, firstName),
            new Claim(ClaimTypes.Surname, lastName),
            new Claim("userId", userId.ToString()),
        };

        // Add role claims
        foreach (var role in roles)
        {
            claims.Add(new Claim(ClaimTypes.Role, role));
        }

        var token = new JwtSecurityToken(
            issuer: issuer,
            audience: audience,
            claims: claims,
            expires: DateTime.UtcNow.AddMinutes(expirationMinutes),
            signingCredentials: credentials
        );

        return new JwtSecurityTokenHandler().WriteToken(token);
    }

    public async Task<List<string>> GetUserPermissionsAsync(int userId)
    {
        var user = await _context.Users
            .Include(u => u.UserRoles)
                .ThenInclude(ur => ur.Role)
                    .ThenInclude(r => r.RolePermissions)
                        .ThenInclude(rp => rp.Permission)
            .FirstOrDefaultAsync(u => u.Id == userId && u.DeletedAt == null);

        if (user == null)
        {
            return new List<string>();
        }

        return user.UserRoles
            .SelectMany(ur => ur.Role.RolePermissions)
            .Select(rp => rp.Permission.Name)
            .Distinct()
            .ToList();
    }

    public async Task<bool> ChangePasswordAsync(int userId, string currentPassword, string newPassword)
    {
        var credential = await _context.Set<NexUs.Models.Entities.UserCredential>()
            .FirstOrDefaultAsync(c => c.UserId == userId);

        if (credential == null)
        {
            _logger.LogWarning("Change password failed: No credentials found for user {UserId}", userId);
            return false;
        }

        // Verify current password
        if (!_passwordService.VerifyPassword(currentPassword, credential.PasswordHash))
        {
            _logger.LogWarning("Change password failed: Invalid current password for user {UserId}", userId);
            return false;
        }

        // Hash and save new password
        credential.PasswordHash = _passwordService.HashPassword(newPassword);
        credential.IsPasswordChanged = true;
        credential.LastPasswordChange = DateTime.UtcNow;
        await _context.SaveChangesAsync();

        _logger.LogInformation("Password changed successfully for user {UserId}", userId);
        return true;
    }

    public async Task<bool> DeactivateAccountAsync(int userId)
    {
        var user = await _context.Users.FirstOrDefaultAsync(u => u.Id == userId && u.DeletedAt == null);

        if (user == null)
        {
            _logger.LogWarning("Deactivate account failed: User {UserId} not found", userId);
            return false;
        }

        // Soft delete the user
        user.DeletedAt = DateTime.UtcNow;
        await _context.SaveChangesAsync();

        _logger.LogInformation("Account deactivated for user {UserId}", userId);
        return true;
    }

    public async Task<bool> RequestPasswordResetAsync(string email)
    {
        var user = await _context.Users
            .FirstOrDefaultAsync(u => u.Email.ToLower() == email.ToLower() && u.DeletedAt == null);

        if (user == null)
        {
            _logger.LogWarning("Password reset requested for non-existent email: {Email}", email);
            // Return true to prevent email enumeration attacks
            return true;
        }

        // Invalidate existing tokens for this user
        var now = DateTimeHelper.PhilippineNow;
        var existingTokens = await _context.PasswordResetTokens
            .Where(t => t.UserId == user.Id && !t.IsUsed && t.ExpiresAt > now)
            .ToListAsync();
        
        foreach (var token in existingTokens)
        {
            token.IsUsed = true;
        }

        // Generate new token
        var resetToken = new NexUs.Models.Entities.PasswordResetToken
        {
            Token = Guid.NewGuid().ToString("N") + Guid.NewGuid().ToString("N"),
            UserId = user.Id,
            ExpiresAt = DateTimeHelper.PhilippineNow.AddHours(1),
            IsUsed = false
        };

        _context.PasswordResetTokens.Add(resetToken);
        await _context.SaveChangesAsync();

        // Build reset link
        var frontendUrl = _configuration["ApplicationSettings:FrontendUrl"] ?? "http://localhost:5173";
        var resetLink = $"{frontendUrl}/forgot-password/{resetToken.Token}";

        // Send email via automation pipeline
        var userName = $"{user.FirstName} {user.LastName}".Trim();
        var emailSent = await _automationService.TriggerAndSendImmediatelyAsync("PasswordResetRequested", new Dictionary<string, object>
        {
            { "Email", user.Email },
            { "FirstName", userName },
            { "UserName", userName },
            { "ResetLink", resetLink }
        });

        if (!emailSent)
        {
            _logger.LogWarning("Automation pipeline did not send password reset email to {Email}; falling back to direct send", email);
            emailSent = await _emailService.SendPasswordResetEmailAsync(user.Email, userName, resetLink);
        }

        if (emailSent)
        {
            _logger.LogInformation("Password reset email sent to: {Email}", email);
            await _auditService.LogAsync("Auth", "PasswordResetRequest", $"Password reset requested for: {email}", user.Id);
        }
        else
        {
            _logger.LogError("Failed to send password reset email to: {Email} via both automation and direct send", email);
        }

        return emailSent;
    }

    public async Task<bool> ResetPasswordAsync(string token, string newPassword)
    {
        var now = DateTimeHelper.PhilippineNow;
        var resetToken = await _context.PasswordResetTokens
            .Include(t => t.User)
            .FirstOrDefaultAsync(t => t.Token == token && !t.IsUsed && t.ExpiresAt > now);

        if (resetToken == null)
        {
            _logger.LogWarning("Invalid or expired password reset token attempted");
            return false;
        }

        // Get user credentials
        var credential = await _context.Set<NexUs.Models.Entities.UserCredential>()
            .FirstOrDefaultAsync(c => c.UserId == resetToken.UserId);

        if (credential == null)
        {
            _logger.LogWarning("No credentials found for user during password reset");
            return false;
        }

        // Update password
        credential.PasswordHash = _passwordService.HashPassword(newPassword);
        
        // Mark token as used
        resetToken.IsUsed = true;

        await _context.SaveChangesAsync();

        _logger.LogInformation("Password reset successful for user: {UserId}", resetToken.UserId);
        await _auditService.LogAsync("Auth", "PasswordReset", $"Password reset completed for: {resetToken.User?.Email}", resetToken.UserId);

        return true;
    }

    public async Task<ValidateTokenResponseDto?> ValidateResetTokenAsync(string token)
    {
        var now = DateTimeHelper.PhilippineNow;
        _logger.LogInformation("=== TOKEN VALIDATION DEBUG ===");
        _logger.LogInformation("Token from URL: {Token}", token);
        _logger.LogInformation("Current PH time: {Now}", now);

        // Check if token exists at all (no filters)
        var rawToken = await _context.PasswordResetTokens
            .FirstOrDefaultAsync(t => t.Token == token);

        if (rawToken == null)
        {
            _logger.LogWarning("Token NOT FOUND in database at all!");
        }
        else
        {
            _logger.LogInformation("Token FOUND: IsUsed={IsUsed}, ExpiresAt={ExpiresAt}, UserId={UserId}",
                rawToken.IsUsed, rawToken.ExpiresAt, rawToken.UserId);
            _logger.LogInformation("Is expired? {IsExpired} (ExpiresAt {ExpiresAt} > Now {Now} = {Result})",
                rawToken.ExpiresAt <= now, rawToken.ExpiresAt, now, rawToken.ExpiresAt > now);
        }

        var resetToken = await _context.PasswordResetTokens
            .Include(t => t.User)
            .FirstOrDefaultAsync(t => t.Token == token && !t.IsUsed && t.ExpiresAt > now);

        if (resetToken == null)
        {
            _logger.LogWarning("Token query with filters returned NULL");
            return new ValidateTokenResponseDto(false, null);
        }

        if (resetToken.User == null)
        {
            _logger.LogWarning("Token valid but User navigation is NULL (soft-deleted user or query filter issue)");
            return new ValidateTokenResponseDto(false, null);
        }

        _logger.LogInformation("Token is VALID for user: {Email}", resetToken.User.Email);
        return new ValidateTokenResponseDto(true, resetToken.User.Email);
    }

    public async Task<bool> SendOtpAsync(string email)
    {
        // Invalidate existing unused OTPs for this email
        var now = DateTimeHelper.PhilippineNow;
        var existingOtps = await _context.EmailVerificationOtps
            .Where(o => o.Email.ToLower() == email.ToLower() && !o.IsUsed && o.ExpiresAt > now)
            .ToListAsync();

        foreach (var otp in existingOtps)
        {
            otp.IsUsed = true;
        }

        // Generate 6-digit code
        var code = Random.Shared.Next(100000, 999999).ToString();

        var verificationOtp = new NexUs.Models.Entities.EmailVerificationOtp
        {
            Email = email,
            Code = code,
            ExpiresAt = DateTimeHelper.PhilippineNow.AddMinutes(10),
            IsUsed = false
        };

        _context.EmailVerificationOtps.Add(verificationOtp);
        await _context.SaveChangesAsync();

        var emailSent = await _automationService.TriggerAndSendImmediatelyAsync("OtpRequested", new Dictionary<string, object>
        {
            { "Email", email },
            { "FirstName", email },
            { "OtpCode", code },
            { "UserEmail", email }
        });

        if (!emailSent)
        {
            _logger.LogWarning("Automation pipeline did not send OTP email to {Email}; falling back to direct send", email);
            emailSent = await _emailService.SendOtpVerificationEmailAsync(email, code);
        }

        if (emailSent)
        {
            _logger.LogInformation("OTP verification email sent to: {Email}", email);
        }
        else
        {
            _logger.LogError("Failed to send OTP verification email to: {Email} via both automation and direct send", email);
        }

        return emailSent;
    }

    public async Task<bool> VerifyOtpAsync(string email, string code)
    {
        var now = DateTimeHelper.PhilippineNow;
        var otp = await _context.EmailVerificationOtps
            .FirstOrDefaultAsync(o =>
                o.Email.ToLower() == email.ToLower() &&
                o.Code == code &&
                !o.IsUsed &&
                o.ExpiresAt > now);

        if (otp == null)
        {
            _logger.LogWarning("OTP verification failed for email: {Email}", email);
            return false;
        }

        otp.IsUsed = true;
        await _context.SaveChangesAsync();

        _logger.LogInformation("OTP verified successfully for email: {Email}", email);
        return true;
    }

    public async Task<bool> EmailExistsAsync(string email)
    {
        return await _context.Users
            .AnyAsync(u => u.Email.ToLower() == email.ToLower() && u.DeletedAt == null);
    }
}

