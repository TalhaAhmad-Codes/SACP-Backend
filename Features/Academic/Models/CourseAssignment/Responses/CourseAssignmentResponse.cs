namespace Backend.Features.Academic.Models.CourseAssignment.Responses
{
    public record CourseAssignmentResponse(
        Guid Id,
        Guid CourseId,
        Guid FacultyId
    );
}
