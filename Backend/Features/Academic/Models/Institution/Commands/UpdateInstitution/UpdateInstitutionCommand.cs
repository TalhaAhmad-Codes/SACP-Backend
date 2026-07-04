using MediatR;

namespace Backend.Features.Academic.Models.Institution.Commands.UpdateInstitution
{
    public sealed record UpdateInstitutionCommand(Guid Id, string Name) : IRequest<Unit>;
}
