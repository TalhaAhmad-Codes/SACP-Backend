using Backend.Features.Academic.Generators;
using Backend.Features.Academic.Models.Students.Responses;
using Backend.Features.Academic.Providers.Interfaces;
using Backend.Infrastructure.Persistence;
using Mapster;
using MediatR;

namespace Backend.Features.Academic.Models.Students.Commands.CreateStudent
{
    public sealed class CreateStudentHandler
        : IRequestHandler<CreateStudentCommand, StudentResponseDto>
    {
        private readonly ApplicationDbContext _context;
        private readonly IInstitutionProvider _institutionProvider;
        private readonly IDepartmentProvider _departmentProvider;

        public CreateStudentHandler(
            ApplicationDbContext context,
            IInstitutionProvider institutionProvider,
            IDepartmentProvider departmentProvider
        )
        {
            _context = context;
            _institutionProvider = institutionProvider;
            _departmentProvider = departmentProvider;
        }

        public async Task<StudentResponseDto> Handle(
            CreateStudentCommand request,
            CancellationToken cancellationToken
        )
        {
            var regNo = request.RegistrationNumber is null
                ? await RegistrationNumber.Generate(
                    _institutionProvider,
                    _departmentProvider,
                    request.DepartmentId,
                    request.EnrollmentDate.Year,
                    0
                )
                : null;

            Student student = new()
            {
                FirstName = request.FirstName,
                LastName = request.LastName,
                RegistrationNumber = request.RegistrationNumber ?? regNo!.ToString(),
                EnrollmentDate = request.EnrollmentDate,
                AcademicStatus = request.AcademicStatus,
                Semester = request.Semester,
                UserId = request.UserId,
                DegreeId = request.DegreeId,
                DepartmentId = request.DepartmentId,
            };

            await _context.Students.AddAsync(student);
            await _context.SaveChangesAsync();

            return student.Adapt<StudentResponseDto>();
        }
    }
}
