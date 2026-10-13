using Backend.Features.Academic.Models.Degrees.Responses;
using Backend.Shared.Common.DTOs;
using MediatR;

namespace Backend.Features.Academic.Models.Degrees.Queries.GetDegreeById
{
    public sealed class GetDegreeByIdQuery : BaseDto, IRequest<DegreeResponseDto> { }
}
