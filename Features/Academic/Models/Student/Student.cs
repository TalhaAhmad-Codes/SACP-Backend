using Backend.Features.Academic.Models.Student.Enums;
using Backend.Features.Academic.Values;
using Backend.Features.Users.Models;
using Backend.Shared.Common;

namespace Backend.Features.Academic.Models.Student
{
    public sealed class Student : BaseEntity
    {
        public Name Name { get; set; }
        public string FatherName { get; set; }
        public Gender Gender { get; set; }
        public DateOnly DateOfBirth { get; set; }
        public DateOnly DateOfAdmission { get; set; }
        public int RollNumber { get; set; }
        public string Email { get; set; }
        public string RegistrationNumber { get; set; }

        public int Age => Math.Abs(DateOfBirth.Year - DateTime.Now.Year);
        public int YearOfAdmission => DateOfAdmission.Year;

        // * Foriegn Key Constraints
        public Guid? UserId { get; set; } = null;
        public User? User { get; set; }

        public Guid DepartmentId { get; set; }
        public Department.Department Department { get; set; }

        // * Relations
        public ICollection<CourseEnrollment.CourseEnrollment> CourseEnrollments { get; set; }
        public ICollection<Attendance.Attendance> Attendances { get; set; }
        public ICollection<ExamResult.ExamResult> ExamResults { get; set; }
    }
}
