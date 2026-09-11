using Backend.Shared.Common.DTOs;
using MediatR;

namespace Backend.Features.Academic.Models.Institutions.Commands.UpdateInsitution
{
    public sealed class UpdateInstitutionCommand : BaseDto, IRequest<Unit>
    {
        public string Name { get; init; }
    }
}
