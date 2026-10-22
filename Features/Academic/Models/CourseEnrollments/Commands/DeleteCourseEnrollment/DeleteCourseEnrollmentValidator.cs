using Backend.Shared.Extensions;
using FluentValidation;

namespace Backend.Features.Academic.Models.CourseEnrollments.Commands.DeleteCourseEnrollment
{
    public sealed class DeleteCourseEnrollmentValidator
        : AbstractValidator<DeleteCourseEnrollmentCommand>
    {
        public DeleteCourseEnrollmentValidator()
        {
            RuleFor(e => e.Id).RequiredId();
        }
    }
}
