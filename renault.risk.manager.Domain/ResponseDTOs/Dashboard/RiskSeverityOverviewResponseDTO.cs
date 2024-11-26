namespace renault.risk.manager.Domain.ResponseDTOs.Dashboard;

public record RiskSeverityOverviewResponseDTO(
    int TotalRisks,
    int LowImpactRisks,
    int CriticalRisks
    );