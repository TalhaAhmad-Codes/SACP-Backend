using Backend.Features.Academic.Commands.Student.DeleteStudent;
using FluentValidation;

namespace Backend.Features.Academic.Validators.Student
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
