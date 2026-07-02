using Backend.Features.Academic.Queries.Student.GetStudent;
using Backend.Features.Academic.Responses;
using Backend.Infrastructure.Persistence;
using Mapster;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Backend.Features.Academic.Handlers.Students.Queries;

public sealed class GetStudentByEmailHandler : IRequestHandler<GetStudentByEmailQuery, StudentResponse?>
{
    private readonly ApplicationDbContext _context;

    public GetStudentByEmailHandler(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<StudentResponse?> Handle(GetStudentByEmailQuery request, CancellationToken cancellationToken)
    {
        var student = await _context.Students.FirstOrDefaultAsync(s => s.Email == request.Email.Trim());
        return student?.Adapt<StudentResponse>();
    }
}