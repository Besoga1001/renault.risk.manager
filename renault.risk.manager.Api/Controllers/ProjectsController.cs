using Microsoft.AspNetCore.Mvc;
using renault.risk.manager.Application.Interfaces.Services;
using renault.risk.manager.Domain.RequestDTOs;

namespace renault.risk.manager.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ProjectsController : ControllerBase
{
    private readonly IProjectService projectService;

    // ReSharper disable once ConvertToPrimaryConstructor
    public ProjectsController(IProjectService projectService)
    {
        this.projectService = projectService;
    }

    [HttpPost]
    public async Task<ObjectResult> Insert(ProjectRequestDTO projectRequestDto)
    {
        return new OkObjectResult(await projectService.Insert(projectRequestDto));
    }
    
    [HttpGet]
    public async Task<ObjectResult> GetAll([FromQuery] string? name)
    {
        return new OkObjectResult(await projectService.GetAllAsync(name));
    }
    
    [HttpGet("{id:int}")]
    public async Task<ObjectResult> GetById(int id)
    {
        return new OkObjectResult(await projectService.GetByIdAsync(id));
    }
}