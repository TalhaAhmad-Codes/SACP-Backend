using Backend.Shared.Common.DTOs;
using MediatR;

namespace Backend.Features.Academic.Models.Institutions.Commands.DeleteInstitution
{
    public sealed class DeleteInstitutionCommand : BaseDto, IRequest<Unit> { }
}
