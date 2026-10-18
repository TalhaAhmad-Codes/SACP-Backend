using Backend.Shared.Extensions;
using FluentValidation;

namespace Backend.Features.Academic.Models.Courses.Queries.GetCourseById
{
    public sealed class GetCourseByIdValidator : AbstractValidator<GetCourseByIdQuery>
    {
        public GetCourseByIdValidator()
        {
            RuleFor(c => c.Id).RequiredId();
        }
    }
}
