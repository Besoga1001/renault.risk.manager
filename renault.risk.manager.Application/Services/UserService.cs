using Microsoft.Identity.Client;
using renault.risk.manager.Application.Interfaces.Services;

namespace renault.risk.manager.Application.Services;

public class UserService : IUserService
{
    private readonly string[] _scopes = { "api://30b509a7-03cf-4e96-bc35-f74391c15990/.default" };

    public void ValidateUser()
    {

    }

    public async Task<AuthenticationResult> GenerateToken()
    {
        var app = ConfidentialClientApplicationBuilder
            .Create("30b509a7-03cf-4e96-bc35-f74391c15990")
            .WithClientSecret("It68Q~i4tAM5YTZx43UrkmyNcekY8YHXQc4f4aZT")
            .WithAuthority(new Uri("https://login.microsoftonline.com/245c550b-85da-468e-812b-0fe900e4abaf"))
            .Build();

        return await app
            .AcquireTokenForClient(_scopes)
            .ExecuteAsync();
    }
}