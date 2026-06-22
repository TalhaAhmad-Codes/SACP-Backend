using MediatR;

namespace Backend.Features.Auth.Commands.Register
{
    public sealed record StudentRegisterCommand(
        string FirstName,
        string LastName,
        string RegistrationNumber,
        string Username,
        string Email,
        string Password,
        string ConfirmPassword
    ) : IRequest<Guid>;
}
