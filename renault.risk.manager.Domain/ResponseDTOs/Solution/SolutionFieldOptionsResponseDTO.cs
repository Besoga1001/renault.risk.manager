namespace renault.risk.manager.Domain.ResponseDTOs.Solution;

public record SolutionFieldOptionsResponseDTO
(
    Dictionary<int, string> SlnStrategy,
    Dictionary<int, string> SlnResidualProbability,
    Dictionary<int, string> SlnResidualImpact,
    Dictionary<int, string> SlnRiskValidation
);