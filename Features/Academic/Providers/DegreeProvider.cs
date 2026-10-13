using Backend.Features.Academic.Models.Degrees;
using Backend.Features.Academic.Providers.Interfaces;
using Backend.Infrastructure.Persistence;
using Backend.Shared.Providers;

namespace Backend.Features.Academic.Providers
{
    public sealed class DegreeProvider : GeneralProvider<Degree>, IDegreeProvider
    {
        public DegreeProvider(ApplicationDbContext context)
            : base(context) { }
    }
}
