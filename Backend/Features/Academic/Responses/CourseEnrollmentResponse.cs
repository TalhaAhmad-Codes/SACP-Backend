using Backend.Features.Academic.Models.Enums;

namespace Backend.Features.Academic.Responses
{
    public record CourseEnrollmentResponse(
        Guid id,
        CourseEnrollmentStatus Status,
        Guid CourseId,
        Guid StudentId
    );
}
