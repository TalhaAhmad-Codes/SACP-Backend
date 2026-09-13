using Backend.Shared.Validators;

namespace Backend.Features.Users.Commands.ActiveUser
{
    public sealed class ActivateUserValidator : BaseValidator<ActivateUserCommand>
    {
        public ActivateUserValidator()
            : base() { }
    }
}
