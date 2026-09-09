namespace Backend.Shared.Common.DTOs
{
    public abstract class BaseResponseDto : BaseDto
    {
        public DateTime CreatedAt { get; init; }
        public DateTime? UpdatedAt { get; init; }
    }
}
