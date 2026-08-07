using Backend.Shared.Common;

namespace Backend.Features.Academic.Models.CourseAssignment
{
    public sealed class CourseAssignment : BaseEntity
    {
        // * Foreign Key Constraints
        public Guid CourseId { get; set; }
        public Course.Course Course { get; set; }

        public Guid FacultyId { get; set; }
        public FacultyMember.FacultyMember FacultyMember { get; set; }
    }
}
