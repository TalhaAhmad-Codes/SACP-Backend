using Backend.Features.Academic.Models.Departments;
using Backend.Features.Academic.Models.FacultyMembers.Enums;
using Backend.Features.Users.Models;
using Backend.Shared.Common.Entities;

namespace Backend.Features.Academic.Models.FacultyMembers
{
    public sealed class FacultyMember : BaseEntity
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string FullName => $"{FirstName} {LastName}";
        public FacultyRole Role { get; set; }
        public string AccessCode { get; set; }
        public DateOnly DateOfJoining { get; set; }

        public Guid? UserId { get; set; }
        public User? User { get; set; }
        public bool HasUserAccount => UserId is not null;

        public Guid DepartmentId { get; set; }
        public Department Department { get; set; }
    }
}
