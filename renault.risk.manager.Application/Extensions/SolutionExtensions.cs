using renault.risk.manager.Domain.Entities;
using renault.risk.manager.Domain.RequestDTOs;
using renault.risk.manager.Domain.ResponseDTOs;

namespace renault.risk.manager.Application.Extensions;

public static class SolutionExtensions
{
    public static tb_solution toEntity(this SolutionRequestDTO solutionRequestDto) => new ()
    {
        sln_strategy = solutionRequestDto.Strategy,
        sln_residual_probability = solutionRequestDto.ResidualProbability,
        sln_residual_impact = solutionRequestDto.ResidualImpact,
        sln_action_validation = solutionRequestDto.ActionValidation,
        sln_risk_validation  = solutionRequestDto.RiskValidation,
        sln_alert_date = solutionRequestDto.AlertDate,
        sln_captalization = solutionRequestDto.Captalization,
        sln_user_pilot_id = solutionRequestDto.UserPilotId,
        sln_start_action_plan_date = solutionRequestDto.StartActionPlanDate,
        sln_action = solutionRequestDto.Action,
        sln_observation = solutionRequestDto.Observation,
        sln_resolution_date = solutionRequestDto.ResolutionDate,
        sln_created_at = DateTime.Now,
        sln_risk_id = solutionRequestDto.RiskId
    };

    public static SolutionResponseDTO toDto(this tb_solution solutionEntity) => new ()
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
}