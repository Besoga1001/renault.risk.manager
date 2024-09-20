using Microsoft.AspNetCore.Mvc;
using renault.risk.manager.Application.Interfaces;
using renault.risk.manager.Domain.RequestDTOs;
using renault.risk.manager.Domain.ResponseDTOs;

namespace renault.risk.manager.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ProjectsController(IProjectService projectService) : ControllerBase
{
    [HttpPost]
    public async Task<ObjectResult> Insert(ProjectRequestDTO projectRequestDto)
    {
        ProjectResponseDTO response = await projectService.Insert(projectRequestDto);
        return new OkObjectResult(response);
    }
}