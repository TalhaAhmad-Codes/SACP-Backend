using MediatR;

namespace Backend.Features.Auth.Commands.Register
{
    public sealed record FacultyRegisterCommand(
        string Username,
        string Email,
        string Password,
        string ConfirmPassword,
        string AccessCode
    ) : IRequest<Guid>;
}
