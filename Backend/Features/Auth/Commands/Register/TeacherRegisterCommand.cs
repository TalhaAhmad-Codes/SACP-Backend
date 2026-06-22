using MediatR;

namespace Backend.Features.Auth.Commands.Register
{
    public sealed record TeacherRegisterCommand(
        string FirstName,
        string LastName,
        string AccessCode,
        string Username,
        string Email,
        string Password,
        string ConfirmPassword
    ) : IRequest<Guid>;
}
