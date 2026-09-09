using Backend.Shared.Common.DTOs;
using MediatR;

namespace Backend.Features.Users.Commands.UpdateUser.Avatar
{
    public sealed class UpdateUserAvatarCommand : BaseDto, IRequest<bool>
    {
        public IFormFile Avatar { get; init; }
    }
}
