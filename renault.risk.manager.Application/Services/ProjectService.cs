using renault.risk.manager.Application.Interfaces;
using renault.risk.manager.Domain.RequestDTOs;
using renault.risk.manager.Domain.ResponseDTOs;

namespace renault.risk.manager.Application.Services;

public class ProjectService : IProjectService
{
    public Task<ProjectResponseDTO> Insert(ProjectRequestDTO projectRequestDto)
    {
        return null;
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