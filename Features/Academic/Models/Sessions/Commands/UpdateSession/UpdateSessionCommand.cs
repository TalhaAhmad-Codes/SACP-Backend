using Backend.Shared.Common.DTOs;
using MediatR;

namespace Backend.Features.Academic.Models.Sessions.Commands.UpdateSession
{
    public sealed class UpdateSessionCommand : BaseDto, IRequest<Unit>
    {
        public string Name { get; init; }
        public DateOnly StartDate { get; init; }
        public DateOnly EndDate { get; init; }
    }
}
