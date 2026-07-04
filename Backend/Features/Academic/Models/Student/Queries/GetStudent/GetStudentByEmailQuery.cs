using Backend.Features.Academic.Models.Student.Responses;
using MediatR;

namespace Backend.Features.Academic.Models.Student.Queries.GetStudent
{
    public sealed record GetStudentByEmailQuery(string Email) : IRequest<StudentResponse?>;
}
