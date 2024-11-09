using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using renault.risk.manager.Application.Interfaces.Services;

namespace renault.risk.manager.Api.Controllers;

// [Authorize]
[ApiController]
[Route("api/home")]
public class HomeController : ControllerBase
{
    private readonly IHomeService homeService;

    // ReSharper disable once ConvertToPrimaryConstructor
    public HomeController(IHomeService homeService)
    {
        this.homeService = homeService;
    }

    [HttpGet("cards")]
    public async Task<ObjectResult> GetInfoCards()
    {
        return new ObjectResult(await homeService.GetInfoCards());
    }

    [HttpGet("graphic")]
    public async Task<ObjectResult> GetNumberOfRisksPerProject()
    {
        return new ObjectResult(await homeService.GetNumberOfRisksPerProject());
    }
}