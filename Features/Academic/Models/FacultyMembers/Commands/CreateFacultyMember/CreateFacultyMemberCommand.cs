using Backend.Features.Academic.Models.FacultyMembers.Enums;
using Backend.Features.Academic.Models.FacultyMembers.Responses;
using MediatR;

namespace Backend.Features.Academic.Models.FacultyMembers.Commands.CreateFacultyMember
{
    public sealed class CreateFacultyMemberCommand : IRequest<FacultyMemberResponseDto>
    {
        public string FirstName { get; init; }
        public string LastName { get; init; }
        public FacultyRole Role { get; init; }
        public DateOnly DateOfJoining { get; init; }

        public Guid? UserId { get; init; }
        public Guid DepartmentId { get; init; }
    }
}
