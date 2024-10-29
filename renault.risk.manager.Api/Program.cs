using Microsoft.EntityFrameworkCore;
using renault.risk.manager.Api.Middlewares;
using renault.risk.manager.Application.Interfaces.Repositories;
using renault.risk.manager.Application.Interfaces.Services;
using renault.risk.manager.Application.Services;
using renault.risk.manager.Infrastructure.Context;
using renault.risk.manager.Infrastructure.Repositories.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddControllers();

builder.Services.Configure<RouteOptions>(options =>
{
    options.LowercaseUrls = true;
});

// MSAL Tokens Configuration

/*
builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddMicrosoftIdentityWebApi(builder.Configuration.GetSection("AzureAd"));

builder.Services.AddAuthorization();

*/

// builder.Services.AddAuthorization(options =>
// {
//     options.AddPolicy("ApiAccess", policy =>
//         policy.RequireClaim("scp", "api.Read"));
// });

builder.Services.AddDbContext<RiskManagerContext>(options =>
    options.UseNpgsql(builder.Configuration
        .GetConnectionString("DefaultConnection"))
        .UseLazyLoadingProxies());

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
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthentication();
app.UseAuthorization();

app.UseHttpsRedirection();
app.UseMiddleware<RiskManagerExceptionMiddleware>();
app.MapControllers();

app.Run();