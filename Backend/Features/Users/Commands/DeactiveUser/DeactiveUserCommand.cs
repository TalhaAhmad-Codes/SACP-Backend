using MediatR;

namespace Backend.Features.Users.Commands.DeactiveUser
{
    public sealed record DeactivateUserCommand(Guid UserId) : IRequest<Unit>;
}
