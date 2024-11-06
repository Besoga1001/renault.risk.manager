using renault.risk.manager.Domain.FiltersDTOs;
using renault.risk.manager.Domain.RequestDTOs;
using renault.risk.manager.Domain.RequestDTOs.RiskDTOs;
using renault.risk.manager.Domain.ResponseDTOs;
using renault.risk.manager.Domain.ResponseDTOs.Risk;

namespace renault.risk.manager.Application.Interfaces.Services;

public interface IRiskService
{
    Task<RiskResponseDTO> InsertAsync(RiskInsertRequestDTO riskInsertRequestDto);
    Task InsertRangeAsync(List<RiskInsertRequestDTO> riskInsertRequestDtos);
    Task<RiskResponseDTO> UpdateAsync(int riskId, RiskUpdateRequestDTO riskUpdateRequestDto);
    Task<List<RiskResponseDTO>> GetAllAsync(RiskFiltersDTO riskFiltersDto);
    Task<RiskResponseDTO> GetByIdAsync(int riskId);
    RiskFieldOptionsResponseDTO GetFieldOptions(); //Enums
}