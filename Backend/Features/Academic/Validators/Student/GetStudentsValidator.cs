using Backend.Features.Academic.Queries.Student.GetStudent;
using Backend.Shared.Common.FixedValue;
using FluentValidation;

namespace Backend.Features.Academic.Validators.Student;

public sealed class GetStudentsValidator : AbstractValidator<GetStudentsQuery>
{
    public GetStudentsValidator()
    {
        // * Page Number
        RuleFor(s => s.PageNumber)
            .GreaterThan(0).WithMessage("Page number must be greater than 0");
        
        // * Page Size
        RuleFor(s => s.PageSize)
            .GreaterThanOrEqualTo(MinValue.PageSize).WithMessage($"Page size must be greater than '{MinValue.PageSize}'");
    }
}