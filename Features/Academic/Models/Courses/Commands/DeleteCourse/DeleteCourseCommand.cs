using Backend.Shared.Common.DTOs;
using MediatR;

namespace Backend.Features.Academic.Models.Courses.Commands.DeleteCourse
{
    public sealed class DeleteCourseCommand : BaseDto, IRequest<Unit> { }
}
