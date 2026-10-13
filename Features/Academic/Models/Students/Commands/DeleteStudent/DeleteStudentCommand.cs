using Backend.Shared.Common.DTOs;
using MediatR;

namespace Backend.Features.Academic.Models.Students.Commands.DeleteStudent
{
    public sealed class DeleteStudentCommand : BaseDto, IRequest<Unit> { }
}
