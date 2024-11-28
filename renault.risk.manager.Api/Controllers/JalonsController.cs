using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using renault.risk.manager.Application.Interfaces.Services;
using renault.risk.manager.Domain.RequestDTOs;
using renault.risk.manager.Domain.RequestDTOs.JalonDTOs;

namespace renault.risk.manager.Api.Controllers;

[ApiController]
[Authorize]
[Route("api/jalons")]
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

    [HttpPatch("{jalonId}")]
    public async Task<ObjectResult> Patch(int jalonId, JalonUpdateDTO jalonUpdateDto)
    {
        return new OkObjectResult(await _jalonService.Update(jalonId, jalonUpdateDto));
    }

    [HttpGet]
    public async Task<ObjectResult> GetAll([FromQuery] string? description)
    {
        return new OkObjectResult(await _jalonService.GetAllAsync(description));
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