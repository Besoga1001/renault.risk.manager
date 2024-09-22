using renault.risk.manager.Domain.RequestDTOs;
using renault.risk.manager.Domain.ResponseDTOs;

namespace renault.risk.manager.Application.Interfaces.Services;

public interface IProjectService
{
    Task<ProjectResponseDTO> Insert(ProjectRequestDTO projectRequestDto);
    IEnumerable<ProjectResponseDTO> GetAll();
    Task<ProjectResponseDTO> GetById(int id);
    string Delete(int id);

}