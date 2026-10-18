using Backend.Shared.Common.DTOs;

namespace Backend.Features.Academic.Models.Courses.Responses
{
    public sealed class CourseResponseDto : BaseResponseDto
    {
        public string Title { get; init; }
        public string? Code { get; init; }
        public int Semester { get; init; }
        public int? CreditHours { get; init; }

        public Guid DegreeId { get; init; }
    }
}
