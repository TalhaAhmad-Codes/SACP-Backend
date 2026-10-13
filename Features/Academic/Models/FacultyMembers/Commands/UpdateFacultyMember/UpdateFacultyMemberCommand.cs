using Backend.Features.Academic.Models.FacultyMembers.Enums;
using Backend.Shared.Common.DTOs;
using MediatR;

namespace Backend.Features.Academic.Models.FacultyMembers.Commands.UpdateFacultyMember
{
    public sealed class UpdateFacultyMemberCommand : BaseDto, IRequest<Unit>
    {
        public string FirstName { get; init; }
        public string LastName { get; init; }
        public FacultyRole Role { get; init; }
        public DateOnly DateOfJoining { get; init; }

        public Guid? UserId { get; init; }
        public Guid DepartmentId { get; init; }
    }
}
