using Backend.Features.Academic.Models.Student.Queries.GetStudent;
using Backend.Features.Academic.Models.Student.Responses;
using Backend.Features.Academic.Providers.Interfaces;
using Backend.Infrastructure.Persistence;
using Mapster;
using MediatR;

namespace Backend.Features.Academic.Models.Student.Handlers.Queries;

public sealed class GetStudentByIdAsync : IRequestHandler<GetStudentByIdQuery, StudentResponse>
{
    private readonly ApplicationDbContext _context;
    private readonly IStudentProvider _studentProvider;

    public GetStudentByIdAsync(ApplicationDbContext context, IStudentProvider studentProvider)
    {
        _context = context;
        _studentProvider = studentProvider;
    }

    public async Task<StudentResponse> Handle(GetStudentByIdQuery request, CancellationToken cancellationToken)
    {
        var student = await _studentProvider.GetByIdAsync(request.Id, cancellationToken);
        return student.Adapt<StudentResponse>();
    }
}