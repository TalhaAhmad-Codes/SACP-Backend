using Backend.Features.Academic.Models.Student;
using Backend.Features.Academic.Providers.Interfaces;
using Backend.Infrastructure.Persistence;
using Backend.Shared.Providers;
using Microsoft.EntityFrameworkCore;

namespace Backend.Features.Academic.Providers
{
    public sealed class StudentProvider : GeneralProvider<Student>, IStudentProvider
    {
        public StudentProvider(ApplicationDbContext context) : base(context) { }

        public async Task<bool> ExistsByEmailAsync(string email, CancellationToken cancellationToken = default)
            => await _dbSet.AnyAsync(s => s.Email == email, cancellationToken);

        public async Task<bool> ExistsByRollNumberAndYearOfAdmissionAsync(int rollNumber, int yearOfAdmission, CancellationToken cancellationToken = default)
            => await _dbSet.AnyAsync(s => s.RollNumber == rollNumber && s.YearOfAdmission == yearOfAdmission, cancellationToken);
    }
}
