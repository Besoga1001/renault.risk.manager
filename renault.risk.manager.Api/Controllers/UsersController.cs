using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using renault.risk.manager.Application.Interfaces.Services;
using renault.risk.manager.Domain.RequestDTOs;

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

    [HttpPost("/import-data")]
    public async Task<ObjectResult> InsertRangeAsync(List<UserInsertRequestDTO> userInsertRequestDtos)
    {
        await userService.InsertRangeAsync(userInsertRequestDtos);
        return new ObjectResult("Data Import Completed Successfully");
    }
}