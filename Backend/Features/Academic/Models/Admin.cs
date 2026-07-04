using Backend.Features.Academic.Models.ValueObjects;
using Backend.Shared.Common;

namespace Backend.Features.Academic.Models
{
    public sealed class Admin : BaseEntity
    {
        public Name Name { get; set; }

        // * Foriegn Keys
        public Guid UserId { get; set; }
        public Guid InstitutionId { get; set; }
    }
}
