using Backend.Features.Academic.Models.Enums;
using Backend.Shared.Common;

namespace Backend.Features.Academic.Models
{
    public sealed class CourseAssignment : BaseEntity
    {
        public CourseAssignmentStatus Status { get; set; }

        // * Foreign Key Constraints
        public Guid CourseId { get; set; }
        public Course Course { get; set; }

        public Guid FacultyId { get; set; }
        public FacultyMember FacultyMember { get; set; }
    }
}
