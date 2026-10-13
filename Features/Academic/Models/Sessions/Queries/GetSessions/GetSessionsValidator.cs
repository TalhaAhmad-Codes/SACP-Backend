using Backend.Shared.Common.Utilities;
using Backend.Shared.Extensions;
using Backend.Shared.Validators;
using FluentValidation;

namespace Backend.Features.Academic.Models.Sessions.Queries.GetSessions
{
    public sealed class GetSessionsValidator : BasePagedValidator<GetSessionsQuery>
    {
        public GetSessionsValidator()
            : base()
        {
            // Name
            RuleFor(s => s.Name).StringMinMax("Name", MinValue.SessionName, MaxValue.SessionName);

            // Date
            RuleFor(s => s.FromDate!.Value)
                .PastOrPresentDate("From Date")
                .When(s => s.FromDate.HasValue);

            RuleFor(s => s.ToDate)
                .GreaterThan(s => s.FromDate)
                .WithMessage(Message.MustPastDate("From Date", "To Date"))
                .When(s => s.ToDate.HasValue && s.FromDate.HasValue);
        }
    }
}
