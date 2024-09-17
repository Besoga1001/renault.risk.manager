using Microsoft.AspNetCore.Mvc;
using renault.risk.manager.Application.Interfaces;
using renault.risk.manager.Domain.RequestDTOs;
using renault.risk.manager.Domain.ResponseDTOs;

namespace renault.risk.manager.Api.Controllers;

public class ProjectsController
{
    private readonly IProjectService _projectService;

    public ProjectsController(IProjectService projectService)
    {
        _projectService = projectService;
    }

    [HttpPost]
    public async Task<ActionResult<ProjectResponseDTO>> Insert(ProjectRequestDTO projectRequestDto)
    {
        ProjectResponseDTO response = await _projectService.Insert(projectRequestDto);
        // return Ok(response);
        return null;
    }
}