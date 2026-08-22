using Backend.Features.Academic.Models.Student;
using Backend.Shared.Providers.Interfaces;

namespace Backend.Features.Academic.Providers.Interfaces
{
    public interface IStudentProvider : IGeneralProvider<Student>
    {
        Task<bool> ExistsByEmailAsync(string email, CancellationToken cancellationToken = default);

        Task<bool> ExistsByRollNumberAndYearOfAdmissionAsync(int rollNumber, int yearOfAdmission, CancellationToken cancellationToken = default);
    }
}
