using renault.risk.manager.Domain.ResponseDTOs.Home;

namespace renault.risk.manager.Application.Interfaces.Services;

public interface IHomeService
{
    Task<CardsHomeResponseDTO> GetInfoCards();
    Task<Dictionary<string, int>> GetNumberOfRisksPerProject();
}