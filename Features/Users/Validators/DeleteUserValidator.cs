using Backend.Features.Users.Commands.DeleteUser;
using Backend.Shared.Validators;

namespace Backend.Features.Users.Validators
{
    public sealed class DeleteUserValidator : BaseValidator<DeleteUserCommand>
    {
        public DeleteUserValidator()
            : base() { }
    }
}
