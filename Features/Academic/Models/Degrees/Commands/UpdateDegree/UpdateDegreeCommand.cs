using Backend.Shared.Common.DTOs;
using MediatR;

namespace Backend.Features.Academic.Models.Degrees.Commands.UpdateDegree
{
    public sealed class UpdateDegreeCommand : BaseDto, IRequest<Unit>
    {
        public string Title { get; init; }
        public string Code { get; init; }

        public Guid DepartmentId { get; init; }
    }
}
