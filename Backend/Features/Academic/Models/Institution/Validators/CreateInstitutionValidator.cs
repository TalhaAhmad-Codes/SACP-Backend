using Backend.Features.Academic.Models.Institution.Commands.CreateInsitution;
using Backend.Shared.Common;
using Backend.Shared.Common.FixedValue;
using FluentValidation;

namespace Backend.Features.Academic.Models.Institution.Validators
{
    public sealed class CreateInstitutionValidator : AbstractValidator<CreateInstitutionCommand>
    {
        public CreateInstitutionValidator()
        {
            // * Name
            RuleFor(i => i.Name)
                .NotEmpty().WithMessage(Message.NotEmpty("Institution name"))
                .MaximumLength(MaxValue.InstitutionName).WithMessage(Message.InvalidMaxLength("Institution", MaxValue.InstitutionName));
        }
    }
}
