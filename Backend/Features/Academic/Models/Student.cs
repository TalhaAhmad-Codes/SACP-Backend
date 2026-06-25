using Backend.Features.Academic.Models.Enums;
using Backend.Features.Academic.Models.ValueObjects;
using Backend.Features.Users.Models;
using Backend.Shared.Common;

namespace Backend.Features.Academic.Models
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

        // * Foriegn Key Constraints
        public Guid UserId { get; set; }
        public User User { get; set; }

        public Guid DepartmentId { get; set; }
        public Department Department { get; set; }

        // * Relations
        public ICollection<Course> Courses { get; set; }
        public ICollection<Attendance> Attendances { get; set; }
        public ICollection<ExamResult> ExamResults { get; set; }
    }
}
