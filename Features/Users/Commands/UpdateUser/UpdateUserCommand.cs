using MediatR;

namespace Backend.Features.Users.Commands.UpdateUser
{
    public sealed record UpdateUserCommand(Guid UserId, string Username, string Password)
        : IRequest<bool>;
}
