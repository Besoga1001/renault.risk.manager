using Microsoft.AspNetCore.Mvc;
using renault.risk.manager.Application.Interfaces.Services;
using renault.risk.manager.Domain.RequestDTOs;

namespace renault.risk.manager.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class JalonsController : ControllerBase
{
    private readonly IJalonService _jalonService;

    //ReSharper disable once ConvertToPrimaryConstructor
    public JalonsController(IJalonService jalonService)
    {
        _jalonService = jalonService;
    }

    [HttpPost]
    public async Task<ObjectResult> Insert(JalonRequestDTO jalonRequestDto)
    {
        return new OkObjectResult(await _jalonService.Insert(jalonRequestDto));
    }

    [HttpGet]
    public async Task<ObjectResult> GetAll([FromQuery] string? name)
    {
        return new OkObjectResult(await _jalonService.GetAllAsync(name));
    }

    [HttpGet("{id:int}")]
    public async Task<ObjectResult> GetById(int id)
    {
        return new OkObjectResult(await _jalonService.GetByIdAsync(id));
    }

    [HttpDelete]
    public async Task<ObjectResult> Delete(int id)
    {
        return new OkObjectResult(await _jalonService.Delete(id));
    }

}