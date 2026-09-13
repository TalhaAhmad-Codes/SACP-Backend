namespace Backend.Features.Users.Responses
{
    public sealed class UserAvatarResponse
    {
        public byte[]? Avatar { get; init; }
        public string? ContentType { get; init; }
    }
}
