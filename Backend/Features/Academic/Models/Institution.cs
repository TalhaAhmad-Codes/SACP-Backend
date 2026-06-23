using Backend.Shared.Common;

namespace Backend.Features.Academic.Models
{
    public sealed class Institution : BaseEntity
    {
        public string Name { get; set; }

        // * Relations
        public Admin Admin { get; set; }
        public ICollection<Department> Departments { get; set; }
        public ICollection<FacultyMember> FacultyMembers { get; set; }
    }
}
