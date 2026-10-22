using Backend.Features.Academic.Models.CourseEnrollments.Enums;
using Backend.Features.Academic.Models.Courses;
using Backend.Features.Academic.Models.Sessions;
using Backend.Features.Academic.Models.Students;
using Backend.Shared.Common.Entities;

namespace Backend.Features.Academic.Models.CourseEnrollments
{
    public sealed class CourseEnrollment : BaseEntity
    {
        public CourseEnrollmentStatus Status { get; set; }

        public Guid CourseId { get; set; }
        public Course Course { get; set; }

        public Guid SessionId { get; set; }
        public Session Session { get; set; }

        public Guid StudentId { get; set; }
        public Student Student { get; set; }
    }
}
