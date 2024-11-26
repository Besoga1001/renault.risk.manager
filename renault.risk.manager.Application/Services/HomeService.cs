using renault.risk.manager.Application.Extensions;
using renault.risk.manager.Application.Interfaces.Repositories;
using renault.risk.manager.Application.Interfaces.Services;
using renault.risk.manager.Domain.Entities;
using renault.risk.manager.Domain.ResponseDTOs.Home;
using renault.risk.manager.Domain.ResponseDTOs.Risk;

namespace renault.risk.manager.Application.Services;

public class HomeService : IHomeService
{
    private readonly IClaimsUserService claimsUserService;
    private readonly IUserRepository userRepository;
    private readonly IRiskRepository riskRepository;
    private readonly IProjectRepository projectRepository;

    // ReSharper disable once ConvertToPrimaryConstructor
    public HomeService(
        IClaimsUserService claimsUserService,
        IUserRepository userRepository,
        IRiskRepository riskRepository,
        IProjectRepository projectRepository)
    {
        this.claimsUserService = claimsUserService;
        this.userRepository = userRepository;
        this.riskRepository = riskRepository;
        this.projectRepository = projectRepository;
    }

    public async Task<List<RiskResponseDTO>> GetRisksByUserMetier()
    {
        var userEntity = await userRepository.GetByEmailAsync(claimsUserService.GetCurrentUserEmail());
        var riskEntities = await riskRepository.GetAllAsync(userEntity?.TbMetiers);
        return riskEntities.Select(r => r.ToDto()).ToList();
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