using Backend.Features.Academic.Models.Institutions.Responses;
using Backend.Shared.Common.DTOs;
using MediatR;

namespace Backend.Features.Academic.Models.Institutions.Queries.GetInstitutionById
{
    public sealed class GetInstitutionByIdQuery : BaseDto, IRequest<InstitutionResponseDto> { }
}
