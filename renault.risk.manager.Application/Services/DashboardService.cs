using System.Globalization;
using renault.risk.manager.Application.Extensions;
using renault.risk.manager.Application.Interfaces.Repositories;
using renault.risk.manager.Application.Interfaces.Services;
using renault.risk.manager.Domain.ResponseDTOs.Dashboard;

namespace renault.risk.manager.Application.Services;

public class DashboardService : IDashboardService
{
    private readonly IRiskRepository riskRepository;
    private readonly IUserRepository userRepository;
    private readonly IJalonRepository jalonRepository;
    private readonly IMetierRepository metierRepository;
    private readonly IClaimsUserService claimsUserService;

    public DashboardService(
        IRiskRepository riskRepository,
        IUserRepository userRepository,
        IJalonRepository jalonRepository,
        IMetierRepository metierRepository,
        IClaimsUserService claimsUserService)
    {
        this.riskRepository= riskRepository;
        this.userRepository = userRepository;
        this.jalonRepository = jalonRepository;
        this.metierRepository = metierRepository;
        this.claimsUserService = claimsUserService;
    }

    public async Task<CardsDashboardResponseDTO> GetInfoCards()
    {
        var riskEntities = await riskRepository.GetAllAsync();
        var currentUserEntity = await userRepository.GetByEmailAsync(claimsUserService.GetCurrentUserEmail());
        var jalonEntity = await jalonRepository.GetByIdAsync(riskEntities.GetMostAffectedJalonId());
        var metierEntity = await metierRepository.GetByIdAsync(riskEntities.GetMostAffectedMetierId());

        return new CardsDashboardResponseDTO(
            riskEntities.Count,
            riskEntities.GetWeeklyRisks(),
            currentUserEntity != null ? riskEntities.GetRisksByUser(currentUserEntity.usr_id) : 0,
            jalonEntity.jal_description,
            metierEntity.met_description
        );
    }

    public async Task<RiskPerProjectResponseDTO> GetRiskPerProject()
    {
        var riskEntities = await riskRepository.GetAllAsync();

        return new RiskPerProjectResponseDTO(riskEntities.GetRisksPerProjects());
    }

    public async Task<RiskSeverityOverviewResponseDTO> GetRiskSeverityOverview()
    {
        var riskEntities = await riskRepository.GetAllAsync();

        return new RiskSeverityOverviewResponseDTO(
            riskEntities.Count,
            riskEntities.GetTotalCriticalRisks(),
            riskEntities.GetTotalLowImpactRisks()
        );
    }

    public async Task<RiskTypeOverviewResponseDTO> GetRiskTypeOverview()
    {
        var riskEntities = await riskRepository.GetAllAsync();

        return new RiskTypeOverviewResponseDTO(riskEntities.GetRisksPerType());
    }

    public async Task<List<RiskActivityByMonthResponseDTO>> GetRiskActivityByMonth()
    {
        var riskEntities = await riskRepository.GetAllAsync();
        var culture = new CultureInfo("pt-BR");
        var riskActivityByMonthResponseDtos = new List<RiskActivityByMonthResponseDTO>();

        for (var i = 0; i <= 5; i++)
        {
            var monthDate = DateTime.Now.AddMonths(-i);
            var monthAbrev = monthDate.ToString("MMMM", culture).ToUpper().Substring(0, 3);
            riskActivityByMonthResponseDtos.Add(new RiskActivityByMonthResponseDTO(
                monthAbrev,
                riskEntities.GetByMonthRisks(monthDate,true),
                riskEntities.GetByMonthRisks(monthDate,false)
            ));
        }
        return riskActivityByMonthResponseDtos;
    }

}