using Backend.Features.Academic.Models.Students.Responses;
using Backend.Shared.Common.DTOs;
using MediatR;

namespace Backend.Features.Academic.Models.Students.Queries.GetStudentById
{
    public sealed class GetStudentByIdQuery : BaseDto, IRequest<StudentResponseDto> { }
}
