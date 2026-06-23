using Backend.Features.Academic.Models.ValueObjects;
using Backend.Features.Users.Models;
using Backend.Shared.Common;

namespace Backend.Features.Academic.Models
{
    public sealed class Admin : BaseEntity
    {
        public Name Name { get; set; }

        // * Foriegn Keys
        public Guid UserId { get; set; }
        public Guid InstitutionId { get; set; }

        // * Relations
        public User User { get; set; }
        public Institution Institution { get; set; }
    }
}
