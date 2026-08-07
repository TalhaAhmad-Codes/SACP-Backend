using Backend.Features.Academic.Models.Student.Commands.DeleteStudent;
using Backend.Features.Academic.Providers.Interfaces;
using Backend.Infrastructure.Persistence;
using MediatR;

namespace Backend.Features.Academic.Models.Student.Handlers.Commands;

public sealed class DeleteStudentHandler : IRequestHandler<DeleteStudentCommand, Unit>
{
    private readonly ApplicationDbContext _context;
    private readonly IStudentProvider _studentProvider;

    public DeleteStudentHandler(ApplicationDbContext context, IStudentProvider studentProvider)
    {
        _context = context;
        _studentProvider = studentProvider;
    }
    
    public async Task<Unit> Handle(DeleteStudentCommand request, CancellationToken cancellationToken)
    {
        var student = await _studentProvider.GetByIdAsync(request.Id);

        _context.Students.Remove(student);
        await _context.SaveChangesAsync(cancellationToken);
        return Unit.Value;
    }
}
