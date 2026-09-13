using Backend.Shared.Validators;

namespace Backend.Features.Users.Commands.DeactiveUser
{
    public sealed class DeactivateUserValidator : BaseValidator<DeactivateUserCommand>
    {
        public DeactivateUserValidator()
            : base() { }
    }
}
