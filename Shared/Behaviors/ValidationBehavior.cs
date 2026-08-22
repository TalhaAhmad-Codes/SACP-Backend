using FluentValidation;
using MediatR;

namespace Backend.Shared.Behaviors
{
    // ? This class is a MediatR pipeline behavior that performs validation on incoming requests using FluentValidation.
    public sealed class ValidationBehavior<TRequest, TResponse>
        : IPipelineBehavior<TRequest, TResponse>
        where TRequest : notnull
    {
        private readonly IEnumerable<IValidator<TRequest>> _validators;

        public ValidationBehavior(IEnumerable<IValidator<TRequest>> validators)
        {
            _validators = validators;
        }

        // ? This method is called for each request passing through the MediatR pipeline. It validates the request using all registered validators and throws a ValidationException if any validation failures occur.
        public async Task<TResponse> Handle(
            TRequest request,
            CancellationToken cancellationToken,
            RequestHandlerDelegate<TResponse> next
        )
        {
            // * If there are no validators for the request type, simply continue to the next behavior or handler in the pipeline.
            if (!_validators.Any())
            {
                return await next();
            }

            /*
            ? Create a ValidationContext for the request, which will be used by the validators to perform validation.
             * Then, execute all validators asynchronously and collect their results.
             * Finally, check for any validation failures and throw a ValidationException if any are found. If validation succeeds, continue to the next behavior or handler in the pipeline.
            */
            var context = new ValidationContext<TRequest>(request);

            var validationResults = await Task.WhenAll(
                _validators.Select(v => v.ValidateAsync(context, cancellationToken))
            );

            var failures = validationResults
                .SelectMany(result => result.Errors)
                .Where(error => error is not null)
                .ToList();

            if (failures.Count != 0)
            {
                throw new ValidationException(failures);
            }

            return await next();
        }
    }
}
