using Backend.Shared.Common.DTOs;
using MediatR;

namespace Backend.Features.Academic.Models.CourseEnrollments.Commands.DeleteCourseEnrollment
{
    public sealed class DeleteCourseEnrollmentCommand : BaseDto, IRequest<Unit> { }
}
