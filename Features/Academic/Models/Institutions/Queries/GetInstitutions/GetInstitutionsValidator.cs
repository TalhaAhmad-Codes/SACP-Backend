using Backend.Shared.Common.Utilities;
using Backend.Shared.Extensions;
using Backend.Shared.Validators;
using FluentValidation;

namespace Backend.Features.Academic.Models.Institutions.Queries.GetInstitutions
{
    public sealed class GetInstitutionsValidator : BasePagedValidator<GetInstitutionsQuery>
    {
        public GetInstitutionsValidator()
            : base()
        {
            RuleFor(i => i.Name)
                .StringMinMax("Institution", maxLength: MaxValue.InstitutionName)
                .Unless(i => string.IsNullOrEmpty(i.Name));
        }
    }
}
