using Backend.Features.Academic.Providers.Interfaces;
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

        // This method generates a unique registration number for the student
        public static async Task<RegistrationNumber> Generate(
            IInstitutionProvider institutionProvider,
            IDepartmentProvider departmentProvider,
            Guid departmentId,
            int yearOfAdmission,
            int rollNumber
        )
        {
            // Get Department
            var department = await departmentProvider.GetByIdAsync(departmentId);

            // Get Institution
            var institution = await institutionProvider.GetByIdAsync(department.InstitutionId);

            // Generate the registration number
            var institutionLabel = institution.Name.Substring(0, 3).ToUpper();
            var departmentLabel = department.Name.Substring(0, 3).ToUpper() + department.Code;

            var registrationNumber = new RegistrationNumber(
                institutionLabel,
                departmentLabel,
                yearOfAdmission,
                rollNumber
            );

            return registrationNumber;
        }

        // Method to get the number as string
        public override string ToString()
        {
            return $"{InstitutionLabel}-{DepartmentLabel}-{YearOfAdmission}-{RollNumber}";
        }
    }
}
