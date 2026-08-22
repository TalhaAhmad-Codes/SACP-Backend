using MediatR;

namespace Backend.Features.Academic.Models.Student.Commands.DeleteStudent
{
    public record DeleteStudentCommand(Guid Id) : IRequest<Unit>;
}
