using AuthService.Application.Services;
using AuthService.Domain.Interfaces;
using AuthService.Infrastructure.RabbitMQ;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

builder.Services.AddHttpClient<IAuthCheckService, AuthCheckService>();
builder.Services.AddScoped<IRabbitMqService, RabbitMqService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment() || app.Environment.IsProduction())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();



app.Run();


