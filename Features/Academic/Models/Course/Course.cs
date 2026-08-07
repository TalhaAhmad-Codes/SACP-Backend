using Backend.Features.Academic.Models.Course.Enums;
using Backend.Shared.Common;

namespace Backend.Features.Academic.Models.Course
{
    public sealed class Course : BaseEntity
    {
        public string Title { get; set; }
        public string Code { get; set; }
        public int CreditHours { get; set; }
        public Semester Semester { get; set; }

        // * Foriegn Key Constraint
        public Guid DepartmentId { get; set; }
        public Department.Department Department { get; set; }

        // * Relations
        public CourseAssignment.CourseAssignment CourseAssignment { get; set; }
        public ICollection<CourseEnrollment.CourseEnrollment> CourseEnrollments { get; set; }
        public ICollection<Attendance.Attendance> Attendances { get; set; }
        public ICollection<Exam.Exam> Exams { get; set; }
        public Lecture.Lecture Lecture { get; set; }
    }
}
