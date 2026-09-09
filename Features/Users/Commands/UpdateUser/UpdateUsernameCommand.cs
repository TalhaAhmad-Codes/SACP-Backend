using Backend.Shared.Common.DTOs;
using MediatR;

namespace Backend.Features.Users.Commands.UpdateUser
{
    public sealed class UpdateUsernameCommand : BaseDto, IRequest<Unit>
    {
        public string Username { get; init; }
    }
}
