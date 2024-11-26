using renault.risk.manager.Domain.ResponseDTOs.Dashboard;

namespace renault.risk.manager.Application.Interfaces.Services;

public interface IDashboardService
{
    Task<CardsDashboardResponseDTO> GetInfoCards();
    Task<RiskPerProjectResponseDTO> GetRiskPerProject();
    Task<RiskSeverityOverviewResponseDTO> GetRiskSeverityOverview();
    Task<RiskTypeOverviewResponseDTO> GetRiskTypeOverview();
    Task<List<RiskActivityByMonthResponseDTO>> GetRiskActivityByMonth();
}