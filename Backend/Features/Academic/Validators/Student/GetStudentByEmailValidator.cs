using Backend.Features.Academic.Queries.Student.GetStudent;
using FluentValidation;

namespace Backend.Features.Academic.Validators.Student;

public sealed class GetStudentByEmailValidator : AbstractValidator<GetStudentByEmailQuery>
{
    public GetStudentByEmailValidator()
    {
        // * Email
        RuleFor(s => s.Email)
            .EmailAddress().WithMessage("Email address is invalid");
    }
}