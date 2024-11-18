using System.Security.Claims;
using Microsoft.AspNetCore.Http;
using renault.risk.manager.Application.Interfaces.Services;

namespace renault.risk.manager.Application.Services;

public class ClaimsUserService : IClaimsUserService
{
    private readonly IHttpContextAccessor httpContextAccessor;

    public ClaimsUserService(IHttpContextAccessor httpContextAccessor)
    {
        this.httpContextAccessor = httpContextAccessor;
    }

    public string GetCurrentUserEmail()
    {
        var emailClaim = httpContextAccessor.HttpContext?.User.FindFirst(ClaimTypes.Email);
        return emailClaim == null ? "" : emailClaim.Value;
    }
}