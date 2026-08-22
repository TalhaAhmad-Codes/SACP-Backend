using Backend.Features.Academic.Models.Institution.Responses;
using MediatR;

namespace Backend.Features.Academic.Models.Institution.Queries.GetInstitution
{
    public sealed record GetInstitutionByIdQuery(Guid Id) : IRequest<InstitutionResponse>;
}
