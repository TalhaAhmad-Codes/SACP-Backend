using Backend.Features.Academic.Models.Sessions.Responses;
using Backend.Shared.Common.DTOs;
using MediatR;

namespace Backend.Features.Academic.Models.Sessions.Queries.GetSessionById
{
    public sealed class GetSessionByIdQuery : BaseDto, IRequest<SessionResponseDto> { }
}
