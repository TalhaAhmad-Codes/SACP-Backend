using Backend.Features.Academic.Models.Enums;
using Backend.Features.Academic.Models.ValueObjects;
using Backend.Features.Users.Models;
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
        public string Email { get; set; }

        // * Foriegn Key Constraints
        public Guid? UserId { get; set; } = null;
        public User? User { get; set; }

        public Guid DepartmentId { get; set; }
        public Department Department { get; set; }

        public Guid InstitutionId { get; set; }
        public Institution Institution { get; set; }

        // * Relations
        public ICollection<CourseAssignment> CourseAssignments { get; set; }
        public ICollection<Attendance> Attendances { get; set; }
    }
}
