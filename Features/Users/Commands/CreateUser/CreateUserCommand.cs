using Backend.Features.Users.Models.Enums;
using Backend.Features.Users.Responses;
using MediatR;

namespace Backend.Features.Users.Commands.CreateUser
{
    public sealed record CreateUserCommand(
        string Username,
        string Email,
        string Password,
        UserRole Role
    ) : IRequest<UserResponse>;
}
