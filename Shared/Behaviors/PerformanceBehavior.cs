using System.Diagnostics;
using MediatR;

namespace Backend.Shared.Behaviors
{
    // ? This class is a MediatR pipeline behavior that measures the performance of handling requests and logs a warning if the handling time exceeds a certain threshold (500 milliseconds in this case).
    public sealed class PerformanceBehavior<TRequest, TResponse>
        : IPipelineBehavior<TRequest, TResponse>
        where TRequest : notnull
    {
        private readonly ILogger<PerformanceBehavior<TRequest, TResponse>> _logger;
        private readonly Stopwatch _timer;

        public PerformanceBehavior(ILogger<PerformanceBehavior<TRequest, TResponse>> logger)
        {
            _logger = logger;
            _timer = new Stopwatch();
        }

        // ? This method is called for each request passing through the MediatR pipeline. It starts a timer before calling the next behavior or handler in the pipeline to process the request, and then stops the timer after processing is complete. If the elapsed time exceeds 500 milliseconds, it logs a warning with the request name, elapsed time, and request details.
        public async Task<TResponse> Handle(
            TRequest request,
            CancellationToken cancellationToken,
            RequestHandlerDelegate<TResponse> next
        )
        {
            _timer.Start();

            var response = await next();

            _timer.Stop();

            var elapsedMilliseconds = _timer.ElapsedMilliseconds;

            if (elapsedMilliseconds > 500) // * If the elapsed time exceeds 500 milliseconds, log a warning with the request name, elapsed time, and request details.
            {
                var requestName = typeof(TRequest).Name;
                _logger.LogWarning(
                    "Long Running Request: {Name} ({ElapsedMilliseconds} milliseconds) {@Request}",
                    requestName,
                    elapsedMilliseconds,
                    request
                );
            }

            return response;
        }
    }
}
