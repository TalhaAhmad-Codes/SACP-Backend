using System.Linq.Expressions;
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

        public static IRuleBuilderOptions<T, E> InEnum<T, E>(this IRuleBuilder<T, E> ruleBuilder)
            where E : struct, Enum
        {
            return ruleBuilder
                .IsInEnum()
                .WithMessage(Message.InvalidEnum(typeof(E).Name, Enum.GetValues(typeof(E))));
        }

        // For Date Ranges
        public static IRuleBuilderOptions<T, DateOnly> PastOrPresentDate<T>(
            this IRuleBuilder<T, DateOnly> ruleBuilder,
            string property
        )
            where T : notnull
        {
            return ruleBuilder
                .Must(d => d <= DateOnly.FromDateTime(DateTime.UtcNow))
                .WithMessage(Message.MustPastOrPresentDate(property));
        }

        public static IRuleBuilderOptions<T, DateOnly> PresentOrFutureDate<T>(
            this IRuleBuilder<T, DateOnly> ruleBuilder,
            string property
        )
            where T : notnull
        {
            return ruleBuilder
                .Must(d => d >= DateOnly.FromDateTime(DateTime.UtcNow))
                .WithMessage(Message.MustPresentOrFutureDate(property));
        }

        public static void NullableDateRange<T>(
            this AbstractValidator<T> validator,
            Expression<Func<T, DateOnly?>> fromDate,
            Expression<Func<T, DateOnly?>> toDate,
            string property
        )
        {
            // From Date
            validator
                .RuleFor(fromDate)
                .LessThanOrEqualTo(DateOnly.FromDateTime(DateTime.UtcNow))
                .WithMessage(Message.MustPastOrPresentDate($"From {property}"));

            // To Date
            validator
                .RuleFor(toDate)
                .LessThanOrEqualTo(DateOnly.FromDateTime(DateTime.UtcNow))
                .WithMessage(Message.MustPastOrPresentDate($"To {property}"));

            // Range of these dates
            validator
                .RuleFor(toDate)
                .GreaterThanOrEqualTo(i => fromDate.Compile()(i))
                .WithMessage(Message.ProperRangeInclusive(property))
                .When(i =>
                {
                    var from = fromDate.Compile()(i);
                    var to = toDate.Compile()(i);

                    return from.HasValue && to.HasValue;
                });
        }

        //public static void InclusiveDateRange<T>(
        //    this AbstractValidator<T> validator,
        //    Expression<Func<T, DateOnly>> fromDate,
        //    Expression<Func<T, DateOnly>> toDate,
        //    string prop1,
        //    string prop2
        //)
        //    where T : notnull
        //{
        //    // Range of these dates
        //    validator
        //        .RuleFor(toDate)
        //        .GreaterThanOrEqualTo(i => fromDate.Compile()(i))
        //        .WithMessage(Message.ProperRangeInclusive($"Both {prop1} and {prop2}"));
        //}
    }
}
