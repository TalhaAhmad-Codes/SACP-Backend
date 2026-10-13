using Backend.Shared.Extensions;
using FluentValidation;

namespace Backend.Features.Academic.Models.Degrees.Commands.DeleteDegree
{
    public sealed class DeleteDegreeValidator : AbstractValidator<DeleteDegreeCommand>
    {
        public DeleteDegreeValidator()
        {
            RuleFor(d => d.Id).RequiredId();
        }
    }
}
