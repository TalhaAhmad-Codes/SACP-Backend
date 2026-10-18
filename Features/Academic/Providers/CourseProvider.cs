using Backend.Features.Academic.Models.Courses;
using Backend.Features.Academic.Providers.Interfaces;
using Backend.Infrastructure.Persistence;
using Backend.Shared.Providers;
using Microsoft.EntityFrameworkCore;

namespace Backend.Features.Academic.Providers
{
    public sealed class CourseProvider : GeneralProvider<Course>, ICourseProvider
    {
        public CourseProvider(ApplicationDbContext context)
            : base(context) { }

        public async Task<bool> ExistsByCodeAsync(
            string code,
            CancellationToken cancellationToken
        ) => await _context.Courses.AnyAsync(c => c.Code == code, cancellationToken);
    }
}
