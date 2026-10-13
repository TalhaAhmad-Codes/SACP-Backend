namespace Backend.Features.Users.Responses
{
    public sealed class UserAvatarResponseDto
    {
        public byte[]? Avatar { get; init; }
        public string? ContentType { get; init; }
    }
}
