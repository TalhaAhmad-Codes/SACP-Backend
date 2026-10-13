using Backend.Features.Academic.Providers.Interfaces;
using Backend.Infrastructure.Persistence;
using MediatR;

namespace Backend.Features.Academic.Models.Students.Commands.UpdateStudent
{
    public sealed class UpdateStudentHandler : IRequestHandler<UpdateStudentCommand, Unit>
    {
        private readonly ApplicationDbContext _context;
        private readonly IStudentProvider _provider;

        public UpdateStudentHandler(ApplicationDbContext context, IStudentProvider provider)
        {
            _context = context;
            _provider = provider;
        }

        public async Task<Unit> Handle(
            UpdateStudentCommand request,
            CancellationToken cancellationToken
        )
        {
            var student = await _provider.GetByIdAsync(request.Id, cancellationToken);

            student.FirstName = request.FirstName;
            student.LastName = request.LastName;
            student.RegistrationNumber = request.RegistrationNumber ?? student.RegistrationNumber;
            student.EnrollmentDate = request.EnrollmentDate;
            student.AcademicStatus = request.AcademicStatus;
            student.Semester = request.Semester;
            student.UserId = request.UserId;
            student.DegreeId = request.DegreeId;
            student.DepartmentId = request.DepartmentId;
            student.MarkUpdated();

            _context.Students.Update(student);
            await _context.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}
