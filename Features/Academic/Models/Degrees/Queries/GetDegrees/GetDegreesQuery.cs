using Backend.Features.Academic.Models.Degrees.Responses;
using Backend.Shared.Common.DTOs;
using MediatR;

namespace Backend.Features.Academic.Models.Degrees.Queries.GetDegrees
{
    public sealed class GetDegreesQuery
        : BasePagedQuery,
            IRequest<PagedResultDto<DegreeResponseDto>>
    {
        public string? Title { get; init; }
        public string? Code { get; init; }

        public Guid? DepartmentId { get; init; }
    }
}
