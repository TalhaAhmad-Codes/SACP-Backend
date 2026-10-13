using Backend.Shared.Extensions;
using FluentValidation;

namespace Backend.Features.Academic.Models.Students.Commands.DeleteStudent
{
    public sealed class DeleteStudentValidator : AbstractValidator<DeleteStudentCommand>
    {
        public DeleteStudentValidator()
        {
            RuleFor(s => s.Id).RequiredId();
        }
    }
}
