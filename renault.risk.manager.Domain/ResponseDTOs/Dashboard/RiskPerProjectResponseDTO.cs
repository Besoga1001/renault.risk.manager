namespace renault.risk.manager.Domain.ResponseDTOs.Dashboard;

public record RiskPerProjectResponseDTO(
        Dictionary<string, int> RiskPerProject
    );