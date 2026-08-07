using Backend.Shared.Extensions;

var builder = WebApplication.CreateBuilder(args);

// ? Registering all services to the dependency injection using extension methods.
builder.Services.AddControllers();
builder.Services.AddApplicationServices();
builder.Services.AddDatabase(builder.Configuration);
builder.Services.AddJwtAuthentication(builder.Configuration);
builder.Services.AddSwaggerDocumentation();
// builder.Services.AddRedis(builder.Configuration);
builder.Services.AddHangfireServices(builder.Configuration);
builder.Services.AddProviders();

var app = builder.Build();

app.UseApplicationServices();

app.Run();
