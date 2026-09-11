using Backend.Features.Academic.Models.Departments;
using Backend.Features.Academic.Providers.Interfaces;
using Backend.Infrastructure.Persistence;
using Backend.Shared.Providers;
using Microsoft.EntityFrameworkCore;

namespace Backend.Features.Academic.Providers
{
    public sealed class DepartmentProvider : GeneralProvider<Department>, IDepartmentProvider
    {
        public DepartmentProvider(ApplicationDbContext context)
            : base(context) { }

        public async Task<bool> ExistsByNameAsync(
            string name,
            CancellationToken cancellationToken = default
        ) =>
            await _dbSet
                .AsNoTracking()
                .AnyAsync(d => EF.Functions.ILike(d.Name, name), cancellationToken);
    }
}
