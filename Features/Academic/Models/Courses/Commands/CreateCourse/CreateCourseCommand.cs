using Backend.Features.Academic.Models.Courses.Responses;
using MediatR;

namespace Backend.Features.Academic.Models.Courses.Commands.CreateCourse
{
    public sealed class CreateCourseCommand : IRequest<CourseResponseDto>
    {
        public string Title { get; init; }
        public string? Code { get; init; }
        public int Semester { get; init; }
        public int? CreditHours { get; init; }

        public Guid DegreeId { get; init; }
    }
}
