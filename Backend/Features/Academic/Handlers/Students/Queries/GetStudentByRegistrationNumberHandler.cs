using Backend.Features.Academic.Queries.Student.GetStudent;
using Backend.Features.Academic.Responses;
using Backend.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using Mapster;
using MediatR;

namespace Backend.Features.Academic.Handlers.Students.Queries;

public sealed class GetStudentByRegistrationNumberHandler : IRequestHandler<GetStudentByRegistrationNumberQuery, StudentResponse?>
{
    private readonly ApplicationDbContext _context;

    public GetStudentByRegistrationNumberHandler(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<StudentResponse?> Handle(GetStudentByRegistrationNumberQuery request, CancellationToken cancellationToken)
    {
        var student = await _context.Students.FirstOrDefaultAsync(s => s.RegistrationNumber == request.RegistrationNumber.Trim(), cancellationToken);

        return student?.Adapt<StudentResponse>();
    }
}
