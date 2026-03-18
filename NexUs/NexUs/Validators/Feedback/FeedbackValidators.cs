using FluentValidation;
using NexUs.Models.DTO.Feedbacks;

namespace NexUs.Validators.Feedback
{
    public class CreateFeedbackValidator : AbstractValidator<CreateFeedbackDto>
    {
        public CreateFeedbackValidator()
        {
            RuleFor(x => x.TutoringRequestId)
                .GreaterThan(0).WithMessage("TutoringRequestId is required.");

            RuleFor(x => x.SessionLogId)
                .GreaterThan(0).WithMessage("SessionLogId is required.");

            RuleFor(x => x.Rating)
                .InclusiveBetween(1, 5).WithMessage("Rating must be between 1 and 5.");

            RuleFor(x => x.Comment)
                .MaximumLength(2000).WithMessage("Comment cannot exceed 2000 characters.");
        }
    }

    public class UpdateFeedbackValidator : AbstractValidator<UpdateFeedbackDto>
    {
        public UpdateFeedbackValidator()
        {
            RuleFor(x => x.Rating)
                .InclusiveBetween(1, 5)
                .When(x => x.Rating.HasValue)
                .WithMessage("Rating must be between 1 and 5.");

            RuleFor(x => x.Comment)
                .MaximumLength(2000).WithMessage("Comment cannot exceed 2000 characters.");
        }
    }
}
