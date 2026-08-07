using MediatR;

namespace Backend.Features.Auth.Commands.Register
{
    public sealed record AdminRegisterCommand(
        string FirstName,
        string LastName,
        string InstitutionName,
        string Username,
        string Email,
        string Password,
        string ConfirmPassword
    ) : IRequest<Guid>;
}
