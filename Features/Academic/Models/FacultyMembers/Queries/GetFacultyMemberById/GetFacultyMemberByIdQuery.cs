using Backend.Features.Academic.Models.FacultyMembers.Responses;
using Backend.Shared.Common.DTOs;
using MediatR;

namespace Backend.Features.Academic.Models.FacultyMembers.Queries.GetFacultyMemberById
{
    public sealed class GetFacultyMemberByIdQuery : BaseDto, IRequest<FacultyMemberResponseDto> { }
}
