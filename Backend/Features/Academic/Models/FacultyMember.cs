using Backend.Features.Academic.Models.Enums;
using Backend.Features.Academic.Models.ValueObjects;
using Backend.Shared.Common;

namespace Backend.Features.Academic.Models
{
    public sealed class FacultyMember : BaseEntity
    {
        public Name Name { get; set; }
        public FacultyJobRole JobRole { get; set; }
        public DateOnly DateOfJoining { get; set; }
        public FacultyStatus Status { get; set; }
        public string AccessCode { get; set; }

        // * Foriegn Keys
        public Guid UserId { get; set; }
        public Guid DepartmentId { get; set; }
        public Guid InstitutionId { get; set; }
    }
}
