using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using renault.risk.manager.Application.Interfaces.Services;
using renault.risk.manager.Domain.RequestDTOs.SolutionDTOs;

namespace renault.risk.manager.Api.Controllers;

[ApiController]
[Authorize]
[Route("api/solutions")]
public class SolutionsController : ControllerBase
{
    private readonly ISolutionService solutionService;

    // ReSharper disable once ConvertToPrimaryConstructor
    public SolutionsController(ISolutionService solutionService)
    {
        this.solutionService = solutionService;
    }

    [HttpPost]
    public async Task<ObjectResult> Insert(SolutionInsertRequestDTO solutionInsertRequestDto)
    {
        return new OkObjectResult(await solutionService.InsertAsync(solutionInsertRequestDto));
    }

    [HttpPatch("{solutionId}")]
    public async Task<ObjectResult> Update(int solutionId, [FromBody] SolutionUpdateRequestDTO solutionUpdateRequestDto)
    {
        return new OkObjectResult(await solutionService.UpdateAsync(solutionId, solutionUpdateRequestDto));
    }

    [HttpGet]
    public async Task<ObjectResult> GetAll()
    {
        return new OkObjectResult(await solutionService.GetAllAsync());
    }

    [HttpGet("{id}")]
    public async Task<ObjectResult> GetById(int id)
    {
        return new OkObjectResult(await solutionService.GetByIdAsync(id));
    }

    [HttpGet("field-options")]
    public ObjectResult GetFieldOptions()
    {
        return new OkObjectResult(solutionService.GetFieldOptions());
    }
}