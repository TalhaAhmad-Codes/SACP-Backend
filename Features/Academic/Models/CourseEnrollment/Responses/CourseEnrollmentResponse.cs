using Backend.Features.Academic.Models.CourseEnrollment.Enums;

namespace Backend.Features.Academic.Models.CourseEnrollment.Responses
{
    public record CourseEnrollmentResponse(
        Guid id,
        CourseEnrollmentStatus Status,
        Guid CourseId,
        Guid StudentId
    );
}
