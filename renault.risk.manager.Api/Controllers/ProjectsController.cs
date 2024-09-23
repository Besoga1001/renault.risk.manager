using Microsoft.AspNetCore.Mvc;
using renault.risk.manager.Application.Interfaces.Services;
using renault.risk.manager.Domain.RequestDTOs;

namespace renault.risk.manager.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ProjectsController(IProjectService projectService) : ControllerBase
{
    [HttpPost]
    public async Task<ObjectResult> Insert(ProjectRequestDTO projectRequestDto)
    {
        return new OkObjectResult(await projectService.Insert(projectRequestDto));
    }
    
    [HttpGet]
    public ObjectResult GetAll([FromQuery] string? name)
    {
        return new OkObjectResult(projectService.GetAllAsync(name));
    }
    
    [HttpGet("{id:int}")]
    public ObjectResult GetById(int id)
    {
        return new OkObjectResult(projectService.GetById(id));
    }
}