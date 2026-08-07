using Backend.Features.Academic.Models.FacultyMember;
using Backend.Features.Academic.Providers.Interfaces;
using Backend.Infrastructure.Persistence;
using Backend.Shared.Providers;

namespace Backend.Features.Academic.Providers
{
    public sealed class FacultyMemberProvider : GeneralProvider<FacultyMember>, IFacultyMemberProvider
    {
        public FacultyMemberProvider(ApplicationDbContext context) : base(context) { }
    }
}
