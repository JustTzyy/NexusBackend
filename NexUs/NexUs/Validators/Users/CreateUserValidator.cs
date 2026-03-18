using FluentValidation;
using NexUs.Models.DTO.Users;

namespace NexUs.Validators.Users
{
    public class CreateUserValidator : AbstractValidator<CreateUserDto>
    {
        public CreateUserValidator()
        {
            RuleFor(x => x.FirstName)
                .NotEmpty().WithMessage("First name is required")
                .MaximumLength(100).WithMessage("First name cannot exceed 100 characters");

            RuleFor(x => x.LastName)
                .NotEmpty().WithMessage("Last name is required")
                .MaximumLength(100).WithMessage("Last name cannot exceed 100 characters");

            RuleFor(x => x.MiddleName)
                .MaximumLength(100).WithMessage("Middle name cannot exceed 100 characters")
                .When(x => !string.IsNullOrEmpty(x.MiddleName));

            RuleFor(x => x.Suffix)
                .MaximumLength(20).WithMessage("Suffix cannot exceed 20 characters")
                .Must(suffix => suffix == null || new[] { "Jr.", "Sr.", "II", "III", "IV", "V" }.Contains(suffix))
                .WithMessage("Suffix must be one of: Jr., Sr., II, III, IV, V")
                .When(x => !string.IsNullOrEmpty(x.Suffix));

            RuleFor(x => x.Email)
                .NotEmpty().WithMessage("Email is required")
                .EmailAddress().WithMessage("Invalid email format")
                .MaximumLength(150).WithMessage("Email cannot exceed 150 characters");

            RuleFor(x => x.Phone)
                .Matches(@"^[\d\s\-\+\(\)]+$").WithMessage("Phone number can only contain digits, spaces, hyphens, plus signs, and parentheses")
                .MaximumLength(20).WithMessage("Phone number cannot exceed 20 characters")
                .When(x => !string.IsNullOrEmpty(x.Phone));

            RuleFor(x => x.DateOfBirth)
                .LessThan(DateTime.UtcNow).WithMessage("Date of birth cannot be in the future")
                .GreaterThan(DateTime.UtcNow.AddYears(-120)).WithMessage("Date of birth cannot be more than 120 years ago")
                .When(x => x.DateOfBirth.HasValue);

            RuleFor(x => x.Gender)
                .MaximumLength(20).WithMessage("Gender cannot exceed 20 characters")
                .When(x => !string.IsNullOrEmpty(x.Gender));

            RuleFor(x => x.Nationality)
                .MaximumLength(60).WithMessage("Nationality cannot exceed 60 characters")
                .When(x => !string.IsNullOrEmpty(x.Nationality));
        }
    }
}
