using Backend.Features.Users.Models.Enums;

namespace Backend.Features.Users.Responses
{
    public sealed record UserResponse(
        Guid Id,
        string Username,
        string Email,
        UserRole Role,
        bool IsActive
    );
}
