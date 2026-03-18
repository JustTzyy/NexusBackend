using FluentValidation;
using NexUs.Models.DTO.TutoringRequests;

namespace NexUs.Validators.TutoringRequest
{
    public class CreateTutoringRequestValidator : AbstractValidator<CreateTutoringRequestDto>
    {
        public CreateTutoringRequestValidator()
        {
            RuleFor(x => x.BuildingId)
                .GreaterThan(0).WithMessage("Building is required");

            RuleFor(x => x.DepartmentId)
                .GreaterThan(0).WithMessage("Department is required");

            RuleFor(x => x.SubjectId)
                .GreaterThan(0).WithMessage("Subject is required");

            RuleFor(x => x.Message)
                .NotEmpty().WithMessage("Please describe what you need help with")
                .MaximumLength(2000).WithMessage("Message cannot exceed 2000 characters");

            RuleFor(x => x.Priority)
                .NotEmpty().WithMessage("Priority is required")
                .Must(p => p == "Low" || p == "Normal" || p == "High")
                .WithMessage("Priority must be Low, Normal, or High");
        }
    }
}
