using System.Text.Json;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Web;
using Microsoft.OpenApi.Models;
using renault.risk.manager.Api.Middlewares;
using renault.risk.manager.Application.Interfaces.Repositories;
using renault.risk.manager.Application.Interfaces.Services;
using renault.risk.manager.Application.Services;
using renault.risk.manager.Infrastructure.Context;
using renault.risk.manager.Infrastructure.Repositories.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "Minha API", Version = "v1" });
});

builder.Services.AddEndpointsApiExplorer();

builder.Services.AddControllers()
    .AddJsonOptions(options =>
    {
        options.JsonSerializerOptions.PropertyNamingPolicy = JsonNamingPolicy.CamelCase;
    });

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAny",
        policy => policy.AllowAnyOrigin()
            .AllowAnyMethod()
            .AllowAnyHeader());
});

builder.Services.AddAuthentication();
builder.Services.AddAuthorization();

builder.Services.AddDbContext<RiskManagerContext>(options =>
    options.UseNpgsql(builder.Configuration
        .GetConnectionString("DefaultConnection"))
        .UseLazyLoadingProxies());

builder.Services.AddScoped<IMetierService, MetierService>();
builder.Services.AddScoped<IMetierRepository, MetierRepository>();

builder.Services.AddScoped<IJalonService, JalonService>();
builder.Services.AddScoped<IJalonRepository, JalonRepository>();

builder.Services.AddScoped<IProjectService, ProjectService>();
builder.Services.AddScoped<IProjectRepository, ProjectRepository>();

builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<IUserRepository, UserRepository>();

builder.Services.AddScoped<ISolutionService, SolutionService>();
builder.Services.AddScoped<ISolutionRepository, SolutionRepository>();

builder.Services.AddScoped<IRiskService, RiskService>();
builder.Services.AddScoped<IRiskRepository, RiskRepository>();

builder.Services.AddScoped<IHomeService, HomeService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment() || app.Environment.IsProduction())
{
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "Minha API v1");
    });;
}

// app.UseAuthentication();
// app.UseAuthorization();

app.UseCors("AllowAny");
app.UseHttpsRedirection();
app.UseMiddleware<RiskManagerExceptionMiddleware>();
app.MapControllers();

app.Run();