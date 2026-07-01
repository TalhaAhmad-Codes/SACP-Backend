using Backend.Features.Academic.Queries.Student.GetStudent;
using Backend.Features.Academic.Responses;
using Backend.Infrastructure.Persistence;
using Backend.Shared.Common.Pagination;
using Backend.Shared.Extensions;
using Mapster;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Backend.Features.Academic.Handlers.Students.Queries;

public sealed class GetStudentsHandler : IRequestHandler<GetStudentsQuery, PagedResult<StudentResponse>>
{
    private readonly ApplicationDbContext _context;

    public GetStudentsHandler(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<PagedResult<StudentResponse>> Handle(GetStudentsQuery request,
        CancellationToken cancellationToken)
    {
        var query = _context.Students.AsNoTracking().AsQueryable();
        
        // * Applying filters
        if (request.Filter.DepartmentId.HasValue)
            query = query.Where(s => s.DepartmentId == request.Filter.DepartmentId);
        
        if (request.Filter.FirstName is not null)
            query = query.Where(s => s.Name.FirstName.StartsWith(request.Filter.FirstName.Trim()));

        if (request.Filter.LastName is not null)
            query = query.Where(s => s.Name.LastName.StartsWith(request.Filter.LastName.Trim()));

        if (request.Filter.FatherName is not null)
            query = query.Where(s => s.FatherName.StartsWith(request.Filter.FatherName.Trim()));

        if (request.Filter.Gender.HasValue)
            query = query.Where(s => s.Gender == request.Filter.Gender);

        if (request.Filter.FromDateOfBirth.HasValue)
            query = query.Where(s => s.DateOfBirth >= request.Filter.FromDateOfBirth);

        if (request.Filter.ToDateOfBirth.HasValue)
            query = query.Where(s => s.DateOfBirth <= request.Filter.ToDateOfBirth);

        if (request.Filter.FromDateOfAdmission.HasValue)
            query = query.Where(s => s.DateOfAdmission >= request.Filter.FromDateOfAdmission);

        if (request.Filter.ToDateOfAdmission.HasValue)
            query = query.Where(s => s.DateOfAdmission <= request.Filter.ToDateOfAdmission);

        if (request.Filter.FromRollNumber.HasValue)
            query = query.Where(s => s.RollNumber >= request.Filter.FromRollNumber);

        if (request.Filter.ToRollNumber.HasValue)
            query = query.Where(s => s.RollNumber <= request.Filter.ToRollNumber);
        
        // * Paging
        var students = await query
            .OrderBy(u => u.RollNumber)
            .ProjectToType<StudentResponse>()
            .ToPagedResultAsync(request.PageNumber, request.PageSize, cancellationToken);

        return students;
    }
}
