using renault.risk.manager.Domain.ResponseDTOs.Home;
using renault.risk.manager.Domain.ResponseDTOs.Risk;

namespace renault.risk.manager.Application.Interfaces.Services;

public interface IHomeService
{
    Task<List<RiskResponseDTO>> GetRisksByUserMetier();
    Task<CardsHomeResponseDTO> GetInfoCards();
    Task<Dictionary<string, int>> GetNumberOfRisksPerProject();
}