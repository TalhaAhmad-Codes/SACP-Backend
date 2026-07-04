using Backend.Shared.Common;

namespace Backend.Features.Academic.Models
{
    public sealed class Department : BaseEntity
    {
        public string Name { get; set; }
        public int Label { get; set; } = 0;

        // * Foriegn Key
        public Guid InstitutionId { get; set; }

        // * Relations
        public ICollection<FacultyMember> FacultyMembers { get; set; }
        public ICollection<Student> Students { get; set; }
        public ICollection<Course> Courses { get; set; }
    }
}
