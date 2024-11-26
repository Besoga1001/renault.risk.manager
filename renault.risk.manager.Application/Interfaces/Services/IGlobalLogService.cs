using renault.risk.manager.Domain.ResponseDTOs;

namespace renault.risk.manager.Application.Interfaces.Services;

public interface IGlobalLogService
{
    Task<List<GlobalLogResponseDTO>> GetAllAsync(string? filterLogOptionsEnum);
    Task<List<GlobalLogResponseDTO>> GetBySolutionAsync();
    Dictionary<int, string> GetFieldOptions();
}