using Backend.Shared.Common;

namespace Backend.Features.Academic.Models.Department
{
    public sealed class Department : BaseEntity
    {
        public string Name { get; set; }
        public int Label { get; set; } = 0;

        // * Foriegn Key Constraint
        public Guid InstitutionId { get; set; }
        public Institution.Institution Institution { get; set; }

        // * Relations
        public ICollection<FacultyMember.FacultyMember> FacultyMembers { get; set; }
        public ICollection<Student.Student> Students { get; set; }
        public ICollection<Course.Course> Courses { get; set; }
    }
}
