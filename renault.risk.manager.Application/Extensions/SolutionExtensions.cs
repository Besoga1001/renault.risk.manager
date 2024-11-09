using renault.risk.manager.Domain.Entities;
using renault.risk.manager.Domain.RequestDTOs.SolutionDTOs;
using renault.risk.manager.Domain.ResponseDTOs;

namespace renault.risk.manager.Application.Extensions;

public static class SolutionExtensions
{
    public static tb_solution ToEntity(this SolutionInsertRequestDTO solutionRequestDto) => new ()
    {
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
        sln_risk_id = solutionRequestDto.SlnRiskId,
        sln_created_at = DateTime.Now
    };

    public static SolutionResponseDTO ToDto(this tb_solution solutionEntity) => new ()
    {
        Id = solutionEntity.sln_id,
        Strategy = solutionEntity.sln_strategy,
        ResidualProbability = solutionEntity.sln_residual_probability,
        ResidualImpact = solutionEntity.sln_residual_impact,
        ActionValidation = solutionEntity.sln_action_validation,
        RiskValidation = solutionEntity.sln_risk_validation,
        AlertDate = solutionEntity.sln_alert_date,
        Captalization = solutionEntity.sln_captalization,
        UserPilotId = solutionEntity.sln_user_pilot_id,
        StartActionPlanDate = solutionEntity.sln_start_action_plan_date,
        Action = solutionEntity.sln_action,
        Observation = solutionEntity.sln_observation,
        ResolutionDate = solutionEntity.sln_resolution_date
    };

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
}