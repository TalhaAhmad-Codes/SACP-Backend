using Backend.Features.Users.Models.Enums;
using MediatR;

namespace Backend.Features.Users.Commands.CreateUser
{
    public sealed record CreateUserCommand(
        string Username,
        string Email,
        string Password,
        UserRole Role
    ) : IRequest<Guid>;
}
