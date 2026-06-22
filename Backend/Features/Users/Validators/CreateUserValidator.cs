using Backend.Features.Users.Commands.CreateUser;
using Backend.Shared.Common.FixedValue;
using FluentValidation;

namespace Backend.Features.Users.Validators
{
    public sealed class CreateUserValidator : AbstractValidator<CreateUserCommand>
    {
        public CreateUserValidator()
        {
            RuleFor(u => u.Username)
                .NotEmpty()
                .WithMessage("Username is required")
                .MaximumLength(MaxValue.Username)
                .WithMessage($"Username must not exceed '{MaxValue.Username}' characters")
                .MinimumLength(MinValue.Username)
                .WithMessage($"Username must contain at least '{MinValue.Username}' characters");

            RuleFor(u => u.Email)
                .NotEmpty()
                .WithMessage("Email is required")
                .MaximumLength(MaxValue.Email)
                .WithMessage($"Email must not exceed '{MaxValue.Email}' characters")
                .EmailAddress();

            RuleFor(u => u.Password)
                .NotEmpty()
                .WithMessage("Password is required")
                .MinimumLength(MinValue.Password)
                .WithMessage($"Password must contain at least '{MinValue.Password}' characters")
                .MaximumLength(MaxValue.Password)
                .WithMessage($"Password must not exceed '{MaxValue.Password}' characters");

            RuleFor(u => u.Role).NotEmpty().WithMessage("User's role is required").IsInEnum();
        }
    }
}
