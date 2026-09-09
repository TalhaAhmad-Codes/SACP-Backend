using Backend.Shared.Common.DTOs;
using MediatR;

namespace Backend.Features.Users.Commands.DeleteUser
{
    public sealed class DeleteUserCommand : BaseDto, IRequest<Unit> { }
}
