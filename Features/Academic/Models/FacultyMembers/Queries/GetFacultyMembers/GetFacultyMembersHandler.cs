using Backend.Features.Academic.Models.FacultyMembers.Responses;
using Backend.Infrastructure.Persistence;
using Backend.Shared.Common.DTOs;
using Backend.Shared.Extensions;
using Mapster;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Backend.Features.Academic.Models.FacultyMembers.Queries.GetFacultyMembers
{
    public sealed class GetFacultyMembersHandler
        : IRequestHandler<GetFacultyMembersQuery, PagedResultDto<FacultyMemberResponseDto>>
    {
        private readonly ApplicationDbContext _context;

        public GetFacultyMembersHandler(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<PagedResultDto<FacultyMemberResponseDto>> Handle(
            GetFacultyMembersQuery request,
            CancellationToken cancellationToken
        )
        {
            var query = _context.FacultyMembers.AsNoTracking();

            // Filteration
            if (request.Name is not null)
                query = query.Where(f => EF.Functions.ILike(f.FirstName, $"{request.Name}%"));

            if (request.Role.HasValue)
                query = query.Where(f => f.Role == request.Role);

            if (request.FromDateOfJoining.HasValue)
                query = query.Where(f => f.DateOfJoining >= request.FromDateOfJoining);

            if (request.ToDateOfJoining.HasValue)
                query = query.Where(f => f.DateOfJoining <= request.ToDateOfJoining);

            if (request.HasUserAccount.HasValue)
                query = query.Where(f => f.HasUserAccount == request.HasUserAccount);

            if (request.DepartmentId.HasValue)
                query = query.Where(f => f.DepartmentId == request.DepartmentId);

            // Pagination
            var response = await query
                .OrderBy(f => f.FullName)
                .ProjectToType<FacultyMemberResponseDto>()
                .ToPagedResultAsync(request.PageNumber, request.PageSize, cancellationToken);

            return response;
        }
    }
}
