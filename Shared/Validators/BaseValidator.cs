using Backend.Shared.Common.DTOs;
using Backend.Shared.Extensions;
using FluentValidation;

namespace Backend.Shared.Validators
{
    public abstract class BaseValidator<T> : AbstractValidator<T>
        where T : BaseDto
    {
        protected BaseValidator()
        {
            RuleFor(x => x.Id).RequiredId();
        }
    }
}
