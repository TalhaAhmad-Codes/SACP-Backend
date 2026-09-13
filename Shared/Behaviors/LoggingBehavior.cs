using MediatR;
using Serilog;

namespace Backend.Shared.Behaviors
{
    // This class is a MediatR pipeline behavior that logs the handling of requests and their completion using Serilog.
    public sealed class LoggingBehavior<TRequest, TResponse>
        : IPipelineBehavior<TRequest, TResponse>
        where TRequest : notnull
    {
        // This method is called for each request passing through the MediatR pipeline. It logs the start of handling the request, then calls the next behavior or handler in the pipeline, and finally logs the completion of the request before returning the response.
        public async Task<TResponse> Handle(
            TRequest request,
            CancellationToken cancellationToken,
            RequestHandlerDelegate<TResponse> next
        )
        {
            var requestName = typeof(TRequest).Name; // Get the name of the request type for logging purposes.
            Log.Information("Handling request {RequestName} {@Request}", requestName, request);

            var response = await next(); // Call the next behavior or handler in the pipeline to process the request and get the response.
            Log.Information("Completed request {RequestName}", requestName);

            return response;
        }
    }
}
