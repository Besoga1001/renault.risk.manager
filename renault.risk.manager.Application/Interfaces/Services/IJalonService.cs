using renault.risk.manager.Domain.RequestDTOs;
using renault.risk.manager.Domain.ResponseDTOs;

namespace renault.risk.manager.Application.Interfaces.Services;

public interface IJalonService
{
    Task<JalonResponseDTO> Insert(JalonRequestDTO jalonRequestDto);
    Task<JalonResponseDTO> GetByIdAsync(int jalonId);
    Task<List<JalonResponseDTO>> GetAllAsync(string? jalonName);
    Task<string> Delete(int jalonId);
}