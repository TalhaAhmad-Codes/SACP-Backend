using Backend.Shared.Common.DTOs;
using MediatR;

namespace Backend.Features.Academic.Models.FacultyMembers.Commands.DeleteFacultyMember
{
    public sealed class DeleteFacultyMemberCommand : BaseDto, IRequest<Unit> { }
}
