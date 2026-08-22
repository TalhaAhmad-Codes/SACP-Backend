using Backend.Features.Academic.Models.Institution.Commands.UpdateInstitution;
using Backend.Shared.Common;
using Backend.Shared.Common.FixedValue;
using Backend.Shared.Extensions;
using FluentValidation;

namespace Backend.Features.Academic.Models.Institution.Validators
{
    public sealed class UpdateInstitutionValidator : AbstractValidator<UpdateInstitutionCommand>
    {
        public UpdateInstitutionValidator()
        {
            // * Id
            RuleFor(i => i.Id).RequiredId("Institution");

            // * Name
            RuleFor(i => i.Name)
                .NotEmpty().WithMessage(Message.NotEmpty("Institution name"))
                .MaximumLength(MaxValue.InstitutionName).WithMessage(Message.InvalidMaxLength("Institution", MaxValue.InstitutionName));
        }
    }
}
