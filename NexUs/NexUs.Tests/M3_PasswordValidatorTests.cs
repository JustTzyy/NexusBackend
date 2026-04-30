using FluentValidation.TestHelper;
using NexUs.Models.DTO.Auth;
using NexUs.Validators.Auth;
using Xunit;

namespace NexUs.Tests;

/// <summary>
/// M-3: Verifies that password validators enforce complexity requirements —
/// uppercase, lowercase, digit, and special character.
/// </summary>
public class M3_PasswordValidatorTests
{
    private readonly RegisterDtoValidator _registerValidator = new();
    private readonly ChangePasswordDtoValidator _changeValidator = new();

    // --- RegisterDto ---

    [Theory]
    [InlineData("password")]       // all lowercase, no digit, no special
    [InlineData("PASSWORD1")]      // no lowercase, no special
    [InlineData("Password1")]      // no special character
    [InlineData("Password!")]      // no digit
    [InlineData("pass1!")]         // too short (< 8 chars)
    [InlineData("12345678")]       // no letters at all
    public void Register_WeakPassword_FailsValidation(string password)
    {
        var dto = new RegisterDto { Email = "a@b.com", Password = password, ConfirmPassword = password };
        var result = _registerValidator.TestValidate(dto);

        result.ShouldHaveValidationErrorFor(x => x.Password);
    }

    [Theory]
    [InlineData("Password1!")]
    [InlineData("Abc@1234")]
    [InlineData("MyS3cur3#Pass")]
    [InlineData("X$9aaaBBB")]
    public void Register_StrongPassword_PassesValidation(string password)
    {
        var dto = new RegisterDto { Email = "a@b.com", Password = password, ConfirmPassword = password };
        var result = _registerValidator.TestValidate(dto);

        result.ShouldNotHaveValidationErrorFor(x => x.Password);
    }

    // --- ChangePasswordDto ---

    [Fact]
    public void ChangePassword_WeakNewPassword_FailsValidation()
    {
        var dto = new ChangePasswordDto
        {
            CurrentPassword = "anything",
            NewPassword = "password",
            ConfirmPassword = "password"
        };
        var result = _changeValidator.TestValidate(dto);

        result.ShouldHaveValidationErrorFor(x => x.NewPassword);
    }

    [Fact]
    public void ChangePassword_StrongNewPassword_PassesValidation()
    {
        var dto = new ChangePasswordDto
        {
            CurrentPassword = "anything",
            NewPassword = "NewPass1!",
            ConfirmPassword = "NewPass1!"
        };
        var result = _changeValidator.TestValidate(dto);

        result.ShouldNotHaveValidationErrorFor(x => x.NewPassword);
    }
}
