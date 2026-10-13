using Backend.Features.Academic.Models.Institutions.Responses;
using MediatR;

namespace Backend.Features.Academic.Models.Institutions.Commands.CreateInstitution
{
    public sealed class CreateInstitutionCommand : IRequest<InstitutionResponseDto>
    {
        public string Name { get; init; }
    }
}
