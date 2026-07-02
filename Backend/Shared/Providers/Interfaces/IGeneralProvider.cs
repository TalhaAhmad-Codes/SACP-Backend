namespace Backend.Shared.Providers.Interfaces;

public interface IGeneralProvider<T> where T : class
{
    Task<T?> GetByIdAsync(Guid id, CancellationToken cancellationToken = default);
}
