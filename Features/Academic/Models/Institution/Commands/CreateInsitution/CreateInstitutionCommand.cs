using Backend.Features.Academic.Models.Institution.Responses;
using MediatR;

namespace Backend.Features.Academic.Models.Institution.Commands.CreateInsitution
{
    public sealed record CreateInstitutionCommand(string Name) : IRequest<InstitutionResponse>;
}
