using Backend.Shared.Common.DTOs;
using MediatR;

namespace Backend.Features.Academic.Models.Courses.Commands.UpdateCourse
{
    public sealed class UpdateCourseCommand : BaseDto, IRequest<Unit>
    {
        public string Title { get; init; }
        public string? Code { get; init; }
        public int Semester { get; init; }
        public int? CreditHours { get; init; }

        public Guid DegreeId { get; init; }
    }
}
