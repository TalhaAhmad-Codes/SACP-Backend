using Backend.Features.Academic.Models.Enums;
using Backend.Shared.Common;

namespace Backend.Features.Academic.Models
{
    public sealed class Course : BaseEntity
    {
        public string Title { get; set; }
        public string Code { get; set; }
        public int CreditHours { get; set; }
        public Semester Semester { get; set; }

        // * Foriegn Key
        public Guid DepartmentId { get; set; }

        // * Relations
        public CourseAssignment CourseAssignment { get; set; }
        public ICollection<CourseEnrollment> CourseEnrollments { get; set; }
        public ICollection<Attendance> Attendances { get; set; }
        public ICollection<Exam> Exams { get; set; }
    }
}
