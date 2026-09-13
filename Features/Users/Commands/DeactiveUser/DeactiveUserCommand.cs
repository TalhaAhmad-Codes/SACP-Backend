using Backend.Shared.Common.DTOs;
using MediatR;

namespace Backend.Features.Users.Commands.DeactiveUser
{
    public sealed class DeactivateUserCommand : BaseDto, IRequest<Unit> { }
}
