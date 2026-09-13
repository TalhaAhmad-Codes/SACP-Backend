using Backend.Features.Academic.Models.Institutions;
using Backend.Features.Academic.Providers.Interfaces;
using Backend.Infrastructure.Persistence;
using Backend.Shared.Providers;
using Microsoft.EntityFrameworkCore;

namespace Backend.Features.Academic.Providers
{
    public sealed class InstitutionProvider : GeneralProvider<Institution>, IInstitutionProvider
    {
        public InstitutionProvider(ApplicationDbContext context)
            : base(context) { }

        public async Task<bool> ExistsByNameAsync(
            string name,
            CancellationToken cancellationToken = default
        ) =>
            await _dbSet
                .AsNoTracking()
                .AnyAsync(i => EF.Functions.ILike(i.Name, name), cancellationToken);
    }
}
