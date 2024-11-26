using renault.risk.manager.Application.Extensions;
using renault.risk.manager.Application.Interfaces.Repositories;
using renault.risk.manager.Application.Interfaces.Services;
using renault.risk.manager.Domain.Entities;
using renault.risk.manager.Domain.RequestDTOs;
using renault.risk.manager.Domain.ResponseDTOs;

namespace renault.risk.manager.Application.Services;

public class ProjectService : IProjectService
{
    private readonly IProjectRepository projectRepository;
    private readonly IJalonRepository jalonRepository;

    // ReSharper disable once ConvertToPrimaryConstructor
    public ProjectService(IProjectRepository projectRepository, IJalonRepository jalonRepository)
    {
        this.projectRepository = projectRepository;
        this.jalonRepository = jalonRepository;
    }
    
    public async Task<ProjectResponseDTO> Insert(ProjectRequestDTO projectRequestDto)
    {
        var jalonEntities = new List<tb_jalon>();
        foreach (var jalonId in projectRequestDto.Jalons)
        {
            jalonEntities.Add(await jalonRepository.GetByIdAsync(jalonId));
        }
        var projectEntity = await projectRepository.AddAsync(projectRequestDto.ToEntity(jalonEntities));
        await projectRepository.SaveChangesAsync();
        return projectEntity.ToDto();
    }

    public async Task<List<ProjectResponseDTO>> GetAllAsync(string? name)
    {
        var projectEntities = await projectRepository.GetAllAsync(name);
        return projectEntities.Select(x => x.ToDto()).ToList();
    }
    
    public async Task<ProjectResponseDTO> GetByIdAsync(int id)
    {
        var projectEntity = await projectRepository.GetByIdAsync(id);
        return projectEntity.ToDto();
    }

    public string Delete(int id)
    {
        var response = projectRepository.Remove(id);
        return response ? $"Registry {id} Deleted Successfully" : $"Error to Delete Registry {id}";
    }

}