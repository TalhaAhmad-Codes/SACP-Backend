using Backend.Features.Academic.Models.Degrees;
using Backend.Features.Academic.Models.FacultyMembers;
using Backend.Features.Academic.Models.Students;
using Backend.Shared.Common.Entities;

namespace Backend.Features.Academic.Models.Departments
{
    public sealed class Department : BaseInstitutionEntity
    {
        public string Name { get; set; }
        public string Code { get; set; }
        public string? Description { get; set; }

        public ICollection<FacultyMember> FacultyMembers { get; set; }
        public ICollection<Student> Students { get; set; }
        public ICollection<Degree> Degrees { get; set; }
    }
}
