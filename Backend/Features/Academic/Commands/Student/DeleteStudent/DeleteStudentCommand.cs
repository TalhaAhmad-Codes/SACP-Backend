using MediatR;

namespace Backend.Features.Academic.Commands.Student.DeleteStudent
{
    public record DeleteStudentCommand(Guid Id) : IRequest<bool>;
}
