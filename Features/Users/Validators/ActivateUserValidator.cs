using Backend.Features.Users.Commands.ActiveUser;
using Backend.Shared.Validators;

namespace Backend.Features.Users.Validators
{
    public sealed class ActivateUserValidator : BaseValidator<ActivateUserCommand>
    {
        public ActivateUserValidator()
            : base() { }
    }
}
