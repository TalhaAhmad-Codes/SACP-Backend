using Backend.Features.Academic.Models.Institution;
using Backend.Shared.Providers.Interfaces;

namespace Backend.Features.Academic.Providers.Interfaces;

public interface IInstitutionProvider : IGeneralProvider<Institution>
{
    Task<bool> ExistsByNameAsync(string name, CancellationToken cancellationToken = default);
}