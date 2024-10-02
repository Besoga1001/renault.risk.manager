using renault.risk.manager.Domain.RequestDTOs;
using renault.risk.manager.Domain.ResponseDTOs;

namespace renault.risk.manager.Application.Interfaces.Services;

public interface IProjectService
{
    Task<ProjectResponseDTO> Insert(ProjectRequestDTO projectRequestDto);
    Task<List<ProjectResponseDTO>> GetAllAsync(string? name);
    Task<ProjectResponseDTO> GetByIdAsync(int id);
    string Delete(int id);

}