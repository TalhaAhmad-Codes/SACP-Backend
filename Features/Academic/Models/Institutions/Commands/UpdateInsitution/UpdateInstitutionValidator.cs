using Backend.Shared.Common.Utilities;
using Backend.Shared.Extensions;
using Backend.Shared.Validators;

namespace Backend.Features.Academic.Models.Institutions.Commands.UpdateInsitution
{
    public sealed class UpdateInstitutionValidator : BaseValidator<UpdateInstitutionCommand>
    {
        public UpdateInstitutionValidator()
            : base()
        {
            RuleFor(i => i.Name).RequiredString("Institution", maxLength: MaxValue.InstitutionName);
        }
    }
}
