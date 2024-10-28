using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using renault.risk.manager.Application.Interfaces.Services;

namespace renault.risk.manager.Api.Controllers;

[ApiController]
[Authorize]
[Route("api/[controller]")]
public class UsersController : ControllerBase
{
    private readonly IUserService _userService;

    // ReSharper disable once ConvertToPrimaryConstructor
    public UsersController(IUserService userService)
    {
        _userService = userService;
    }

    [HttpPost]
    public void ValidateUser()
    {
        var email = User
            .Claims
            .FirstOrDefault(c => c.Type == "http://schemas.xmlsoap.org/ws/2005/05/identity/claims/emailaddress")?
            .Value;

        if (email != null)
        {
            _userService.ValidateUser(email);
        }
    }
}