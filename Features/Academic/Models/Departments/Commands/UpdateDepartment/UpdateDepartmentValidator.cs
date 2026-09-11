using Backend.Shared.Common.Utilities;
using Backend.Shared.Extensions;
using Backend.Shared.Validators;
using FluentValidation;

namespace Backend.Features.Academic.Models.Departments.Commands.UpdateDepartment
{
    public sealed class UpdateDepartmentValidator : BaseValidator<UpdateDepartmentCommand>
    {
        public UpdateDepartmentValidator()
            : base()
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
        }
    }
}
