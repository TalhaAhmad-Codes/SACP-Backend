using Backend.Shared.Common.Utilities;
using Backend.Shared.Extensions;
using FluentValidation;

namespace Backend.Features.Academic.Models.Degrees.Commands.UpdateDegree
{
    public sealed class UpdateDegreeValidator : AbstractValidator<UpdateDegreeCommand>
    {
        public UpdateDegreeValidator()
        {
            // Id
            RuleFor(d => d.Id).RequiredId();

            // Title
            RuleFor(d => d.Title)
                .RequiredString("Title", MinValue.DegreeTitle, MaxValue.DegreeTitle);

            // Code
            RuleFor(d => d.Code).RequiredString("Code", MinValue.DegreeCode, MaxValue.DegreeCode);

            // Department
            RuleFor(d => d.DepartmentId).RequiredId("Department");
        }
    }
}
