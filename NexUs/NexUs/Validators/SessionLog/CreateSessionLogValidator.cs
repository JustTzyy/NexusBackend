using FluentValidation;
using NexUs.Models.DTO.SessionLogs;

namespace NexUs.Validators.SessionLog
{
    public class CreateSessionLogValidator : AbstractValidator<CreateSessionLogDto>
    {
        private static readonly string[] ValidOutcomes = ["Completed", "Late", "Absent"];
        private static readonly string[] ValidAbsentParties = ["Teacher", "Student", "Both"];

        public CreateSessionLogValidator()
        {
            RuleFor(x => x.TutoringRequestId)
                .GreaterThan(0).WithMessage("TutoringRequestId is required");

            RuleFor(x => x.SessionDate)
                .NotEmpty().WithMessage("SessionDate is required");

            RuleFor(x => x.Outcome)
                .NotEmpty().WithMessage("Outcome is required")
                .Must(o => ValidOutcomes.Contains(o))
                .WithMessage("Outcome must be Completed, Late, or Absent");

            RuleFor(x => x.AbsentParty)
                .Must((dto, ap) => dto.Outcome == "Completed" || !string.IsNullOrEmpty(ap))
                .WithMessage("AbsentParty is required when the session was not completed")
                .Must(ap => ap == null || ValidAbsentParties.Contains(ap))
                .WithMessage("AbsentParty must be Teacher, Student, or Both");
        }
    }
}
