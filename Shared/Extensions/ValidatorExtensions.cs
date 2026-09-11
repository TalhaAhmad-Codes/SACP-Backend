using Backend.Shared.Common.Utilities;
using FluentValidation;

namespace Backend.Shared.Extensions
{
    public static class ValidatorExtensions
    {
        public static IRuleBuilderOptions<T, Guid> RequiredId<T>(
            this IRuleBuilder<T, Guid> ruleBuilder,
            string property = "Id"
        )
            where T : notnull
        {
            return ruleBuilder.NotEmpty().WithMessage(Message.NotEmpty(property));
        }

        public static IRuleBuilderOptions<T, string> RequiredString<T>(
            this IRuleBuilder<T, string> ruleBuilder,
            string property,
            int? minLength = null,
            int? maxLength = null
        )
            where T : notnull
        {
            var builder = ruleBuilder.NotEmpty().WithMessage(Message.NotEmpty(property));

            if (maxLength.HasValue)
            {
                builder = builder
                    .MaximumLength(maxLength.Value)
                    .WithMessage(Message.InvalidMaxLength(property, maxLength.Value));
            }

            if (minLength.HasValue)
            {
                builder = builder
                    .MinimumLength(minLength.Value)
                    .WithMessage(Message.InvalidMinLength(property, minLength.Value));
            }

            return builder;
        }

        public static IRuleBuilderOptions<T, string?> StringMinMax<T>(
            this IRuleBuilder<T, string?> ruleBuilder,
            string property,
            int? minLength = null,
            int? maxLength = null
        )
            where T : notnull
        {
            var builder = ruleBuilder;

            if (maxLength.HasValue)
            {
                builder = builder
                    .MaximumLength(maxLength.Value)
                    .WithMessage(Message.InvalidMaxLength(property, maxLength.Value));
            }

            if (minLength.HasValue)
            {
                builder = builder
                    .MinimumLength(minLength.Value)
                    .WithMessage(Message.InvalidMinLength(property, minLength.Value));
            }

            return (IRuleBuilderOptions<T, string>)builder;
        }
    }
}
