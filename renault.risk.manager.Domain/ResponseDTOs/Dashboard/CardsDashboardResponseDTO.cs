namespace renault.risk.manager.Domain.ResponseDTOs.Dashboard;

public record CardsDashboardResponseDTO
(
    int TotalRisks,
    int WeeklyRisks,
    int UserRisks,
    string JalonMostAffected,
    string MetierMostAffected
);