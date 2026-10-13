using Backend.Shared.Common.DTOs;
using MediatR;

namespace Backend.Features.Academic.Models.Sessions.Commands.DeleteSession
{
    public sealed class DeleteSessionCommand : BaseDto, IRequest<Unit> { }
}
