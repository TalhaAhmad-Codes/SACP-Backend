using Backend.Infrastructure.Persistence;
using Backend.Shared.Providers.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Backend.Shared.Providers;

public abstract class GeneralProvider<T> : IGeneralProvider<T> where T : class
{
    protected readonly ApplicationDbContext _context;
    protected readonly DbSet<T> _dbSet;

    public GeneralProvider(ApplicationDbContext context)
    {
        _context = context;
        _dbSet = _context.Set<T>();
    }

    public async Task<T?> GetByIdAsync(Guid id, CancellationToken cancellationToken = default) =>
        await _dbSet.FindAsync(id, cancellationToken);
}
