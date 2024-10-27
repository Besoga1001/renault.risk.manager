using renault.risk.manager.Domain.Entities;
using renault.risk.manager.Domain.RequestDTOs;
using renault.risk.manager.Domain.ResponseDTOs;

namespace renault.risk.manager.Application.Extensions;

public static class RiskExtensions
{
    public static tb_risk ToEntity(this RiskInsertRequestDTO riskInsertRequestDto) => new ()
    {
        rsk_description = riskInsertRequestDto.Description,
        rsk_type = riskInsertRequestDto.Type,
        rsk_probability = riskInsertRequestDto.Probability,
        rsk_responsible_area = riskInsertRequestDto.ResponsibleArea,
        rsk_classification = riskInsertRequestDto.Classification,
        rsk_project_id = riskInsertRequestDto.ProjectId,
        rsk_alert_date = riskInsertRequestDto.AlertDate,
        rsk_impact = riskInsertRequestDto.Impact,
        rsk_plant = riskInsertRequestDto.Plant,
        rsk_consequence = riskInsertRequestDto.Consequence,
        rsk_jalon = riskInsertRequestDto.Jalon,
        rsk_metier = riskInsertRequestDto.Metier,
        rsk_created_at = DateTime.Now,
        rsk_usr_id = riskInsertRequestDto.UserId
    };

    public static RiskResponseDTO ToDto(this tb_risk riskEntity) => new ()
    {
        Id = riskEntity.rsk_id,
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
        SolutionId = riskEntity.TbSolution?.sln_id ?? 0,
        UserId = riskEntity.rsk_usr_id
    };

    public static void Mapper(this tb_risk riskEntity, RiskUpdateRequestDTO riskUpdateRequestDto)
    {
        if (riskUpdateRequestDto.Description != null) riskEntity.rsk_description = riskUpdateRequestDto.Description;
        if (riskUpdateRequestDto.Type != null) riskEntity.rsk_type = riskUpdateRequestDto.Type;
        if (riskUpdateRequestDto.Probability != null) riskEntity.rsk_probability = riskUpdateRequestDto.Probability;
        if (riskUpdateRequestDto.ResponsibleArea != null) riskEntity.rsk_responsible_area = riskUpdateRequestDto.ResponsibleArea;
        if (riskUpdateRequestDto.Classification != null) riskEntity.rsk_classification = riskUpdateRequestDto.Classification;
        if (riskUpdateRequestDto.ProjectId != null) riskEntity.rsk_project_id = riskUpdateRequestDto.ProjectId.Value;
        if (riskUpdateRequestDto.AlertDate != null) riskEntity.rsk_alert_date = riskUpdateRequestDto.AlertDate.Value;
        if (riskUpdateRequestDto.Impact != null) riskEntity.rsk_impact = riskUpdateRequestDto.Impact;
        if (riskUpdateRequestDto.Plant != null) riskEntity.rsk_plant = riskUpdateRequestDto.Plant;
        if (riskUpdateRequestDto.Consequence != null) riskEntity.rsk_consequence = riskUpdateRequestDto.Consequence;
        if (riskUpdateRequestDto.Jalon != null) riskEntity.rsk_jalon = riskUpdateRequestDto.Jalon;
        if (riskUpdateRequestDto.Metier != null) riskEntity.rsk_metier = riskUpdateRequestDto.Metier;
        if (riskUpdateRequestDto.UserId != null) riskEntity.rsk_usr_id = riskUpdateRequestDto.UserId.Value;
        riskEntity.rsk_updated_at = DateTime.Now;
    }
}