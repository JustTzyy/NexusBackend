using FluentValidation;
using NexUs.Models.DTO.TutoringRequests;

namespace NexUs.Validators.TutoringRequest
{
    public class UpdateTutoringRequestValidator : AbstractValidator<UpdateTutoringRequestDto>
    {
        public UpdateTutoringRequestValidator()
        {
            RuleFor(x => x.Message)
                .MaximumLength(2000).WithMessage("Message cannot exceed 2000 characters")
                .When(x => !string.IsNullOrEmpty(x.Message));

            RuleFor(x => x.Priority)
                .Must(p => p == "Low" || p == "Normal" || p == "High")
                .WithMessage("Priority must be Low, Normal, or High")
                .When(x => !string.IsNullOrEmpty(x.Priority));
        }
    }
}
