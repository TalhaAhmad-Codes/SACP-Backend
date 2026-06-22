using MediatR;

namespace Backend.Features.Users.Commands.UpdateUser
{
    public record UpdateUserUsernameCommand(Guid Id, string Username)
        : IRequest<bool>;
}
