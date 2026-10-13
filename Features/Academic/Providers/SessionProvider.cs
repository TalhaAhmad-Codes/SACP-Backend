using Backend.Features.Academic.Models.Sessions;
using Backend.Features.Academic.Providers.Interfaces;
using Backend.Infrastructure.Persistence;
using Backend.Shared.Providers;
using Microsoft.EntityFrameworkCore;

namespace Backend.Features.Academic.Providers
{
    public sealed class SessionProvider : GeneralProvider<Session>, ISessionProvider
    {
        public SessionProvider(ApplicationDbContext context)
            : base(context) { }

        public async Task<bool> ExistsByNameAsync(
            string name,
            CancellationToken cancellationToken = default
        ) =>
            await _context
                .Sessions.AsNoTracking()
                .AnyAsync(s => EF.Functions.ILike(s.Name, name), cancellationToken);
    }
}
