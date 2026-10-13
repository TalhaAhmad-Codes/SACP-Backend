using Backend.Shared.Common.DTOs;

namespace Backend.Features.Academic.Models.Degrees.Responses
{
    public sealed class DegreeResponseDto : BaseResponseDto
    {
        public string Title { get; init; }
        public string Code { get; init; }

        public Guid DepartmentId { get; init; }
    }
}
