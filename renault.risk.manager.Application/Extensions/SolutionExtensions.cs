using renault.risk.manager.Application.Helpers;
using renault.risk.manager.Domain.Entities;
using renault.risk.manager.Domain.Enums;
using renault.risk.manager.Domain.Enums.Solution;
using renault.risk.manager.Domain.RequestDTOs.SolutionDTOs;
using renault.risk.manager.Domain.ResponseDTOs;
using renault.risk.manager.Domain.ResponseDTOs.Solution;

namespace renault.risk.manager.Application.Extensions;

public static class SolutionExtensions
{
    public static tb_solution ToEntity(this SolutionInsertRequestDTO solutionRequestDto) => new ()
    {
        sln_risk_id = solutionRequestDto.SlnRiskId,
        sln_strategy = solutionRequestDto.SlnStrategy,
        sln_residual_probability = solutionRequestDto.SlnResidualProbability,
        sln_residual_impact = solutionRequestDto.SlnResidualImpact,
        sln_action_validation = solutionRequestDto.SlnActionValidation,
        sln_risk_validation  = solutionRequestDto.SlnRiskValidation,
        sln_alert_date = solutionRequestDto.SlnAlertDate,
        sln_captalization = solutionRequestDto.SlnCaptalization,
        sln_user_pilot_id = solutionRequestDto.SlnUserPilotId,
        sln_start_action_plan_date = solutionRequestDto.SlnStartActionPlanDate,
        sln_action = solutionRequestDto.SlnAction,
        sln_observation = solutionRequestDto.SlnObservation,
        sln_resolution_date = solutionRequestDto.SlnResolutionDate,
        sln_created_at = DateTime.Now
    };

    public static SolutionResponseDTO ToDto(this tb_solution solutionEntity, string userPilotName) => new
    (
        solutionEntity.sln_id,
        solutionEntity.sln_strategy,
        solutionEntity.sln_residual_probability,
        solutionEntity.sln_residual_impact,
        solutionEntity.sln_action_validation,
        solutionEntity.sln_risk_validation,
        solutionEntity.sln_alert_date,
        solutionEntity.sln_captalization,
        solutionEntity.sln_user_pilot_id,
        userPilotName,
        solutionEntity.sln_start_action_plan_date,
        solutionEntity.sln_action,
        solutionEntity.sln_observation,
        solutionEntity.sln_resolution_date,
        solutionEntity.TbRisk.rsk_id
    );

    public static void Mapper(this tb_solution solutionEntity, SolutionUpdateRequestDTO solutionUpdateRequestDto)
    {
        if (solutionUpdateRequestDto.SlnStrategy != null)
            solutionEntity.sln_strategy = solutionUpdateRequestDto.SlnStrategy;
        if (solutionUpdateRequestDto.SlnResidualProbability != null)
            solutionEntity.sln_residual_probability = solutionUpdateRequestDto.SlnResidualProbability;
        if (solutionUpdateRequestDto.SlnResidualImpact != null)
            solutionEntity.sln_residual_impact = solutionUpdateRequestDto.SlnResidualImpact;
        if (solutionUpdateRequestDto.SlnActionValidation != null)
            solutionEntity.sln_action_validation = solutionUpdateRequestDto.SlnActionValidation;
        if (solutionUpdateRequestDto.SlnRiskValidation != null)
            solutionEntity.sln_risk_validation = solutionUpdateRequestDto.SlnRiskValidation;
        if (solutionUpdateRequestDto.SlnAlertDate != null)
            solutionEntity.sln_alert_date = solutionUpdateRequestDto.SlnAlertDate.Value;
        if (solutionUpdateRequestDto.SlnCaptalization != null)
            solutionEntity.sln_captalization = solutionUpdateRequestDto.SlnCaptalization.Value;
        if (solutionUpdateRequestDto.SlnUserPilotId != null)
            solutionEntity.sln_user_pilot_id = solutionUpdateRequestDto.SlnUserPilotId.Value;
        if (solutionUpdateRequestDto.SlnStartActionPlanDate != null)
            solutionEntity.sln_start_action_plan_date = solutionUpdateRequestDto.SlnStartActionPlanDate.Value;
        if (solutionUpdateRequestDto.SlnAction != null)
            solutionEntity.sln_action = solutionUpdateRequestDto.SlnAction;
        if (solutionUpdateRequestDto.SlnObservation != null)
            solutionEntity.sln_observation = solutionUpdateRequestDto.SlnObservation;
        if (solutionUpdateRequestDto.SlnResolutionDate != null)
            solutionEntity.sln_resolution_date = solutionUpdateRequestDto.SlnResolutionDate.Value;
        solutionEntity.sln_updated_at = DateTime.Now;
    }

    public static SolutionFieldOptionsResponseDTO GetFieldOptions() => new(
        Enum.GetValues<SolutionStrategiesTypesEnum>()
            .ToDictionary(e => (int)e, e => e.GetDescription()),
        Enum.GetValues<FieldLevelsEnum>()
            .ToDictionary(e => (int)e, e => e.GetDescription()),
        Enum.GetValues<FieldLevelsEnum>()
            .ToDictionary(e => (int)e, e => e.GetDescription()),
        Enum.GetValues<SolutionRiskValidationTypesEnum>()
            .ToDictionary(e => (int)e, e => e.GetDescription())
    );
}