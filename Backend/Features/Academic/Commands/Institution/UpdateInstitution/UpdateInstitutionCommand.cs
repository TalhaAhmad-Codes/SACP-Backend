using Backend.Features.Academic.Responses;
using MediatR;

namespace Backend.Features.Academic.Commands.Institution.UpdateInstitution;

public sealed record UpdateInstitutionCommand(
    Guid Id,
    string Name
) : IRequest<InstitutionResponse>;
