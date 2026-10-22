using Backend.Shared.Extensions;
using FluentValidation;

namespace Backend.Features.Academic.Models.CourseEnrollments.Commands.CreateCourseEnrollment
{
    public sealed class CreateCourseEnrollmentValidator
        : AbstractValidator<CreateCourseEnrollmentCommand>
    {
        public CreateCourseEnrollmentValidator()
        {
            RuleFor(e => e.Status).InEnum();

            RuleFor(e => e.CourseId).RequiredId("Course");

            RuleFor(e => e.SessionId).RequiredId("Session");

            RuleFor(e => e.StudentId).RequiredId("Student");
        }
    }
}
