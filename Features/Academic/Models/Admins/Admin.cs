using Backend.Features.Users.Models;
using Backend.Shared.Common.Entities;

namespace Backend.Features.Academic.Models.Admins
{
    public sealed class Admin : BaseInstitutionEntity
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string FullName => $"{FirstName} {LastName}";
        public Guid UserId { get; set; }
        public User User { get; set; }
    }
}
