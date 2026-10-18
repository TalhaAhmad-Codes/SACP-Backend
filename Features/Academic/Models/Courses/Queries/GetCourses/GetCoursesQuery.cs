using Backend.Features.Academic.Models.Courses.Responses;
using Backend.Shared.Common.DTOs;
using MediatR;

namespace Backend.Features.Academic.Models.Courses.Queries.GetCourses
{
    public sealed class GetCoursesQuery
        : BasePagedQuery,
            IRequest<PagedResultDto<CourseResponseDto>>
    {
        public string? Title { get; init; }
        public string? Code { get; init; }
        public int? Semester { get; init; }
        public Guid? DegreeId { get; init; }
    }
}
