using Backend.Features.Academic.Responses;
using Backend.Shared.Common.Pagination;
using MediatR;

namespace Backend.Features.Academic.Queries.Student.GetStudent
{
    public sealed record GetStudentsQuery(
        StudentFilter Filter,
        int PageNumber = 1,
        int PageSize = 10
    ) : IRequest<PagedResult<StudentResponse>>;
}
