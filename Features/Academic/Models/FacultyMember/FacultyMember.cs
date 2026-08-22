using Backend.Features.Academic.Models.FacultyMember.Enums;
using Backend.Features.Academic.Values;
using Backend.Features.Users.Models;
using Backend.Shared.Common;

namespace Backend.Features.Academic.Models.FacultyMember
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
        public Department.Department Department { get; set; }

        public Guid InstitutionId { get; set; }
        public Institution.Institution Institution { get; set; }

        // * Relations
        public ICollection<CourseAssignment.CourseAssignment> CourseAssignments { get; set; }
        public ICollection<Attendance.Attendance> Attendances { get; set; }
    }
}
