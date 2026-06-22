using System.Text;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;

namespace Backend.Shared.Extensions
{
    public static class AuthenticationExtensions
    {
        public static IServiceCollection AddJwtAuthentication(
            this IServiceCollection services,
            IConfiguration configuration
        )
        {
            var secretKey =
                configuration["Jwt:SecretKey"] // * Retrieve the JWT secret key from the configuration.
                ?? throw new InvalidOperationException("JWT Secret Key missing"); // * If it's missing, throw an exception to prevent misconfiguration.

            // ? Configure JWT authentication with the specified parameters, including issuer, audience, signing key, and validation settings.
            services
                .AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                .AddJwtBearer(options =>
                {
                    // * Set up the token validation parameters to ensure that incoming JWTs are properly validated against the expected issuer, audience, signing key, and lifetime.
                    options.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidateIssuer = true,
                        ValidateAudience = true,
                        ValidateIssuerSigningKey = true,
                        ValidateLifetime = true,

                        ValidIssuer = configuration["Jwt:Issuer"],
                        ValidAudience = configuration["Jwt:Audience"],

                        IssuerSigningKey = new SymmetricSecurityKey(
                            Encoding.UTF8.GetBytes(secretKey)
                        ),
                    };
                });

            services.AddAuthorization();

            return services;
        }
    }
}
