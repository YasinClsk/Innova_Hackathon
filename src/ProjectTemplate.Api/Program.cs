using ProjectTemplate.Infrastructure.Persistance.Dependencies;
using ProjectTemplate.Application.Dependencies;
using Microsoft.AspNetCore.Diagnostics;
using FluentValidation;
using System.Text.Json;
using ProjectTemplate.Api.Extensions;
using ProjectTemplate.Api.Middlewares;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using Microsoft.Extensions.Configuration;
using ProjectTemplate.Application.Options;
using ProjectTemplate.Infrastructure.Infrastructure.Dependencies;
using Serilog;
using ProjectTemplate.Api.BackgroundServices;
using Microsoft.OpenApi.Models;
using ProjectTemplate.Api.Dependencies;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddPersistanceDependencies(builder.Configuration);
builder.Services.AddApplicationDependencies();
builder.Services.AddInfrastructureDependencies();
builder.Services.AddAuthorization();

builder.Services.AddSwaggerDependencies();

builder.Services.AddHostedService<DailyChargesService>();
builder.Services.AddHostedService<MonthlyChargesService>();
builder.Services.AddHostedService<WeeklyChargesService>();

builder.Services.Configure<TokenOption>(builder.Configuration.GetSection("Jwt"));

builder.Host.UseSerilog((context,configuration) =>
{
    configuration.ReadFrom.Configuration(context.Configuration);
});

builder.Services.AddAuthenticationDependencies(builder.Configuration);

var app = builder.Build();

//app.AddExceptionHandling();

app.UseMiddleware<ValidationExceptionMiddleware>();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthentication();

app.UseAuthorization();

app.MapControllers();

app.Run();
