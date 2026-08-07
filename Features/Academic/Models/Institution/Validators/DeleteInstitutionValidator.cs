using Backend.Features.Academic.Models.Institution.Commands.DeleteInstitution;
using Backend.Shared.Extensions;
using FluentValidation;

namespace Backend.Features.Academic.Models.Institution.Validators
{
    public sealed class DeleteInstitutionValidator : AbstractValidator<DeleteInstitutionCommand>
    {
        public DeleteInstitutionValidator()
        {
            // * Id
            RuleFor(i => i.Id).RequiredId("Institution");
        }
    }
}
