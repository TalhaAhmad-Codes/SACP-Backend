using Backend.Features.Academic.Models.Student.Queries.GetStudent;
using Backend.Features.Academic.Models.Student.Responses;
using Backend.Infrastructure.Persistence;
using Mapster;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Backend.Features.Academic.Models.Student.Handlers.Queries;

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
