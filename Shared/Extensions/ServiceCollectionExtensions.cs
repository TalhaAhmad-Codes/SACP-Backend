using Backend.Shared.Behaviors;
using FluentValidation;
using MediatR;

namespace Backend.Shared.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services)
        {
            // Register MediatR and discover handlers
            services.AddMediatR(typeof(Program).Assembly);

            // Register pipeline behaviors
            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(LoggingBehavior<,>));

            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidationBehavior<,>));

            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(PerformanceBehavior<,>));

            // Register validators
            services.AddValidatorsFromAssembly(typeof(Program).Assembly);

            return services;

            //// services.AddMediatR(cfg =>
            //// {
            ////     cfg.RegisterServicesFromAssembly(typeof(Program).Assembly);

            ////     cfg.AddOpenBehavior(typeof(LoggingBehavior<,>));
            ////     cfg.AddOpenBehavior(typeof(ValidationBehavior<,>));
            ////     cfg.AddOpenBehavior(typeof(PerformanceBehavior<,>));
            //// });

            //// Register all behaviors and validators with the dependency injection container.
            //services.AddTransient(typeof(IPipelineBehavior<,>), typeof(LoggingBehavior<,>));
            //services.AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidationBehavior<,>));
            //services.AddTransient(typeof(IPipelineBehavior<,>), typeof(PerformanceBehavior<,>));

            //services.AddValidatorsFromAssembly(typeof(Program).Assembly);

            //return services;
        }
    }
}
