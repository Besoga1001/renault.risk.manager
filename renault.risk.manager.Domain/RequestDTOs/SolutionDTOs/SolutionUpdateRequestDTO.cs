using renault.risk.manager.Domain.Enums;
using renault.risk.manager.Domain.Enums.Solution;

namespace renault.risk.manager.Domain.RequestDTOs.SolutionDTOs;

public record SolutionUpdateRequestDTO
    (
        SolutionStrategiesTypesEnum? SlnStrategy,
        FieldLevelsEnum? SlnResidualProbability,
        FieldLevelsEnum? SlnResidualImpact,
        FieldLevelsEnum? SlnActionValidation,
        SolutionRiskValidationTypesEnum? SlnRiskValidation,
        DateTime? SlnAlertDate,
        bool? SlnCaptalization,
        int? SlnUserPilotId,
        DateTime? SlnStartActionPlanDate,
        string? SlnAction,
        string? SlnObservation,
        DateTime? SlnResolutionDate
    );