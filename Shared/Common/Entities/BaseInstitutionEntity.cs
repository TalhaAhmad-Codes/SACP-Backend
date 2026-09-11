using Backend.Features.Academic.Models.Institutions;

namespace Backend.Shared.Common.Entities
{
    public abstract class BaseInstitutionEntity : BaseEntity
    {
        public Guid InstitutionId { get; set; }
        public Institution Institution { get; set; }
    }
}
