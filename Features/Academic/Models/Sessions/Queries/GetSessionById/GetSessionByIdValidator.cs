using Backend.Shared.Extensions;
using FluentValidation;

namespace Backend.Features.Academic.Models.Sessions.Queries.GetSessionById
{
    public sealed class GetSessionByIdValidator : AbstractValidator<GetSessionByIdQuery>
    {
        public GetSessionByIdValidator()
        {
            RuleFor(s => s.Id).RequiredId();
        }
    }
}
