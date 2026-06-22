namespace Backend.Features.Users.Models.ValueObjects
{
    public sealed class Avatar
    {
        public byte[]? Data { get; set; } = null;
        public string? ContentType { get; set; } = null;
    }
}
