using renault.risk.manager.Domain.RequestDTOs;
using renault.risk.manager.Domain.ResponseDTOs;

namespace renault.risk.manager.Application.Interfaces.Services;

public interface IMetierService
{
    Task<MetierResponseDTO> Insert(MetierRequestDTO metierRequestDto);
    Task<MetierResponseDTO> GetByIdAsync(int metierId);
    Task<List<MetierResponseDTO>> GetAllAsync(string? metierDescription);
    Task<string> Delete(int metierId);
}