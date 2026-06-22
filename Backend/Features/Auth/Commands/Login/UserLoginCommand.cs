using MediatR;

namespace Backend.Features.Auth.Commands.Login
{
    public sealed record UserLoginCommand(string Email, string Password) : IRequest<Guid>;
}
