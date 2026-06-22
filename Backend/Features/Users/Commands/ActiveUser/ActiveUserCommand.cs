using MediatR;

namespace Backend.Features.Users.Commands.ActiveUser
{
    public sealed record ActivateUserCommand(Guid UserId) : IRequest<bool>;
}
