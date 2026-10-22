using Backend.Features.Academic.Models.CourseEnrollments.Enums;
using Backend.Features.Academic.Models.CourseEnrollments.Responses;
using MediatR;

namespace Backend.Features.Academic.Models.CourseEnrollments.Commands.CreateCourseEnrollment
{
    public sealed class CreateCourseEnrollmentCommand : IRequest<CourseEnrollmentResponseDto>
    {
        public CourseEnrollmentStatus Status { get; init; }
        public Guid CourseId { get; init; }
        public Guid SessionId { get; init; }
        public Guid StudentId { get; init; }
    }
}
