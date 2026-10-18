using Backend.Shared.Common.Utilities;
using Backend.Shared.Extensions;
using FluentValidation;

namespace Backend.Features.Academic.Models.Courses.Commands.CreateCourse
{
    public sealed class CreateCourseValidator : AbstractValidator<CreateCourseCommand>
    {
        public CreateCourseValidator()
        {
            // Title
            RuleFor(c => c.Title)
                .RequiredString("Title", MinValue.CourseTitle, MaxValue.CourseTitle);

            // Code
            RuleFor(c => c.Code).StringMinMax("Title", MinValue.CourseCode, MaxValue.CourseCode);

            // Semester
            RuleFor(c => c.Semester).GreaterThan(0).WithMessage(Message.ZeroOrLess("Semester"));

            // Credit Hours
            RuleFor(c => c.CreditHours)
                .GreaterThan(0)
                .WithMessage(Message.ZeroOrLess("Credit Hours"))
                .When(c => c.CreditHours.HasValue);

            // Degree
            RuleFor(c => c.DegreeId).RequiredId("Degree");
        }
    }
}
