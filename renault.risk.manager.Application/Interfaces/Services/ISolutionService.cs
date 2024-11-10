using renault.risk.manager.Domain.RequestDTOs.SolutionDTOs;
using renault.risk.manager.Domain.ResponseDTOs;
using renault.risk.manager.Domain.ResponseDTOs.Solution;

namespace renault.risk.manager.Application.Interfaces.Services;

public interface ISolutionService
{
    Task<SolutionResponseDTO> InsertAsync(SolutionInsertRequestDTO solutionInsertRequestDto);
    Task<SolutionResponseDTO> UpdateAsync(int solutionId, SolutionUpdateRequestDTO solutionUpdateRequestDto);
    Task<List<SolutionResponseDTO>> GetAllAsync();
    Task<SolutionResponseDTO> GetByIdAsync(int solutionId);
    SolutionFieldOptionsResponseDTO GetFieldOptions();
}