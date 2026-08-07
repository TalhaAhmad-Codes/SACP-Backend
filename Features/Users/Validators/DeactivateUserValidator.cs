using Backend.Features.Users.Commands.DeactiveUser;
using FluentValidation;

namespace Backend.Features.Users.Validators
{
    public sealed class DeactivateUserValidator : AbstractValidator<DeactivateUserCommand>
    {
        public DeactivateUserValidator()
        {
            RuleFor(u => u.UserId).NotEmpty().WithMessage("User id is required");
        }
    }
}
