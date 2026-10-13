using Backend.Shared.Common.Utilities;
using Backend.Shared.Extensions;
using FluentValidation;

namespace Backend.Features.Academic.Models.Sessions.Commands.CreateSession
{
    public sealed class CreateSessionValidator : AbstractValidator<CreateSessionCommand>
    {
        public CreateSessionValidator()
        {
            // Name
            RuleFor(s => s.Name)
                .RequiredString("Name", MinValue.SessionName, MaxValue.SessionName);

            // Start & End Dates
            RuleFor(s => s.StartDate).PastOrPresentDate("Start Date");

            RuleFor(s => s.EndDate)
                .GreaterThan(s => s.StartDate)
                .WithMessage(Message.MustPastDate("Start Date", "End Date"));
        }
    }
}
