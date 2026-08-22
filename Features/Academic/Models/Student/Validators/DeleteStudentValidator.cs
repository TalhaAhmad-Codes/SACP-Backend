using Backend.Features.Academic.Models.Student.Commands.DeleteStudent;
using FluentValidation;

namespace Backend.Features.Academic.Models.Student.Validators
{
    public sealed class DeleteStudentValidator : AbstractValidator<DeleteStudentCommand>
    {
        public DeleteStudentValidator()
        {
            // * Id
            RuleFor(s => s.Id).NotEmpty().WithMessage("Student must be provided");
        }
    }
}
