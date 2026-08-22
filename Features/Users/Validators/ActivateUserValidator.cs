using Backend.Features.Users.Commands.ActiveUser;
using FluentValidation;

namespace Backend.Features.Users.Validators
{
    public sealed class ActivateUserValidator : AbstractValidator<ActivateUserCommand>
    {
        public ActivateUserValidator()
        {
            RuleFor(u => u.Id).NotEmpty().WithMessage("User id is required");
        }
    }
}
