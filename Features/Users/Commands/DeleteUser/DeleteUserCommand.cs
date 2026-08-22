using MediatR;

namespace Backend.Features.Users.Commands.DeleteUser
{
    public sealed record DeleteUserCommand(Guid UserId) : IRequest<Unit>;
}
