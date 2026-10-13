using Backend.Features.Academic.Models.FacultyMembers.Enums;
using Backend.Features.Academic.Models.FacultyMembers.Responses;
using Backend.Shared.Common.DTOs;
using MediatR;

namespace Backend.Features.Academic.Models.FacultyMembers.Queries.GetFacultyMembers
{
    public sealed class GetFacultyMembersQuery
        : BasePagedQuery,
            IRequest<PagedResultDto<FacultyMemberResponseDto>>
    {
        public string? Name { get; init; }
        public FacultyRole? Role { get; init; }
        public DateOnly? FromDateOfJoining { get; init; }
        public DateOnly? ToDateOfJoining { get; init; }
        public bool? HasUserAccount { get; init; }
        public Guid? DepartmentId { get; init; }
    }
}
