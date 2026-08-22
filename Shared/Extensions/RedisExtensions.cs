using StackExchange.Redis;

namespace Backend.Shared.Extensions
{
    public static class RedisExtensions
    {
        public static IServiceCollection AddRedis(
            this IServiceCollection services,
            IConfiguration configuration
        )
        {
            var connectionString = configuration.GetConnectionString("Redis");  // * Retrieve the Redis connection string from the configuration settings.

            // * If the connection string is not null or whitespace, register a singleton instance of IConnectionMultiplexer with the dependency injection container, connecting to Redis using the provided connection string.
            if (!string.IsNullOrWhiteSpace(connectionString))
            {
                services.AddSingleton<IConnectionMultiplexer>(_ =>
                    ConnectionMultiplexer.Connect(connectionString)
                );
            }

            return services;
        }
    }
}
