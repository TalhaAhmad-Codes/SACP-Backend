namespace Backend.Features.Users.Responses
{
    public sealed record UserAvatarResponse(byte[]? Avatar, string? ContentType);
}
