using MediatR;

namespace Backend.Features.Auth.Commands.Register
{
    public sealed record StudentRegisterCommand(
        string Username,
        string Email,
        string Password,
        string ConfirmPassword,
        string RegistrationNumber
    ) : IRequest<Guid>;
}
