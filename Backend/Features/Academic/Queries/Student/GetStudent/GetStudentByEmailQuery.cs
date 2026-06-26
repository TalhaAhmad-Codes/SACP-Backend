using Backend.Features.Academic.Responses;
using MediatR;

namespace Backend.Features.Academic.Queries.Student.GetStudent
{
    public sealed record GetStudentByEmailQuery(string Email) : IRequest<StudentResponse?>;
}
