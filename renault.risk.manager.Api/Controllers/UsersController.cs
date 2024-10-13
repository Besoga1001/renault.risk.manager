using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using renault.risk.manager.Application.Interfaces.Services;

namespace renault.risk.manager.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class UsersController : ControllerBase
{
    private readonly IUserService _userService;

    public UsersController(IUserService userService)
    {
        _userService = userService;
    }

    [HttpGet]
    public async Task<IActionResult> GenerateToken()
    {
        var response = await _userService.GenerateToken();
        return Ok(response.AccessToken);
    }

    [HttpPost]
    [Authorize(Policy = "ApiAccess")]
    public void ValidateUser()
    {
        _userService.ValidateUser();
    }
}