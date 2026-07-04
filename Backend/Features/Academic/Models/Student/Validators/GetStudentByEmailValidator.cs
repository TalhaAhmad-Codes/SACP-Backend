using Backend.Features.Academic.Models.Student.Queries.GetStudent;
using FluentValidation;

namespace Backend.Features.Academic.Models.Student.Validators
{
    public sealed class GetStudentByEmailValidator : AbstractValidator<GetStudentByEmailQuery>
    {
        public GetStudentByEmailValidator()
        {
            // * Email
            RuleFor(s => s.Email)
                .EmailAddress().WithMessage("Email address is invalid");
        }
    }
}
