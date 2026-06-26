using Backend.Infrastructure.Persistence;
using Backend.Shared.Exceptions;

namespace Backend.Features.Academic.Generators
{
    public sealed class RegistrationNumber
    {
        public string InstitutionLabel { get; }
        public string DepartmentLabel { get; }
        public int YearOfAdmission { get; }
        public int RollNumber { get; }

        private RegistrationNumber(
            string institutionLabel,
            string departmentLabel,
            int yearOfAdmission,
            int rollNumber
        )
        {
            InstitutionLabel = institutionLabel;
            DepartmentLabel = departmentLabel;
            YearOfAdmission = yearOfAdmission;
            RollNumber = rollNumber;
        }

        // ? This method generates a unique registration number for the student
        public static async Task<RegistrationNumber> Generate(
            ApplicationDbContext context,
            Guid departmentId,
            int yearOfAdmission,
            int rollNumber
        )
        {
            // * Get Department
            var department = await context.Departments.FindAsync(departmentId);

            if (department is null)
                throw new DomainException("Department doesn't exist");

            // * Get Institution
            var institution = await context.Institutions.FindAsync(department.InstitutionId);

            if (institution is null)
                throw new DomainException("Institution doesn't exist");

            // * Generate the registration number
            var institutionLabel = institution.Name.Substring(0, 3);
            var departmentLabel = department.Name.Substring(0, 3) + department.Label.ToString();

            var registrationNumber = new RegistrationNumber(
                institutionLabel,
                departmentLabel,
                yearOfAdmission,
                rollNumber
            );

            return registrationNumber;
        }

        // * Method to get the number as string
        public override string ToString()
        {
            return $"{InstitutionLabel}-{DepartmentLabel}-{YearOfAdmission}-{RollNumber}";
        }
    }
}
