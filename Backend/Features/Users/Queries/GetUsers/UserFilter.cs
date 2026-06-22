using Backend.Features.Users.Models.Enums;

namespace Backend.Features.Users.Queries.GetUsers
{
    public sealed record UserFilter(
        string? SearchUsername = null,
        UserRole? Role = null,
        bool? IsActive = null
    );
}
