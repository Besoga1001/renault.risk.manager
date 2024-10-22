using renault.risk.manager.Domain.RequestDTOs;
using renault.risk.manager.Domain.ResponseDTOs;

namespace renault.risk.manager.Application.Interfaces.Services;

public interface IRiskService
{
    Task<RiskResponseDTO> InsertAsync(RiskRequestDTO riskRequestDto);
    Task<RiskResponseDTO> UpdateAsync(RiskRequestDTO riskRequestDto);
    Task<List<RiskResponseDTO>> GetAllAsync();
    Task<RiskResponseDTO> GetByIdAsync(int riskId);
}