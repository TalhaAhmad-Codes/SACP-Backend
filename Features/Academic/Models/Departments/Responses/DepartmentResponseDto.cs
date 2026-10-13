using Backend.Shared.Common.DTOs;

namespace Backend.Features.Academic.Models.Departments.Responses
{
    public sealed class DepartmentResponseDto : BaseInstitutionDto
    {
        public string Name { get; init; }
        public string Code { get; init; }
        public string? Description { get; init; }
    }
}
