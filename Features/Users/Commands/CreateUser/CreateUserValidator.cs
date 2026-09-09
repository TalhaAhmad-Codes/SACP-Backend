using Backend.Shared.Common;
using Backend.Shared.Common.FixedValue;
using Backend.Shared.Extensions;
using FluentValidation;

namespace Backend.Features.Users.Commands.CreateUser
{
    public sealed class CreateUserValidator : AbstractValidator<CreateUserCommand>
    {
        public CreateUserValidator()
        {
            RuleFor(u => u.Username)
                .RequiredString("Username", MinValue.Username, MaxValue.Username);

            RuleFor(u => u.Email)
                .RequiredString("Email", maxLength: MaxValue.Email)
                .EmailAddress()
                .WithMessage(Message.InvalidPattern("Email"));

            RuleFor(u => u.Password)
                .RequiredString("Password", MinValue.Password, MaxValue.Password);

            RuleFor(u => u.Role).IsInEnum().WithMessage(Message.InvalidEnum("Role"));
        }
    }
}
