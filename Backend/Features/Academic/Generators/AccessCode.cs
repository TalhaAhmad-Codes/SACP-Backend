using Backend.Infrastructure.Persistence;
using Backend.Shared.Exceptions;
using Microsoft.EntityFrameworkCore;

namespace Backend.Features.Academic.Generators
{
    public sealed class AccessCode
    {
        public string DepartmentLabel { get; }
        public int FacultyCount { get; }
        public int Year { get; }

        private AccessCode(string departmentLabel, int facultyCount, int year)
        {
            DepartmentLabel = departmentLabel;
            FacultyCount = facultyCount;
            Year = year;
        }

        public static AccessCode Generate(
            ApplicationDbContext context,
            DateOnly dateOfJoin,
            Guid departmentId
        )
        {
            // * Get the department
            var department = context.Departments.Find(departmentId);

            // * Check the depratment
            if (department is null)
                throw new DomainException("Department doesn't exist");

            // * Generate the access code
            var label = department.Name.Substring(0, 3) + department.Label;
            var count =
                context
                    .FacultyMembers.AsQueryable()
                    .AsNoTracking()
                    .Where(fm => fm.DateOfJoining == dateOfJoin)
                    .Count() + 1;
            var year = dateOfJoin.Year;
            return new AccessCode(label, count, year);
        }

        public override string ToString()
        {
            return $"{DepartmentLabel}-{FacultyCount}-{Year}";
        }
    }
}
