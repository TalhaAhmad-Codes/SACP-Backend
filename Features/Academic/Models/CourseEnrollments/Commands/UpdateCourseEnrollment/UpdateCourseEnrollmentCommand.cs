using Backend.Features.Academic.Models.CourseEnrollments.Enums;
using Backend.Shared.Common.DTOs;
using MediatR;

namespace Backend.Features.Academic.Models.CourseEnrollments.Commands.UpdateCourseEnrollment
{
    public sealed class UpdateCourseEnrollmentCommand : BaseDto, IRequest<Unit>
    {
        public CourseEnrollmentStatus Status { get; init; }
        public Guid CourseId { get; init; }
        public Guid SessionId { get; init; }
        public Guid StudentId { get; init; }
    }
}
