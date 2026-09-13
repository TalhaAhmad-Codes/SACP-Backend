using Backend.Shared.Common.DTOs;

namespace Backend.Features.Academic.Models.Institutions.Responses
{
    public sealed class InstitutionResponse : BaseResponseDto
    {
        public string Name { get; init; }
    }
}
