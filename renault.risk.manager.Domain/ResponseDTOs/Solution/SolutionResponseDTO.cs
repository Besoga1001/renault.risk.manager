namespace renault.risk.manager.Domain.ResponseDTOs.Solution;

public record SolutionResponseDTO
(
    int Id,
    string Strategy,
    string ResidualProbability,
    string ResidualImpact,
    string ActionValidation,
    string RiskValidation,
    DateTime AlertDate,
    bool Captalization,
    int UserPilotId,
    DateTime StartActionPlanDate,
    string Action,
    string Observation,
    DateTime ResolutionDate,
    int RiskId
);