using renault.risk.manager.Application.Extensions;
using renault.risk.manager.Application.Helpers;
using renault.risk.manager.Application.Interfaces.Repositories;
using renault.risk.manager.Application.Interfaces.Services;
using renault.risk.manager.Domain.Enums;
using renault.risk.manager.Domain.ResponseDTOs;

namespace renault.risk.manager.Application.Services;

public class GlobalLogService : IGlobalLogService
{
    private readonly IGlobalLogRepository globalLogRepository;

    public GlobalLogService(IGlobalLogRepository globalLogRepository)
    {
        this.globalLogRepository = globalLogRepository;
    }

    public async Task<List<GlobalLogResponseDTO>> GetAllAsync(string? filterLogOptionsEnums)
    {
        var globalLogEntities = await globalLogRepository.GetAllAsync(filterLogOptionsEnums);
        return globalLogEntities.Select(g => g.ToDto()).ToList();
    }

    public async Task<List<GlobalLogResponseDTO>> GetBySolutionAsync()
    {
        const int solutionLogOptionEnumValue = (int)FilterLogOptionsEnum.TbSolution;
        var globalLogEntities =
            await globalLogRepository.GetAllAsync(solutionLogOptionEnumValue.ToString());
        return globalLogEntities.Select(g => g.ToDto()).ToList();
    }

    public Dictionary<int, string> GetFieldOptions()
    {
        return Enum.GetValues<FilterLogOptionsEnum>()
            .ToDictionary(e => (int)e, e => e.GetDisplay());
    }

}