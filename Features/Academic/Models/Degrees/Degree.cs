using Backend.Features.Academic.Models.Courses;
using Backend.Features.Academic.Models.Departments;
using Backend.Features.Academic.Models.Students;
using Backend.Shared.Common.Entities;

namespace Backend.Features.Academic.Models.Degrees
{
    public sealed class Degree : BaseEntity
    {
        public string Title { get; set; }
        public string Code { get; set; }

        public Guid DepartmentId { get; set; }
        public Department Department { get; set; }

        public ICollection<Student> Students { get; set; }
        public ICollection<Course> Courses { get; set; }
    }
}
