using Backend.Shared.Common;
using Backend.Shared.Common.DTOs;
using Backend.Shared.Common.FixedValue;
using FluentValidation;

namespace Backend.Shared.Validators
{
    public abstract class BasePagedValidator<T> : AbstractValidator<T>
        where T : BasePagedQuery
    {
        protected BasePagedValidator()
        {
            RuleFor(x => x.PageNumber)
                .GreaterThanOrEqualTo(MinValue.PageNumber)
                .WithMessage(Message.InvalidMinValue("Page number", MinValue.PageNumber));

            RuleFor(x => x.PageSize)
                .InclusiveBetween(MinValue.PageSize, MaxValue.PageSize)
                .WithMessage(
                    Message.InvalidRange("Page size", MinValue.PageSize, MaxValue.PageSize)
                );
        }
    }
}
