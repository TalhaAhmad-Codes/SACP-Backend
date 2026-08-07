using Backend.Features.Academic.Models.FacultyMember.Enums;

namespace Backend.Features.Academic.Models.FacultyMember.Responses
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
