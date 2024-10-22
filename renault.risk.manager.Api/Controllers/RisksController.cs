using Microsoft.AspNetCore.Mvc;
using renault.risk.manager.Application.Interfaces.Services;
using renault.risk.manager.Domain.RequestDTOs;

namespace renault.risk.manager.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class RisksController
{
    private readonly IRiskService riskService;

    public RisksController(IRiskService riskService)
    {
        this.riskService = riskService;
    }

    [HttpPost]
    public async Task<ObjectResult> Insert(RiskRequestDTO riskRequestDto)
    {
        return new OkObjectResult(await riskService.InsertAsync(riskRequestDto));
    }

    [HttpPatch("{id}")]
    public async Task<ObjectResult> Update(RiskRequestDTO riskRequestDto)
    {
        return new OkObjectResult(await riskService.UpdateAsync(riskRequestDto));
    }

    [HttpGet]
    public async Task<ObjectResult> GetAll()
    {
        return new OkObjectResult(await riskService.GetAllAsync());
    }

    [HttpGet("{id}")]
    public async Task<ObjectResult> GetById(int id)
    {
        return new OkObjectResult(await riskService.GetByIdAsync(id));
    }
}