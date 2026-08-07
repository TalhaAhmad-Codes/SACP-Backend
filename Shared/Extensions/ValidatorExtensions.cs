using Backend.Shared.Common;
using FluentValidation;

namespace Backend.Shared.Extensions
{
    public static class ValidatorExtensions
    {
        public static IRuleBuilderOptions<T, Guid> RequiredId<T>(this IRuleBuilder<T, Guid> ruleBuilder, string property)
            where T : notnull
        {
            return ruleBuilder
                .NotEmpty()
                .WithMessage(Message.NotEmpty($"{property} id"));
        }
    }
}
