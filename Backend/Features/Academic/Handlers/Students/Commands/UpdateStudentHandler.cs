using Backend.Features.Academic.Commands.Student.UpdateStudent;
using Backend.Infrastructure.Persistence;
using Backend.Shared.Exceptions;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Backend.Features.Academic.Handlers.Students.Commands;

public sealed class UpdateStudentHandler : IRequestHandler<UpdateStudentCommand, bool>
{
    private readonly ApplicationDbContext _context;

    public UpdateStudentHandler(ApplicationDbContext context)
    {
        _context = context;
    }
    
    private async Task<bool> ExistsByEmailAsync(string email, CancellationToken  cancellationToken)
    => await _context.Students.AnyAsync(s => s.Email == email, cancellationToken);

    public async Task<bool> Handle(UpdateStudentCommand request, CancellationToken cancellationToken)
    {
        var student = await _context.Students.FindAsync(request.Id);

        if (student is null)
            return false;
        
        // * Check email uniqueness
        if (student.Email != request.Email.Trim())
        {
            var existsByEmail = await ExistsByEmailAsync(request.Email.Trim(), cancellationToken);
        
            if (existsByEmail)
                throw new NotExistsException("Student with given email already exists");            
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
        return true;
    }
}
