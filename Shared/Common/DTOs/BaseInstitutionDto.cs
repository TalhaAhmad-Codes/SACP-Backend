namespace Backend.Shared.Common.DTOs
{
    public abstract class BaseInstitutionDto : BaseResponseDto
    {
        public Guid InstitutionId { get; init; }
    }
}
