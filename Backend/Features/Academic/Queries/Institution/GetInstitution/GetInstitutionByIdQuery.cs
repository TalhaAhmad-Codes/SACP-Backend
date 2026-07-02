using Backend.Features.Academic.Responses;
using MediatR;

namespace Backend.Features.Academic.Queries.Institution.GetInstitution;

public sealed record GetInstitutionByIdQuery(
    Guid Id
) : IRequest<InstitutionResponse?>;
