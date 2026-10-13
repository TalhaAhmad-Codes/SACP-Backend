using Backend.Features.Academic.Models.Degrees.Responses;
using MediatR;

namespace Backend.Features.Academic.Models.Degrees.Commands.CreateDegree
{
    public sealed class CreateDegreeCommand : IRequest<DegreeResponseDto>
    {
        public string Title { get; init; }
        public string Code { get; init; }

        public Guid DepartmentId { get; init; }
    }
}
