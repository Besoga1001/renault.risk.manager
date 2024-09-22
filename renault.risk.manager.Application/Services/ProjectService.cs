using renault.risk.manager.Application.Extensions;
using renault.risk.manager.Application.Interfaces.Repositories;
using renault.risk.manager.Application.Interfaces.Services;
using renault.risk.manager.Domain.RequestDTOs;
using renault.risk.manager.Domain.ResponseDTOs;

namespace renault.risk.manager.Application.Services;

public class ProjectService(IProjectRepository projectRepository) : IProjectService
{

    public async Task<ProjectResponseDTO> Insert(ProjectRequestDTO projectRequestDto)
    {
        var projectEntity = await projectRepository.AddAsync(projectRequestDto.ToEntity());
        return projectEntity.ToDto();
    }

    public IEnumerable<ProjectResponseDTO> GetAll()
    {
        var projectEntities = projectRepository.GetAll();
        return projectEntities.Select(x => x.ToDto());
    }
    
    public async Task<ProjectResponseDTO> GetById(int id)
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