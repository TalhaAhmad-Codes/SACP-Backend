using Backend.Features.Academic.Models.Admin;
using Backend.Features.Academic.Providers.Interfaces;
using Backend.Infrastructure.Persistence;
using Backend.Shared.Providers;

namespace Backend.Features.Academic.Providers
{
    public sealed class AdminProvider : GeneralProvider<Admin>, IAdminProvider
    {
        public AdminProvider(ApplicationDbContext context) : base(context) { }
    }
}
