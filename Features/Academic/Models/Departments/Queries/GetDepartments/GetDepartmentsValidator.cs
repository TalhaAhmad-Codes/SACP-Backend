using Backend.Shared.Common.Utilities;
using Backend.Shared.Extensions;
using Backend.Shared.Validators;
using FluentValidation;

namespace Backend.Features.Academic.Models.Departments.Queries.GetDepartments
{
    public sealed class GetDepartmentsValidator : BasePagedValidator<GetDepartmentsQuery>
    {
        public GetDepartmentsValidator()
            : base()
        {
            RuleFor(d => d.Name)
                .StringMinMax("Department name", maxLength: MaxValue.DepartmentName)
                .Unless(d => string.IsNullOrEmpty(d.Name));

            RuleFor(d => d.InstitutionId)
                .NotEmpty()
                .WithMessage(Message.NotEmpty("Institution"))
                .When(d => d.InstitutionId.HasValue);
        }
    }
}
