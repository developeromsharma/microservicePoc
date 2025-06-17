using Microsoft.EntityFrameworkCore;
using UserService.Domain.Interfaces;
using UserService.Infrastructure.Persistence;
using UserService.Infrastructure.Repositories;

var builder = WebApplication.CreateBuilder(args);

builder.WebHost.UseUrls("http://*:5092");

builder.Services.AddDbContext<UserDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddScoped<IUserRepository, UserRepository>();

builder.Services.AddControllers();  

builder.Services.AddSwaggerGen();

var app = builder.Build();

if (app.Environment.IsDevelopment() || app.Environment.IsProduction())
{
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "User API V1");
    });
}

app.UseHttpsRedirection();
app.MapControllers();
app.Run();
