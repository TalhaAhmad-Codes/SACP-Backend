using Backend.Shared.Common.DTOs;

namespace Backend.Features.Academic.Models.Institutions.Responses
{
    public sealed class InstitutionResponseDto : BaseResponseDto
    {
        public string Name { get; init; }
    }
}
