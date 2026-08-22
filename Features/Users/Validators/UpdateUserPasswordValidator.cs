using Backend.Features.Users.Commands.UpdateUser;
using Backend.Shared.Common.FixedValue;
using FluentValidation;

namespace Backend.Features.Users.Validators
{
    public sealed class UpdateUserPasswordValidator : AbstractValidator<UpdateUserPasswordCommand>
    {
        public UpdateUserPasswordValidator()
        {
            RuleFor(p => p.Id).NotEmpty().WithMessage("User id is required");

            RuleFor(p => p.NewPassword)
                .NotEmpty()
                .WithMessage("Password is required")
                .MinimumLength(MinValue.Password)
                .WithMessage($"Password must contain at least '{MinValue.Password}' characters")
                .MaximumLength(MaxValue.Password)
                .WithMessage($"Password must not exceed '{MaxValue.Password}' characters");

            RuleFor(p => p.ConfirmPassword)
                .NotEmpty()
                .WithMessage("Password is required")
                .MinimumLength(MinValue.Password)
                .WithMessage($"Password must contain at least '{MinValue.Password}' characters")
                .MaximumLength(MaxValue.Password)
                .WithMessage($"Password must not exceed '{MaxValue.Password}' characters")
                .Matches(p => p.NewPassword)
                .WithMessage("Your new password must match");
        }
    }
}
