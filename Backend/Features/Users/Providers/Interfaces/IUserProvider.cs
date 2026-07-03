using Backend.Features.Users.Models;
using Backend.Shared.Providers.Interfaces;

namespace Backend.Features.Users.Providers.Interfaces
{
    public interface IUserProvider : IGeneralProvider<User>
    {
        Task<bool> ExistsByEmailAsync(string email, CancellationToken cancellationToken = default);
    }
}
