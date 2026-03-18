using FluentValidation;
using NexUs.Models.DTO.TeacherInterests;

namespace NexUs.Validators.TeacherInterest
{
    public class CreateTeacherInterestValidator : AbstractValidator<CreateTeacherInterestDto>
    {
        public CreateTeacherInterestValidator()
        {
            RuleFor(x => x.Description)
                .NotEmpty().WithMessage("Please describe your qualifications and interest")
                .MaximumLength(2000).WithMessage("Description cannot exceed 2000 characters");
        }
    }
}
