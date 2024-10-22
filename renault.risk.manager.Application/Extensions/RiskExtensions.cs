using renault.risk.manager.Domain.Entities;
using renault.risk.manager.Domain.RequestDTOs;
using renault.risk.manager.Domain.ResponseDTOs;

namespace renault.risk.manager.Application.Extensions;

public static class RiskExtensions
{
    public static tb_risk toEntity(this RiskRequestDTO riskRequestDto) => new tb_risk
    {
        rsk_description = riskRequestDto.Description,
        rsk_type = riskRequestDto.Type,
        rsk_probability = riskRequestDto.Probability,
        rsk_responsible_area = riskRequestDto.ResponsibleArea,
        rsk_classification = riskRequestDto.Classification,
        rsk_project_id = riskRequestDto.ProjectId,
        rsk_alert_date = riskRequestDto.AlertDate,
        rsk_impact = riskRequestDto.Impact,
        rsk_plant = riskRequestDto.Plant,
        rsk_consequence = riskRequestDto.Consequence,
        rsk_jalon = riskRequestDto.Jalon,
        rsk_metier = riskRequestDto.Metier,
        rsk_created_at = DateTime.Now,
        rsk_solution_id = riskRequestDto.SolutionId,
        rsk_usr_id = riskRequestDto.UserId
    };

    public static RiskResponseDTO toDto(this tb_risk riskEntity) => new RiskResponseDTO
    {
        Description = riskEntity.rsk_description,
        Type = riskEntity.rsk_type,
        Probability = riskEntity.rsk_probability,
        ResponsibleArea = riskEntity.rsk_responsible_area,
        Classification = riskEntity.rsk_classification,
        ProjectId = riskEntity.rsk_project_id,
        AlertDate = riskEntity.rsk_alert_date,
        Impact = riskEntity.rsk_impact,
        Plant = riskEntity.rsk_plant,
        Consequence = riskEntity.rsk_consequence,
        Jalon = riskEntity.rsk_jalon,
        Metier = riskEntity.rsk_metier,
        CreatedAt = riskEntity.rsk_created_at,
        UpdatedAt = riskEntity.rsk_updated_at,
        SolutionId = riskEntity.rsk_solution_id,
        UserId = riskEntity.rsk_usr_id
    };
}