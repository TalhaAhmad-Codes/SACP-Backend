using Backend.Shared.Common.Utilities;
using Backend.Shared.Extensions;
using FluentValidation;

namespace Backend.Features.Academic.Models.Admins.Commands.CreateAdmin
{
    public sealed class CreateAdminValidator : AbstractValidator<CreateAdminCommand>
    {
        public CreateAdminValidator()
        {
            RuleFor(a => a.FirstName)
                .RequiredString("First name", MinValue.PersonName, MaxValue.PersonName);

            RuleFor(a => a.LastName)
                .RequiredString("Last name", MinValue.PersonName, MaxValue.PersonName);

            RuleFor(a => a.UserId).RequiredId("User");

            RuleFor(a => a.InstitutionId).RequiredId("Institution");
        }
    }
}
