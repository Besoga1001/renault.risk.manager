using renault.risk.manager.Application.Extensions;
using renault.risk.manager.Application.Interfaces.Repositories;
using renault.risk.manager.Application.Interfaces.Services;
using renault.risk.manager.Domain.Entities;
using renault.risk.manager.Domain.RequestDTOs;
using renault.risk.manager.Domain.ResponseDTOs;

namespace renault.risk.manager.Application.Services;

public class ProjectService : IProjectService
{
    private readonly IProjectRepository _projectRepository;

    // ReSharper disable once ConvertToPrimaryConstructor
    public ProjectService(IProjectRepository projectRepository)
    {
        _projectRepository = projectRepository;
    }
    
    public async Task<ProjectResponseDTO> Insert(ProjectRequestDTO projectRequestDto)
    {
        var projectEntity = await _projectRepository.AddAsync(projectRequestDto.ToEntity());
        await _projectRepository.SaveChangesAsync();
        return projectEntity.ToDto();
    }

    public async Task<List<ProjectResponseDTO>> GetAllAsync(string? name)
    {
        List<tb_project> projectEntities;
        if (name != null)
        {
            projectEntities = await _projectRepository.GetAllAsyncByName(name);
        }
        else
        {
            projectEntities = await _projectRepository.GetAllAsync();
        }
        return projectEntities.Select(x => x.ToDto()).ToList();
    }
    
    public async Task<ProjectResponseDTO> GetById(int id)
    {
        var projectEntity = await _projectRepository.GetByIdAsync(id);
        return projectEntity.ToDto();
    }

    public string Delete(int id)
    {
        var response = _projectRepository.Remove(id);
        return response ? $"Registry {id} Deleted Successfully" : $"Error to Delete Registry {id}";
    }

}