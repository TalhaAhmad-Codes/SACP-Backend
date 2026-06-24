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

        // * Foriegn Key Constraint
        public Guid DepartmentId { get; set; }
        public Department Department { get; set; }

        // * Relations
        public CourseAssignment CourseAssignment { get; set; }
        public ICollection<CourseEnrollment> CourseEnrollments { get; set; }
        public ICollection<Attendance> Attendances { get; set; }
        public ICollection<Exam> Exams { get; set; }
    }
}
