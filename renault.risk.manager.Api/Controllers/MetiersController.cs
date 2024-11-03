using Microsoft.AspNetCore.Mvc;
using renault.risk.manager.Application.Interfaces.Services;
using renault.risk.manager.Domain.RequestDTOs;

namespace renault.risk.manager.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class MetiersController
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