using Backend.Shared.Common.Utilities;
using Backend.Shared.Extensions;
using FluentValidation;

namespace Backend.Features.Academic.Models.Institutions.Commands.CreateInstitution
{
    public sealed class CreateInstitutionValidator : AbstractValidator<CreateInstitutionCommand>
    {
        public CreateInstitutionValidator()
        {
            RuleFor(i => i.Name).RequiredString("Institution", maxLength: MaxValue.InstitutionName);
        }
    }
}
