using Backend.Shared.Common.DTOs;
using MediatR;

namespace Backend.Features.Users.Commands.ActiveUser
{
    public sealed class ActivateUserCommand : BaseDto, IRequest<Unit> { }
}
