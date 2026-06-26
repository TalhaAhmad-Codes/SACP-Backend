using Backend.Features.Academic.Models.Enums;

namespace Backend.Features.Academic.Responses
{
    public record AttendanceResponse(
        Guid Id,
        AttendanceType Type,
        AttendanceStatus Status,
        DateOnly DateOfMarking,
        Guid CourseId,
        Guid FacultyId,
        Guid StudentId
    );
}
