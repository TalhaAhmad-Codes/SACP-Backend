using Backend.Features.Academic.Models.CourseEnrollments;
using Backend.Features.Academic.Models.Degrees;
using Backend.Features.Academic.Models.Departments;
using Backend.Features.Academic.Models.Students.Enums;
using Backend.Features.Users.Models;
using Backend.Shared.Common.Entities;

namespace Backend.Features.Academic.Models.Students
{
    public sealed class Student : BaseEntity
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string FullName => $"{FirstName} {LastName}";
        public string RegistrationNumber { get; set; }
        public DateOnly EnrollmentDate { get; set; }
        public AcademicStatus AcademicStatus { get; set; }
        public int Semester { get; set; }
        public bool IsActive => AcademicStatus == AcademicStatus.Studying;

        public Guid? UserId { get; set; }
        public User? User { get; set; }

        public Guid DepartmentId { get; set; }
        public Department Department { get; set; }

        public Guid DegreeId { get; set; }
        public Degree Degree { get; set; }

        public ICollection<CourseEnrollment> CourseEnrollments { get; set; }
    }
}
