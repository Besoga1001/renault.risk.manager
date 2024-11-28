using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using renault.risk.manager.Application.Interfaces.Services;
using renault.risk.manager.Domain.RequestDTOs;
using renault.risk.manager.Domain.RequestDTOs.MetierDTOs;

namespace renault.risk.manager.Api.Controllers;

[ApiController]
[Authorize]
[Route("api/metiers")]
public class MetiersController : ControllerBase
{
    private readonly IMetierService _metierService;

    //ReSharper disable once ConvertToPrimaryConstructor
    public MetiersController(IMetierService metierService)
    {
        _metierService = metierService;
    }

    [HttpPost]
    public async Task<ObjectResult> Insert(MetierRequestDTO metierRequestDto)
    {
        return new OkObjectResult(await _metierService.Insert(metierRequestDto));
    }

    [HttpPatch("{metierId}")]
    public async Task<ObjectResult> Patch(int metierId, MetierUpdateDTO metierUpdateDto)
    {
        return new OkObjectResult(await _metierService.Update(metierId, metierUpdateDto));
    }

    [HttpGet]
    public async Task<ObjectResult> GetAll([FromQuery] string? description)
    {
        return new OkObjectResult(await _metierService.GetAllAsync(description));
    }

    [HttpGet("{id:int}")]
    public async Task<ObjectResult> GetById(int id)
    {
        return new OkObjectResult(await _metierService.GetByIdAsync(id));
    }

    [HttpDelete]
    public async Task<ObjectResult> Delete(int id)
    {
        return new OkObjectResult(await _metierService.Delete(id));
    }
}