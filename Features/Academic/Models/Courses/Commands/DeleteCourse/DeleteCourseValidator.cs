using Backend.Shared.Extensions;
using FluentValidation;

namespace Backend.Features.Academic.Models.Courses.Commands.DeleteCourse
{
    public sealed class DeleteCourseValidator : AbstractValidator<DeleteCourseCommand>
    {
        public DeleteCourseValidator()
        {
            RuleFor(c => c.Id).RequiredId();
        }
    }
}
