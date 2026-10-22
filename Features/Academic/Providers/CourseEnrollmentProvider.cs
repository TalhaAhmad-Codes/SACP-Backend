using Backend.Features.Academic.Models.CourseEnrollments;
using Backend.Features.Academic.Providers.Interfaces;
using Backend.Infrastructure.Persistence;
using Backend.Shared.Providers;
using Microsoft.EntityFrameworkCore;

namespace Backend.Features.Academic.Providers
{
    public sealed class CourseEnrollmentProvider
        : GeneralProvider<CourseEnrollment>,
            ICourseEnrollmentProvider
    {
        public CourseEnrollmentProvider(ApplicationDbContext context)
            : base(context) { }

        public async Task<bool> IsAlreadyEnrolledAsync(Guid studentId, Guid courseId)
        {
            var enrollment = await _context.CourseEnrollments.FirstOrDefaultAsync(e =>
                e.StudentId == studentId && e.CourseId == courseId
            );

            return enrollment is not null;
        }
    }
}
