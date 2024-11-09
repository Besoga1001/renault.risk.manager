namespace renault.risk.manager.Domain.RequestDTOs.SolutionDTOs;

public record SolutionInsertRequestDTO
    (
        string SlnStrategy,
        string SlnResidualProbability,
        string SlnResidualImpact,
        string SlnActionValidation,
        string SlnRiskValidation,
        DateTime SlnAlertDate,
        bool SlnCaptalization,
        int SlnUserPilotId,
        DateTime SlnStartActionPlanDate,
        string SlnAction,
        string SlnObservation,
        DateTime SlnResolutionDate,
        int SlnRiskId
    );