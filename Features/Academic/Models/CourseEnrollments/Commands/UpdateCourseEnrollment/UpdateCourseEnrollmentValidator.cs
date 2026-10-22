using Backend.Shared.Extensions;
using FluentValidation;

namespace Backend.Features.Academic.Models.CourseEnrollments.Commands.UpdateCourseEnrollment
{
    public sealed class UpdateCourseEnrollmentValidator
        : AbstractValidator<UpdateCourseEnrollmentCommand>
    {
        public UpdateCourseEnrollmentValidator()
        {
            RuleFor(e => e.Id).RequiredId();

            RuleFor(e => e.Status).InEnum();

            RuleFor(e => e.CourseId).RequiredId("Course");

            RuleFor(e => e.SessionId).RequiredId("Session");

            RuleFor(e => e.StudentId).RequiredId("Student");
        }
    }
}
