namespace renault.risk.manager.Domain.ResponseDTOs.Solution;

public record SolutionResponseDTO(
    int SlnId,
    string SlnStrategy,
    string SlnResidualProbability,
    string SlnResidualImpact,
    string SlnActionValidation,
    string SlnRiskValidation,
    DateTime SlnAlertDate,
    bool SlnCaptalization,
    int PilotName,
    string SlnUserPilotName,
    DateTime SlnStartActionPlanDate,
    string SlnAction,
    string SlnObservation,
    DateTime SlnResolutionDate,
    int RskId
);