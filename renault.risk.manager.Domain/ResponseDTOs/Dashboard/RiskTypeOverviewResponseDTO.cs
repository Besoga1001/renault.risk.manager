namespace renault.risk.manager.Domain.ResponseDTOs.Dashboard;

public record RiskTypeOverviewResponseDTO(
    Dictionary<string, int> CountRiskPerType
    );