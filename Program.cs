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

// namespace Backend
// {
//     public class Program
//     {
//         public static void Main(string[] args)
//         {
//             var builder = WebApplication.CreateBuilder(args);

//             // Add services to the container.

//             builder.Services.AddControllers();
//             // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
//             builder.Services.AddEndpointsApiExplorer();
//             builder.Services.AddSwaggerGen();

//             var app = builder.Build();

//             // Configure the HTTP request pipeline.
//             if (app.Environment.IsDevelopment())
//             {
//                 app.UseSwagger();
//                 app.UseSwaggerUI();
//             }

//             app.UseHttpsRedirection();

//             app.UseAuthorization();


//             app.MapControllers();

//             app.Run();
//         }
//     }
// }