using Backend.Shared.Extensions;
using FluentValidation;

namespace Backend.Features.Academic.Models.CourseEnrollments.Queries.GetCourseEnrollmentById
{
    public sealed class GetCourseEnrollmentByIdValidator
        : AbstractValidator<GetCourseEnrollmentByIdQuery>
    {
        public GetCourseEnrollmentByIdValidator()
        {
            RuleFor(e => e.Id).RequiredId();
        }
    }
}
