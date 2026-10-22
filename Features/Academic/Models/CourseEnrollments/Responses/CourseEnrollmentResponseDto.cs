using Backend.Features.Academic.Models.CourseEnrollments.Enums;
using Backend.Shared.Common.DTOs;

namespace Backend.Features.Academic.Models.CourseEnrollments.Responses
{
    public sealed class CourseEnrollmentResponseDto : BaseResponseDto
    {
        public CourseEnrollmentStatus Status { get; init; }
        public Guid CourseId { get; init; }
        public Guid SessionId { get; init; }
        public Guid StudentId { get; init; }
    }
}
