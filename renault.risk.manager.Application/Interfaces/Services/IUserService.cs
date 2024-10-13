using Microsoft.Identity.Client;

namespace renault.risk.manager.Application.Interfaces.Services;

public interface IUserService
{
    void ValidateUser();
    Task<AuthenticationResult> GenerateToken();
}