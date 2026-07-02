using MediatR;

namespace Backend.Features.Academic.Commands.Institution.DeleteInstitution;

public sealed record DeleteInstitutionCommand(
    Guid Id
) : IRequest<bool>;
