using Backend.Features.Academic.Models.Courses.Responses;
using Backend.Shared.Common.DTOs;
using MediatR;

namespace Backend.Features.Academic.Models.Courses.Queries.GetCourseById
{
    public sealed class GetCourseByIdQuery : BaseDto, IRequest<CourseResponseDto> { }
}
