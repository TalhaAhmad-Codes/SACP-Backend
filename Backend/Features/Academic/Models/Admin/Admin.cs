using Backend.Features.Academic.Values;
using Backend.Features.Users.Models;
using Backend.Shared.Common;

namespace Backend.Features.Academic.Models.Admin
{
    public sealed class Admin : BaseEntity
    {
        public Name Name { get; set; }

        // * Foriegn Key Constraints
        public Guid UserId { get; set; }
        public User User { get; set; }

        public Guid InstitutionId { get; set; }
        public Institution.Institution Institution { get; set; }
    }
}
