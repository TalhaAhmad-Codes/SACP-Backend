using Backend.Features.Academic.Models.Attendance;
using Backend.Features.Academic.Providers.Interfaces;
using Backend.Infrastructure.Persistence;
using Backend.Shared.Providers;

namespace Backend.Features.Academic.Providers
{
    public sealed class AttendanceProvider : GeneralProvider<Attendance>, IAttendanceProvider
    {
        public AttendanceProvider(ApplicationDbContext context) : base(context) { }
    }
}
