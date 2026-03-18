using FluentValidation;
using NexUs.Models.DTO.Permissions;

namespace NexUs.Validators.Permissions
{
    public class UpdatePermissionValidator : AbstractValidator<UpdatePermissionDto>
    {
        public UpdatePermissionValidator()
        {
            RuleFor(x => x.Name)
                .NotEmpty().WithMessage("Permission name cannot be empty")
                .MaximumLength(100).WithMessage("Permission name cannot exceed 100 characters")
                .When(x => x.Name != null);

            RuleFor(x => x.Module)
                .NotEmpty().WithMessage("Module cannot be empty")
                .MaximumLength(100).WithMessage("Module cannot exceed 100 characters")
                .When(x => x.Module != null);

            RuleFor(x => x.Description)
                .NotEmpty().WithMessage("Description cannot be empty")
                .MaximumLength(500).WithMessage("Description cannot exceed 500 characters")
                .When(x => x.Description != null);
        }
    }
}
