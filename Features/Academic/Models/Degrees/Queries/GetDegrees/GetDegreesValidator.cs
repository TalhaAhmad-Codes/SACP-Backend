using Backend.Shared.Common.Utilities;
using Backend.Shared.Extensions;
using Backend.Shared.Validators;
using FluentValidation;

namespace Backend.Features.Academic.Models.Degrees.Queries.GetDegrees
{
    public sealed class GetDegreesValidator : BasePagedValidator<GetDegreesQuery>
    {
        public GetDegreesValidator()
            : base()
        {
            // Title
            RuleFor(d => d.Title)
                .StringMinMax("Title", MinValue.DegreeTitle, MaxValue.DegreeTitle)
                .When(d => d.Title is not null);

            // Code
            RuleFor(d => d.Code)
                .StringMinMax("Code", MinValue.DegreeCode, MaxValue.DegreeCode)
                .When(d => d.Code is not null);

            // Department
            RuleFor(d => d.DepartmentId)
                .NotEmpty()
                .WithMessage(Message.NotEmpty("Department"))
                .When(d => d.DepartmentId.HasValue);
        }
    }
}
