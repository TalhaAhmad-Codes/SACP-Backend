using Backend.Features.Academic.Responses;
using MediatR;

namespace Backend.Features.Academic.Queries.Student.GetStudent
{
    public sealed record GetStudentByIdQuery(Guid Id) : IRequest<StudentResponse?>;
}
