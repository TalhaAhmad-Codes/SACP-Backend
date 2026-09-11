namespace Backend.Shared.Extensions
{
    public static class ApplicationBuilderExtensions
    {
        // This extension method configures the application to use Swagger for API documentation, sets up authentication and authorization middleware, and maps controller routes.
        public static WebApplication UseApplicationServices(this WebApplication app)
        {
            app.UseSwagger();
            app.UseSwaggerUI();

            app.UseAuthentication();
            app.UseAuthorization();

            app.MapControllers();

            return app;
        }
    }
}
