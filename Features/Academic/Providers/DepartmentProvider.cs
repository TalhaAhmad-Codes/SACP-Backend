using Backend.Features.Academic.Models.Department;
using Backend.Features.Academic.Providers.Interfaces;
using Backend.Infrastructure.Persistence;
using Backend.Shared.Providers;

namespace Backend.Features.Academic.Providers
{
    public sealed class DepartmentProvider : GeneralProvider<Department>, IDepartmentProvider
    {
        public DepartmentProvider(ApplicationDbContext context) : base(context) { }
    }
}
