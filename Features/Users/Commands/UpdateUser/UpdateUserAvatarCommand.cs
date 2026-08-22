using MediatR;

namespace Backend.Features.Users.Commands.UpdateUser
{
    public sealed record UpdateUserAvatarCommand(Guid UserId, IFormFile Avatar) : IRequest<bool>;
}
