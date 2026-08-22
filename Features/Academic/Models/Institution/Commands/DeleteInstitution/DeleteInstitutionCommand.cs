using MediatR;

namespace Backend.Features.Academic.Models.Institution.Commands.DeleteInstitution
{
    public sealed record DeleteInstitutionCommand(Guid Id) : IRequest<Unit>;
}
