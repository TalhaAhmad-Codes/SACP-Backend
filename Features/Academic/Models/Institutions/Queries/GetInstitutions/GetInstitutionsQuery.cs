using Backend.Features.Academic.Models.Institutions.Responses;
using Backend.Shared.Common.DTOs;
using MediatR;

namespace Backend.Features.Academic.Models.Institutions.Queries.GetInstitutions
{
    public sealed class GetInstitutionsQuery
        : BasePagedQuery,
            IRequest<PagedResultDto<InstitutionResponseDto>>
    {
        public string? Name { get; init; }
    }
}
