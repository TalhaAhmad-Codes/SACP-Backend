using Backend.Shared.Common.Utilities;
using Backend.Shared.Extensions;
using FluentValidation;

namespace Backend.Features.Academic.Models.Departments.Commands.CreateDepartment
{
    public sealed class CreateDepartmentValidator : AbstractValidator<CreateDepartmentCommand>
    {
        public CreateDepartmentValidator()
        {
            RuleFor(d => d.Name)
                .RequiredString(
                    "Department name",
                    MinValue.DepartmentName,
                    MaxValue.DepartmentName
                );

            RuleFor(d => d.Description)
                .StringMinMax("Description", MinValue.Description, MaxValue.Description)
                .Unless(d => string.IsNullOrEmpty(d.Description));

            RuleFor(d => d.InstitutionId).RequiredId("Institution");
        }
    }
}
