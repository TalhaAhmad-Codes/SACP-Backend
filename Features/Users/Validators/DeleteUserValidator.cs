using Backend.Features.Users.Commands.DeleteUser;
using FluentValidation;

namespace Backend.Features.Users.Validators
{
    public sealed class DeleteUserValidator : AbstractValidator<DeleteUserCommand>
    {
        public DeleteUserValidator()
        {
            RuleFor(u => u.UserId).NotEmpty().WithMessage("User id is required");
        }
    }
}
