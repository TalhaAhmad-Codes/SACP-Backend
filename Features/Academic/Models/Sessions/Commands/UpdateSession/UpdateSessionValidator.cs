using Backend.Shared.Common.Utilities;
using Backend.Shared.Extensions;
using FluentValidation;

namespace Backend.Features.Academic.Models.Sessions.Commands.UpdateSession
{
    public sealed class UpdateSessionValidator : AbstractValidator<UpdateSessionCommand>
    {
        public UpdateSessionValidator()
        {
            // Id
            RuleFor(s => s.Id).RequiredId();

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
