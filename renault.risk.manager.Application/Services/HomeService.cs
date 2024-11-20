using renault.risk.manager.Application.Extensions;
using renault.risk.manager.Application.Interfaces.Repositories;
using renault.risk.manager.Application.Interfaces.Services;
using renault.risk.manager.Domain.ResponseDTOs.Home;

namespace renault.risk.manager.Application.Services;

public class HomeService : IHomeService
{
    private readonly IRiskRepository riskRepository;
    private readonly IProjectRepository projectRepository;

    // ReSharper disable once ConvertToPrimaryConstructor
    public HomeService(IRiskRepository riskRepository, IProjectRepository projectRepository)
    {
        this.riskRepository = riskRepository;
        this.projectRepository = projectRepository;
    }

    public async Task<CardsHomeResponseDTO> GetInfoCards()
    {
        var riskEntities = await riskRepository.GetAllAsync();

        return new CardsHomeResponseDTO
        {
            WeeklyRisk = riskEntities.GetWeeklyRisks(),
            ResolvedMonthlyRisks = riskEntities.GetCurrentMonthRisks(true),
            NoResolvedMonthlyRisks = riskEntities.GetCurrentMonthRisks(false),
            TotalCriticalRisks = riskEntities.GetTotalCriticalRisks()
        };
    }

    public async Task<Dictionary<string, int>> GetNumberOfRisksPerProject()
    {
        var riskEntities = await riskRepository.GetAllAsync();

        var projectNames = (await projectRepository.GetAllAsync())
            .ToDictionary(p => p.pjc_id, p => p.pjc_name);

        return riskEntities
            .GroupBy(r => r.rsk_project_id)
            .ToDictionary(
                g => projectNames.GetValueOrDefault(g.Key, "Project Not Found."),
                g => g.Count()
            );
    }


}