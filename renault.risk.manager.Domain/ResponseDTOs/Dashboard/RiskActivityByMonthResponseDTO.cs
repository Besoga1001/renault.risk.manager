namespace renault.risk.manager.Domain.ResponseDTOs.Dashboard;

public record RiskActivityByMonthResponseDTO(
    string Month, int ResolvedRisks, int NoResolvedRisks
    );