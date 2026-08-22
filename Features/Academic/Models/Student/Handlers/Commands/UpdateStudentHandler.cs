using Backend.Features.Academic.Models.Student.Commands.UpdateStudent;
using Backend.Features.Academic.Providers.Interfaces;
using Backend.Infrastructure.Persistence;
using Backend.Shared.Exceptions;
using MediatR;

namespace Backend.Features.Academic.Models.Student.Handlers.Commands;

public sealed class UpdateStudentHandler : IRequestHandler<UpdateStudentCommand, Unit>
{
    private readonly ApplicationDbContext _context;
    private readonly IStudentProvider _studentProvider;

    public UpdateStudentHandler(ApplicationDbContext context, IStudentProvider studentProvider)
    {
        _context = context;
        _studentProvider = studentProvider;
    }

    public async Task<Unit> Handle(UpdateStudentCommand request, CancellationToken cancellationToken)
    {
        var student = await _studentProvider.GetByIdAsync(request.Id);
        
        // * Check email uniqueness
        if (student.Email != request.Email.Trim())
        {
            var existsByEmail = await _studentProvider.ExistsByEmailAsync(request.Email.Trim(), cancellationToken);
        
            if (existsByEmail)
                throw new InvalidRequestException("Student with given email already exists");
        }

        // * Check roll number uniqueness
        if (student.RollNumber != request.RollNumber || student.DateOfAdmission.Year != request.DateOfAdmission.Year)
        {
            // * Check roll number uniqueness
            var existsByRollNumber = await _studentProvider.ExistsByRollNumberAndYearOfAdmissionAsync(request.RollNumber, request.DateOfAdmission.Year, cancellationToken);

            if (existsByRollNumber)
                throw new InvalidRequestException($"Student with roll number '{request.RollNumber}' on year of admission '{request.DateOfAdmission.Year}' already exists");
        }

        // * Updating the student
        student.Name.FirstName = request.FirstName.Trim();
        student.Name.LastName = request.LastName.Trim();
        student.FatherName = request.FatherName.Trim();
        student.Gender = request.Gender;
        student.DateOfBirth = request.DateOfBirth;
        student.DateOfAdmission = request.DateOfAdmission;
        student.RollNumber = request.RollNumber;
        student.Email = request.Email;
        student.DepartmentId = request.DepartmentId;

        _context.Students.Update(student);
        await _context.SaveChangesAsync(cancellationToken);

        return Unit.Value;
    }
}
