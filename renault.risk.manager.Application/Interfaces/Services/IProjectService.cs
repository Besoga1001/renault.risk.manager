using renault.risk.manager.Domain.RequestDTOs;
using renault.risk.manager.Domain.ResponseDTOs;

namespace renault.risk.manager.Application.Interfaces;

public interface IProjectService
{
    Task<ProjectResponseDTO> Insert(ProjectRequestDTO projectRequestDto);
    Task<IEnumerable<ProjectResponseDTO>> GetAll();
    bool Delete(int id);

}