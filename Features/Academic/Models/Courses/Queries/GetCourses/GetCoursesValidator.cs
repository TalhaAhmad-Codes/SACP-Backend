using Backend.Shared.Common.Utilities;
using Backend.Shared.Extensions;
using Backend.Shared.Validators;
using FluentValidation;

namespace Backend.Features.Academic.Models.Courses.Queries.GetCourses
{
    public sealed class GetCoursesValidator : BasePagedValidator<GetCoursesQuery>
    {
        public GetCoursesValidator()
            : base()
        {
            RuleFor(c => c.Title)
                .StringMinMax("Title", MinValue.CourseTitle, MaxValue.CourseTitle)
                .When(c => c.Title is not null);

            RuleFor(c => c.Code)
                .StringMinMax("Code", MinValue.CourseCode, MaxValue.CourseCode)
                .When(c => c.Code is not null);

            RuleFor(c => c.Semester)
                .GreaterThan(0)
                .WithMessage(Message.ZeroOrLess("Semester"))
                .When(c => c.Semester.HasValue);

            RuleFor(c => c.DegreeId)
                .NotEmpty()
                .WithMessage(Message.NotEmpty("Degree"))
                .When(c => c.DegreeId.HasValue);
        }
    }
}
