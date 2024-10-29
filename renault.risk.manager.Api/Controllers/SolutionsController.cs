using Microsoft.AspNetCore.Mvc;
using renault.risk.manager.Application.Interfaces.Services;
using renault.risk.manager.Domain.RequestDTOs;

namespace renault.risk.manager.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class SolutionsController
{
    private readonly ISolutionService solutionService;

    // ReSharper disable once ConvertToPrimaryConstructor
    public SolutionsController(ISolutionService solutionService)
    {
        this.solutionService = solutionService;
    }

    [HttpPost]
    public async Task<ObjectResult> Insert(SolutionRequestDTO solutionRequestDto)
    {
        return new OkObjectResult(await solutionService.InsertAsync(solutionRequestDto));
    }

    [HttpPatch("{id}")]
    public async Task<ObjectResult> Update(SolutionRequestDTO solutionRequestDto)
    {
        return new OkObjectResult(await solutionService.UpdateAsync(solutionRequestDto));
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
}