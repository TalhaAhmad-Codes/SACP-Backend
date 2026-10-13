using Backend.Shared.Extensions;
using FluentValidation;

namespace Backend.Features.Academic.Models.Degrees.Queries.GetDegreeById
{
    public sealed class GetDegreeByIdValidator : AbstractValidator<GetDegreeByIdQuery>
    {
        public GetDegreeByIdValidator()
        {
            RuleFor(d => d.Id).RequiredId();
        }
    }
}
