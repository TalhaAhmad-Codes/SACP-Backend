using Backend.Features.Academic.Providers.Interfaces;

namespace Backend.Shared.Extensions;

public static class ProviderExtensions
{
    public static IServiceCollection AddProviders(
        this IServiceCollection services)
    {
        // * Academic Data
        services.AddScoped<IInstitutionProvider, IInstitutionProvider>();

        return services;
    }
}