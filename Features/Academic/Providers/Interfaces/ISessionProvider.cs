using Backend.Features.Academic.Models.Sessions;
using Backend.Shared.Providers.Interfaces;

namespace Backend.Features.Academic.Providers.Interfaces
{
    public interface ISessionProvider : IGeneralProvider<Session>
    {
        Task<bool> ExistsByNameAsync(string name, CancellationToken cancellationToken = default);
    }
}
