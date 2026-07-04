using Backend.Features.Users.Models;
using Backend.Features.Users.Providers.Interfaces;
using Backend.Infrastructure.Persistence;
using Backend.Shared.Providers;
using Microsoft.EntityFrameworkCore;

namespace Backend.Features.Users.Providers
{
    public sealed class UserProvider : GeneralProvider<User>, IUserProvider
    {
        public UserProvider(ApplicationDbContext context) : base(context) { }

        public async Task<bool> ExistsByEmailAsync(string email, CancellationToken cancellationToken = default) => await _context.Users.AnyAsync(u => u.Email == email, cancellationToken);
    }
}
