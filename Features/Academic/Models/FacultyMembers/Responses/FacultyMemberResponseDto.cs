using Backend.Features.Academic.Models.FacultyMembers.Enums;
using Backend.Shared.Common.DTOs;

namespace Backend.Features.Academic.Models.FacultyMembers.Responses
{
    public sealed class FacultyMemberResponseDto : BaseResponseDto
    {
        public string FirstName { get; init; }
        public string LastName { get; init; }
        public FacultyRole Role { get; init; }
        public string AccessCode { get; init; }
        public DateOnly DateOfJoining { get; init; }

        public Guid? UserId { get; init; }
        public Guid DepartmentId { get; init; }
    }
}
