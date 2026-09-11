using Backend.Features.Academic.Models.Departments;
using Backend.Shared.Common.Entities;

namespace Backend.Features.Academic.Models.Institutions
{
    public sealed class Institution : BaseEntity
    {
        public string Name { get; set; }

        // Realtions
        public ICollection<Department> Departments { get; set; }
    }
}
