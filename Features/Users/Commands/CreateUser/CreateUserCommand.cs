using Backend.Features.Users.Models.Enums;
using Backend.Features.Users.Responses;
using MediatR;

namespace Backend.Features.Users.Commands.CreateUser
{
    public sealed class CreateUserCommand : IRequest<UserResponseDto>
    {
        public string Username { get; init; }
        public string Email { get; init; }
        public string Password { get; init; }
        public UserRole Role { get; init; }
    }
}
