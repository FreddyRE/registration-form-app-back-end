using Microsoft.EntityFrameworkCore;
using RegistrationForm.Data;
using RegistrationForm.Mappings;
using RegistrationForm.Middleware;
using RegistrationForm.Repositories;
using RegistrationForm.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

builder.Services.AddDbContext<AppDbContext>(options => 
    options.UseInMemoryDatabase("RegistrationDb")
);

builder.Services.AddAutoMapper(typeof(UserProfile));
builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<IRegistrationService, RegistrationService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseMiddleware<ErrorHandlingMiddleware>();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
