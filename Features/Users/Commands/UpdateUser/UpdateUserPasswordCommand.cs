using MediatR;

namespace Backend.Features.Users.Commands.UpdateUser
{
    public record UpdateUserPasswordCommand(Guid Id, string NewPassword, string ConfirmPassword)
        : IRequest<bool>;
}
