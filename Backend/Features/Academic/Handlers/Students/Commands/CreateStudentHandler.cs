using Backend.Features.Academic.Commands.Student.CreateStudent;
using Backend.Features.Academic.Generators;
using Backend.Features.Academic.Models;
using Backend.Infrastructure.Persistence;
using MediatR;

namespace Backend.Features.Academic.Handlers.Students.Commands
{
    public sealed class CreateStudentHandler : IRequestHandler<CreateStudentCommand, Guid>
    {
        private readonly ApplicationDbContext _context;

        public CreateStudentHandler(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Guid> Handle(
            CreateStudentCommand request,
            CancellationToken cancellationToken
        )
        {
            string regNumber;

            if (request.RegistrationNumber is null)
            {
                var num = await RegistrationNumber.Generate(
                    _context,
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
                UserId = request.UserId,
                DepartmentId = request.DepartmentId,
            };

            await _context.Students.AddAsync(student);
            await _context.SaveChangesAsync();

            return student.Id;
        }
    }
}
