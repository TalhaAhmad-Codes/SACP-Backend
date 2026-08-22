using Backend.Features.Academic.Models.Attendance.Enums;

namespace Backend.Features.Academic.Models.Attendance.Responses
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
