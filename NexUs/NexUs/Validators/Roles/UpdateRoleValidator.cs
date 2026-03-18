using FluentValidation;
using NexUs.Models.DTO.Roles;

namespace NexUs.Validators.Roles
{
    public class UpdateRoleValidator : AbstractValidator<UpdateRoleDto>
    {
        public UpdateRoleValidator()
        {
            RuleFor(x => x.Name)
                .NotEmpty().WithMessage("Role name cannot be empty")
                .MaximumLength(100).WithMessage("Role name cannot exceed 100 characters")
                .When(x => x.Name != null);

            RuleFor(x => x.Description)
                .NotEmpty().WithMessage("Description cannot be empty")
                .MaximumLength(500).WithMessage("Description cannot exceed 500 characters")
                .When(x => x.Description != null);
        }
    }
}
