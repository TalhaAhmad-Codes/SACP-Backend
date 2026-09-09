using Backend.Features.Users.Commands.DeactiveUser;
using Backend.Shared.Validators;

namespace Backend.Features.Users.Validators
{
    public sealed class DeactivateUserValidator : BaseValidator<DeactivateUserCommand>
    {
        public DeactivateUserValidator()
            : base() { }
    }
}
