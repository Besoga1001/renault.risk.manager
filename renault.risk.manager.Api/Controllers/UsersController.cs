using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using renault.risk.manager.Application.Interfaces.Services;
using renault.risk.manager.Domain.RequestDTOs.UserDTOs;

namespace renault.risk.manager.Api.Controllers;

[ApiController]
[Route("api/users")]
public class UsersController : ControllerBase
{
    private readonly IUserService userService;

    // ReSharper disable once ConvertToPrimaryConstructor
    public UsersController(IUserService userService)
    {
        this.userService = userService;
    }

    [HttpPost("login")]
    public async Task<ObjectResult> Login(UserLoginRequestDTO userLoginRequestDto)
    {
        return new OkObjectResult(await userService.Login(userLoginRequestDto));
    }

    [Authorize]
    [HttpPost("/import-data")]
    public async Task<ObjectResult> InsertRangeAsync(List<UserInsertRequestDTO> userInsertRequestDtos)
    {
        await userService.InsertRangeAsync(userInsertRequestDtos);
        return new OkObjectResult("Data Import Completed Successfully");
    }

    [HttpPost]
    [Authorize]
    public async Task<ObjectResult> InsertAsync(UserInsertRequestDTO userInsertRequestDto)
    {
        await userService.InsertAsync(userInsertRequestDto);
        return new OkObjectResult("Successfully to Insert New User.");
    }


}