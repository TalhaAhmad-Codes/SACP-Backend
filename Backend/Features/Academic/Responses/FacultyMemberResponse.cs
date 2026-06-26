using Backend.Features.Academic.Models.Enums;

namespace Backend.Features.Academic.Responses
{
    public record FacultyMemberResponse(
        Guid Id,
        string Name,
        FacultyJobRole JobRole,
        DateOnly DateOfJoining,
        FacultyStatus Status,
        string Email,
        Guid UserId,
        Guid DepartmentId,
        Guid InstitutionId
    );
}
