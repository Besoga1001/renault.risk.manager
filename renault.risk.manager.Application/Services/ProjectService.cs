using renault.risk.manager.Application.Extensions;
using renault.risk.manager.Application.Interfaces;
using renault.risk.manager.Domain.Entities;
using renault.risk.manager.Domain.RequestDTOs;
using renault.risk.manager.Domain.ResponseDTOs;
using renault.risk.manager.Infrastructure.Repositories.Interfaces;

namespace renault.risk.manager.Application.Services;

public class ProjectService(IProjectRepository projectRepository) : IProjectService
{

    public async Task<ProjectResponseDTO> Insert(ProjectRequestDTO projectRequestDto)
    {
        tb_project projectEntity = await projectRepository.AddAsync(projectRequestDto.toEntity());
        return projectEntity.toDTO();
    }

    public Task<IEnumerable<ProjectResponseDTO>> GetAll()
    {
        return null;
    }

    public bool Delete(int id)
    {
        return false;
    }
}