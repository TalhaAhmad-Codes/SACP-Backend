using Backend.Features.Academic.Models.ValueObjects;
using Backend.Features.Users.Models;
using Backend.Shared.Common;

namespace Backend.Features.Academic.Models
{
    public sealed class Admin : BaseEntity
    {
        public Name Name { get; set; }

        // * Foriegn Key Constraints
        public Guid UserId { get; set; }
        public User User { get; set; }

        public Guid InstitutionId { get; set; }
        public Institution Institution { get; set; }
    }
}
