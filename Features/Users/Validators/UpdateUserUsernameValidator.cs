using Backend.Features.Users.Commands.UpdateUser;
using Backend.Shared.Common.FixedValue;
using FluentValidation;

namespace Backend.Features.Users.Validators
{
    public sealed class UpdateUserUsernameValidator : AbstractValidator<UpdateUserUsernameCommand>
    {
        public UpdateUserUsernameValidator()
        {
            RuleFor(u => u.Id).NotEmpty().WithMessage("User id is required");

            RuleFor(u => u.Username)
                .NotEmpty()
                .WithMessage("Username is required")
                .MaximumLength(MaxValue.Username)
                .WithMessage($"Username must not exceed '{MaxValue.Username}' characters")
                .MinimumLength(MinValue.Username)
                .WithMessage($"Username must contain at least '{MinValue.Username}' characters");
        }
    }
}
