using Backend.Shared.Validators;

namespace Backend.Features.Users.Commands.DeleteUser
{
    public sealed class DeleteUserValidator : BaseValidator<DeleteUserCommand>
    {
        public DeleteUserValidator()
            : base() { }
    }
}
