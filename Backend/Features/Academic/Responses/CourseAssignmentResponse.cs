using Backend.Features.Academic.Models.Enums;

namespace Backend.Features.Academic.Responses
{
    public record CourseAssignmentResponse(
        Guid Id,
        CourseAssignmentStatus Status,
        Guid CourseId,
        Guid FacultyId
    );
}
