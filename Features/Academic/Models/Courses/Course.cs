using Backend.Features.Academic.Models.CourseEnrollments;
using Backend.Features.Academic.Models.Degrees;
using Backend.Shared.Common.Entities;

namespace Backend.Features.Academic.Models.Courses
{
    public sealed class Course : BaseEntity
    {
        public string Title { get; set; }
        public string? Code { get; set; }
        public int Semester { get; set; }
        public int? CreditHours { get; set; }

        public Guid DegreeId { get; set; }
        public Degree Degree { get; set; }

        public ICollection<CourseEnrollment> CourseEnrollments { get; set; }
    }
}
