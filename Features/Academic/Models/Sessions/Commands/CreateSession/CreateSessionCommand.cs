using Backend.Features.Academic.Models.Sessions.Responses;
using MediatR;

namespace Backend.Features.Academic.Models.Sessions.Commands.CreateSession
{
    public sealed class CreateSessionCommand : IRequest<SessionResponseDto>
    {
        public string Name { get; init; }
        public DateOnly StartDate { get; init; }
        public DateOnly EndDate { get; init; }
    }
}
