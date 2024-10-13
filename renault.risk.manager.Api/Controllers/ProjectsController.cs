using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using renault.risk.manager.Application.Interfaces.Services;
using renault.risk.manager.Domain.RequestDTOs;

namespace renault.risk.manager.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ProjectsController(IProjectService projectService) : ControllerBase
{
    [HttpPost]
    [Authorize(Policy = "ApiAccess")]
    public async Task<ObjectResult> Insert(ProjectRequestDTO projectRequestDto)
    {
        return new OkObjectResult(await projectService.Insert(projectRequestDto));
    }
    
    [HttpGet]
    [Authorize(Policy = "ApiAccess")]
    public async Task<ObjectResult> GetAll([FromQuery] string? name)
    {
        return new OkObjectResult(await projectService.GetAllAsync(name));
    }
    
    [HttpGet("{id:int}")]
    [Authorize(Policy = "ApiAccess")]
    public async Task<ObjectResult> GetById(int id)
    {
        return new OkObjectResult(await projectService.GetByIdAsync(id));
    }
}