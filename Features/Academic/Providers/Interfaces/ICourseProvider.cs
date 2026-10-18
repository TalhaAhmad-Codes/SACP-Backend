using Backend.Features.Academic.Models.Courses;
using Backend.Shared.Providers.Interfaces;

namespace Backend.Features.Academic.Providers.Interfaces
{
    public interface ICourseProvider : IGeneralProvider<Course>
    {
        Task<bool> ExistsByCodeAsync(string code, CancellationToken cancellationToken);
    }
}
