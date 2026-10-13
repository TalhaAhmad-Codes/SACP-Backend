using Backend.Shared.Common.DTOs;

namespace Backend.Features.Academic.Models.Sessions.Responses
{
    public sealed class SessionResponseDto : BaseResponseDto
    {
        public string Name { get; init; }
        public DateOnly StartDate { get; init; }
        public DateOnly EndDate { get; init; }
        public bool IsExpired { get; init; }
    }
}
