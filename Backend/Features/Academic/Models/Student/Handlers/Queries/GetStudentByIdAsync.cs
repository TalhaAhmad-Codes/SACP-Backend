using Backend.Features.Academic.Models.Student.Queries.GetStudent;
using Backend.Features.Academic.Models.Student.Responses;
using Backend.Infrastructure.Persistence;
using Mapster;
using MediatR;

namespace Backend.Features.Academic.Models.Student.Handlers.Queries;

public sealed class GetStudentByIdAsync : IRequestHandler<GetStudentByIdQuery, StudentResponse?>
{
    private readonly ApplicationDbContext _context;

    public GetStudentByIdAsync(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<StudentResponse?> Handle(GetStudentByIdQuery request, CancellationToken cancellationToken)
    {
        var student = await _context.Students.FindAsync(request.Id, cancellationToken);
        return student?.Adapt<StudentResponse>();
    }
}