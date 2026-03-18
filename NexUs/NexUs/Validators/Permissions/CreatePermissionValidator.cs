using FluentValidation;
using NexUs.Models.DTO.Permissions;

namespace NexUs.Validators.Permissions
{
    public class CreatePermissionValidator : AbstractValidator<CreatePermissionDto>
    {
        public CreatePermissionValidator()
        {
            RuleFor(x => x.Name)
                .NotEmpty().WithMessage("Permission name is required")
                .MaximumLength(100).WithMessage("Permission name cannot exceed 100 characters");

            RuleFor(x => x.Module)
                .NotEmpty().WithMessage("Module is required")
                .MaximumLength(100).WithMessage("Module cannot exceed 100 characters");

            RuleFor(x => x.Description)
                .MaximumLength(500).WithMessage("Description cannot exceed 500 characters")
                .When(x => !string.IsNullOrEmpty(x.Description));
        }
    }
}
