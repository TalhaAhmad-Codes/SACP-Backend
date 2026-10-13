using Backend.Shared.Common.DTOs;
using MediatR;

namespace Backend.Features.Academic.Models.Degrees.Commands.DeleteDegree
{
    public sealed class DeleteDegreeCommand : BaseDto, IRequest<Unit> { }
}
