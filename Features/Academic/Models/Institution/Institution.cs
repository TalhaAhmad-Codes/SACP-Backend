using Backend.Shared.Common;

namespace Backend.Features.Academic.Models.Institution
{
    public sealed class Institution : BaseEntity
    {
        public string Name { get; set; }

        // * Relations
        public Admin.Admin Admin { get; set; }
        public ICollection<Department.Department> Departments { get; set; }
        public ICollection<FacultyMember.FacultyMember> FacultyMembers { get; set; }
    }
}
