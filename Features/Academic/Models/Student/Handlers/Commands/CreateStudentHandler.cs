using Backend.Features.Academic.Generators;
using Backend.Features.Academic.Models.Student.Commands.CreateStudent;
using Backend.Features.Academic.Providers.Interfaces;
using Backend.Infrastructure.Persistence;
using Backend.Shared.Exceptions;
using MediatR;

namespace Backend.Features.Academic.Models.Student.Handlers.Commands
{
    public sealed class CreateStudentHandler : IRequestHandler<CreateStudentCommand, Guid>
    {
        private readonly ApplicationDbContext _context;
        private readonly IInstitutionProvider _institutionProvider;
        private readonly IDepartmentProvider _departmentProvider;
        private readonly IStudentProvider _studentProvider;

        public CreateStudentHandler(ApplicationDbContext context, IInstitutionProvider institutionProvider, IDepartmentProvider departmentProvider, IStudentProvider studentProvider)
        {
            _context = context;
            _institutionProvider = institutionProvider;
            _departmentProvider = departmentProvider;
            _studentProvider = studentProvider;
        }

        public async Task<Guid> Handle(CreateStudentCommand request, CancellationToken cancellationToken)
        {
            // * Check email uniqueness
            var existsByEmail = await _studentProvider.ExistsByEmailAsync(request.Email.Trim(), cancellationToken);

            if (existsByEmail)
                throw new InvalidRequestException("Student with given email already exists");

            // * Check roll number uniqueness
            var existsByRollNumber = await _studentProvider.ExistsByRollNumberAndYearOfAdmissionAsync(request.RollNumber, request.DateOfAdmission.Year, cancellationToken);

            if (existsByRollNumber)
                throw new InvalidRequestException($"Student with roll number '{request.RollNumber}' on year of admission '{request.DateOfAdmission.Year}' already exists");

            // * Registration number generation logic
            string regNumber;

            if (request.RegistrationNumber is null)
            {
                var num = await RegistrationNumber.Generate(
                    _institutionProvider,
                    _departmentProvider,
                    request.DepartmentId,
                    request.DateOfAdmission.Year,
                    request.RollNumber
                );
                regNumber = num.ToString();
            }
            else
            {
                regNumber = request.RegistrationNumber.Trim();
            }

            // * Student creation
            var student = new Student()
            {
                Name = new()
                {
                    FirstName = request.FirstName.Trim(),
                    LastName = request.LastName.Trim(),
                },
                FatherName = request.FatherName.Trim(),
                Gender = request.Gender,
                DateOfBirth = request.DateOfBirth,
                DateOfAdmission = request.DateOfAdmission,
                RollNumber = request.RollNumber,
                Email = request.Email.Trim(),
                RegistrationNumber = regNumber,
                DepartmentId = request.DepartmentId,
            };

            await _context.Students.AddAsync(student);
            await _context.SaveChangesAsync();

            return student.Id;
        }
    }
}
