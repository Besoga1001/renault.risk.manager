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
    public async Task<ObjectResult> Insert(RiskInsertRequestDTO riskInsertRequestDto)
    {
        return new OkObjectResult(await riskService.InsertAsync(riskInsertRequestDto));
    }

    [HttpPatch("{riskId}")]
    public async Task<ObjectResult> Update(int riskId, [FromBody] RiskUpdateRequestDTO riskUpdateRequestDto)
    {
        return new OkObjectResult(await riskService.UpdateAsync(riskId, riskUpdateRequestDto));
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