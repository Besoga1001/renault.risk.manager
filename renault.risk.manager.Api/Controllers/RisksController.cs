using System.Net;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using renault.risk.manager.Application.Interfaces.Services;
using renault.risk.manager.Domain.FiltersDTOs;
using renault.risk.manager.Domain.RequestDTOs;
using renault.risk.manager.Domain.RequestDTOs.RiskDTOs;

namespace renault.risk.manager.Api.Controllers;

[ApiController]
[Authorize]
[Route("api/risks")]
public class RisksController : ControllerBase
{
    private readonly IRiskService riskService;

    // ReSharper disable once ConvertToPrimaryConstructor
    public RisksController(IRiskService riskService)
    {
        this.riskService = riskService;
    }

    [HttpPost]
    public async Task<ObjectResult> Insert(RiskInsertRequestDTO riskInsertRequestDto)
    {
        return new ObjectResult(await riskService.InsertAsync(riskInsertRequestDto))
            { StatusCode = (int)HttpStatusCode.Created };
    }

    [HttpPost("data-import")]
    public async Task<ObjectResult> InsertRangeAsync(List<RiskInsertRequestDTO> riskInsertRequestDto)
    {
        await riskService.InsertRangeAsync(riskInsertRequestDto);
        return new ObjectResult("Data Import Completed Successfully");
    }

    [HttpPatch("{riskId}")]
    public async Task<ObjectResult> Update(int riskId, [FromBody] RiskUpdateRequestDTO riskUpdateRequestDto)
    {
        return new OkObjectResult(await riskService.UpdateAsync(riskId, riskUpdateRequestDto));
    }

    [HttpGet]
    public async Task<ObjectResult> GetAll([FromQuery] RiskFiltersDTO riskFiltersDto)
    {
        return new OkObjectResult(await riskService.GetAllAsync(riskFiltersDto));
    }

    [HttpGet("{id}")]
    public async Task<ObjectResult> GetById(int id)
    {
        return new OkObjectResult(await riskService.GetByIdAsync(id));
    }

    [HttpGet("field-options")]
    public ObjectResult GetFieldOptions()
    {
        return new OkObjectResult(riskService.GetFieldOptions());
    }
}