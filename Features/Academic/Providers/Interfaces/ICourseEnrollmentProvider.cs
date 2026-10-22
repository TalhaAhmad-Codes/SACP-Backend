using Backend.Features.Academic.Models.CourseEnrollments;
using Backend.Shared.Providers.Interfaces;

namespace Backend.Features.Academic.Providers.Interfaces
{
    public interface ICourseEnrollmentProvider : IGeneralProvider<CourseEnrollment>
    {
        Task<bool> IsAlreadyEnrolledAsync(Guid studentId, Guid courseId);
    }
}
