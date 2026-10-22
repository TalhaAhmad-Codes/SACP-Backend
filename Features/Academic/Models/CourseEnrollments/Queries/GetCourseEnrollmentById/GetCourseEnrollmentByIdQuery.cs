using Backend.Features.Academic.Models.CourseEnrollments.Responses;
using Backend.Shared.Common.DTOs;
using MediatR;

namespace Backend.Features.Academic.Models.CourseEnrollments.Queries.GetCourseEnrollmentById
{
    public sealed class GetCourseEnrollmentByIdQuery
        : BaseDto,
            IRequest<CourseEnrollmentResponseDto> { }
}
