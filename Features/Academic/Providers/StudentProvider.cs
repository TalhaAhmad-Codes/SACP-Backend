using Backend.Features.Academic.Models.Students;
using Backend.Features.Academic.Providers.Interfaces;
using Backend.Infrastructure.Persistence;
using Backend.Shared.Providers;

namespace Backend.Features.Academic.Providers
{
    public sealed class StudentProvider : GeneralProvider<Student>, IStudentProvider
    {
        public StudentProvider(ApplicationDbContext context)
            : base(context) { }
    }
}
