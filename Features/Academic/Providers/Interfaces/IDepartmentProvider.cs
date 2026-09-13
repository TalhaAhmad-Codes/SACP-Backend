using Backend.Features.Academic.Models.Departments;
using Backend.Shared.Providers.Interfaces;

namespace Backend.Features.Academic.Providers.Interfaces
{
    public interface IDepartmentProvider : IGeneralProvider<Department>
    {
        Task<bool> ExistsByNameAsync(string name, CancellationToken cancellationToken = default);
    }
}
