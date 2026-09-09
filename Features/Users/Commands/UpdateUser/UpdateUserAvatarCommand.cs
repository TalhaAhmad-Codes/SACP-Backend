using Backend.Shared.Common.DTOs;
using MediatR;

namespace Backend.Features.Users.Commands.UpdateUser
{
    public sealed record UpdateUserAvatarCommand : BaseDto, IRequest<bool>
    {
        public IFormFile Avatar { get; init; }
    }
}
