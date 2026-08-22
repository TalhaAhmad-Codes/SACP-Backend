using Backend.Features.Academic.Models.CourseEnrollment.Enums;
using Backend.Shared.Common;

namespace Backend.Features.Academic.Models.CourseEnrollment
{
    public sealed class CourseEnrollment : BaseEntity
    {
        public CourseEnrollmentStatus Status { get; set; }

        // * Foreign Key Constraints
        public Guid CourseId { get; set; }
        public Course.Course Course { get; set; }

        public Guid StudentId { get; set; }
        public Student.Student Student { get; set; }
    }
}
