using Backend.Shared.Common.Entities;

namespace Backend.Features.Academic.Models.Departments
{
    public sealed class Department : BaseInstitutionEntity
    {
        public string Name { get; set; }
        public string Code { get; set; }
        public string? Description { get; set; }
    }
}
