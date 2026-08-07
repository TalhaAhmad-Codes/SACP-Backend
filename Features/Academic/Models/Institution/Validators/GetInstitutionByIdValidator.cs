using Backend.Features.Academic.Models.Institution.Queries.GetInstitution;
using Backend.Shared.Extensions;
using FluentValidation;

namespace Backend.Features.Academic.Models.Institution.Validators
{
    public sealed class GetInstitutionByIdValidator : AbstractValidator<GetInstitutionByIdQuery>
    {
        public GetInstitutionByIdValidator()
        {
            // * Id
            RuleFor(i => i.Id).RequiredId("Institution");
        }
    }
}
