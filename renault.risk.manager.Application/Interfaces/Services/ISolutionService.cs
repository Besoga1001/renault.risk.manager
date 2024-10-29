using renault.risk.manager.Domain.RequestDTOs;
using renault.risk.manager.Domain.ResponseDTOs;

namespace renault.risk.manager.Application.Interfaces.Services;

public interface ISolutionService
{
    Task<SolutionResponseDTO> InsertAsync(SolutionRequestDTO solutionRequestDto);
    Task<SolutionResponseDTO> UpdateAsync(SolutionRequestDTO solutionRequestDto);
    Task<List<SolutionResponseDTO>> GetAllAsync();
    Task<SolutionResponseDTO> GetByIdAsync(int solutionId);
}