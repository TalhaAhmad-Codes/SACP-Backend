using Backend.Features.Academic.Models.Student.Commands.DeleteStudent;
using Backend.Infrastructure.Persistence;
using MediatR;

namespace Backend.Features.Academic.Models.Student.Handlers.Commands;

public sealed class DeleteStudentHandler : IRequestHandler<DeleteStudentCommand, bool>
{
    private readonly ApplicationDbContext _context;

    public DeleteStudentHandler(ApplicationDbContext context)
    {
        _context = context;
    }
    
    public async Task<bool> Handle(DeleteStudentCommand request, CancellationToken cancellationToken)
    {
        var student = await _context.Students.FindAsync(request.Id);

        if (student is null)
            return false;

        _context.Students.Remove(student);
        await _context.SaveChangesAsync(cancellationToken);
        return true;
    }
}