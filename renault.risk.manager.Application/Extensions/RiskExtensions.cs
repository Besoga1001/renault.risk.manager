using renault.risk.manager.Application.Helpers;
using renault.risk.manager.Domain.Entities;
using renault.risk.manager.Domain.Enums;
using renault.risk.manager.Domain.Enums.Risk;
using renault.risk.manager.Domain.RequestDTOs;
using renault.risk.manager.Domain.RequestDTOs.RiskDTOs;
using renault.risk.manager.Domain.ResponseDTOs;
using renault.risk.manager.Domain.ResponseDTOs.Risk;

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
        rsk_jalon_id = riskInsertRequestDto.Jalon,
        rsk_metier_id = riskInsertRequestDto.Metier,
        rsk_status = RiskStatusEnum.Open,
        rsk_created_at = DateTime.Now,
        rsk_usr_id = riskInsertRequestDto.UserId
    };

    public static RiskResponseDTO ToDto(this tb_risk riskEntity) => new
    (
        riskEntity.rsk_id,
        riskEntity.rsk_description,
        riskEntity.rsk_type.GetDescription(),
        riskEntity.rsk_probability.GetDescription(),
        riskEntity.rsk_responsible_area.GetDescription(),
        riskEntity.rsk_classification.GetDescription(),
        riskEntity.rsk_project_id,
        riskEntity.TbProject.pjc_name,
        riskEntity.rsk_alert_date,
        riskEntity.rsk_impact.GetDescription(),
        riskEntity.rsk_plant.GetDescription(),
        riskEntity.rsk_consequence,
        riskEntity.TbJalon.jal_description,
        riskEntity.TbMetier.met_description,
        riskEntity.rsk_status.GetDescription(),
        riskEntity.TbSolution?.sln_id ?? 0,
        riskEntity.rsk_usr_id,
        riskEntity.rsk_created_at,
        riskEntity.rsk_updated_at
    );

    public static void Mapper(this tb_risk riskEntity, RiskUpdateRequestDTO riskUpdateRequestDto)
    {
        if (riskUpdateRequestDto.Description != null)
            riskEntity.rsk_description = riskUpdateRequestDto.Description;
        if (riskUpdateRequestDto.Type != null)
            riskEntity.rsk_type = riskUpdateRequestDto.Type.Value;
        if (riskUpdateRequestDto.Probability != null)
            riskEntity.rsk_probability = riskUpdateRequestDto.Probability.Value;
        if (riskUpdateRequestDto.ResponsibleArea != null)
            riskEntity.rsk_responsible_area = riskUpdateRequestDto.ResponsibleArea.Value;
        if (riskUpdateRequestDto.Classification != null)
            riskEntity.rsk_classification = riskUpdateRequestDto.Classification.Value;
        if (riskUpdateRequestDto.ProjectId != null)
            riskEntity.rsk_project_id = riskUpdateRequestDto.ProjectId.Value;
        if (riskUpdateRequestDto.AlertDate != null)
            riskEntity.rsk_alert_date = riskUpdateRequestDto.AlertDate.Value;
        if (riskUpdateRequestDto.Impact != null)
            riskEntity.rsk_impact = riskUpdateRequestDto.Impact.Value;
        if (riskUpdateRequestDto.Plant != null)
            riskEntity.rsk_plant = riskUpdateRequestDto.Plant.Value;
        if (riskUpdateRequestDto.Consequence != null)
            riskEntity.rsk_consequence = riskUpdateRequestDto.Consequence;
        if (riskUpdateRequestDto.Jalon != null)
            riskEntity.rsk_jalon_id = riskUpdateRequestDto.Jalon.Value;
        if (riskUpdateRequestDto.Metier != null)
            riskEntity.rsk_metier_id = riskUpdateRequestDto.Metier.Value;
        if (riskUpdateRequestDto.Status != null)
            riskEntity.rsk_status = riskUpdateRequestDto.Status.Value;
        if (riskUpdateRequestDto.UserId != null)
            riskEntity.rsk_usr_id = riskUpdateRequestDto.UserId.Value;
        riskEntity.rsk_updated_at = DateTime.Now;
    }

    public static RiskFieldOptionsResponseDTO GetFieldOptions(List<tb_project> projectEntities,
        List<tb_jalon> jalonEntities, List<tb_metier> metierEntities) => new
    (
        Enum.GetValues<RiskTypesEnum>()
            .ToDictionary(e => (int)e, e => e.GetDescription()),

        Enum.GetValues<FieldLevelsEnum>()
            .ToDictionary(e => (int)e, e => e.GetDescription()),

        Enum.GetValues<RiskResponsibleAreasEnum>()
            .ToDictionary(e => (int)e, e => e.GetDescription()),

        Enum.GetValues<RiskClassificationLevelsEnum>()
            .ToDictionary(e => (int)e, e => e.GetDescription()),

        Enum.GetValues<FieldLevelsEnum>()
            .ToDictionary(e => (int)e, e => e.GetDescription()),

        Enum.GetValues<RiskPlantsEnum>()
            .ToDictionary(e => (int)e, e => e.GetDescription()),

        projectEntities.Where(p => p.pjc_status == true)
            .ToDictionary(p => p.pjc_id, p => p.pjc_name),

        metierEntities.ToDictionary(m => m.met_id, m => m.met_description),

        jalonEntities.ToDictionary(j => j.jal_id, j => j.jal_description),

        Enum.GetValues<RiskStatusEnum>()
            .ToDictionary(e => (int)e, e => e.GetDescription()));

    public static int GetWeeklyRisks(this List<tb_risk> riskEntities)
    {
        var firstWeekDay = DateTime.Now.Date.AddDays(-(int)DateTime.Now.DayOfWeek);
        var lastWeekDay = firstWeekDay.AddDays(6);
        return riskEntities.Count(y => y.rsk_alert_date >= firstWeekDay && y.rsk_alert_date <= lastWeekDay);
    }

    public static int GetByMonthRisks(this List<tb_risk> riskEntities, DateTime monthDate, bool isResolved)
    {
        var firstMonthDay = new DateTime(DateTime.Now.Year, monthDate.Month, 1);
        var lastMonthDay = firstMonthDay.AddMonths(1).AddDays(-1);

        return riskEntities
            .Count(y =>
                (isResolved ? y.rsk_status == RiskStatusEnum.Solved : y.rsk_status != RiskStatusEnum.Solved) &&
                y.rsk_alert_date >= firstMonthDay && y.rsk_alert_date <= lastMonthDay);
    }

    public static int GetCurrentMonthRisks(this List<tb_risk> riskEntities, bool isResolved)
    {
        var firstMonthDay = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1);
        var lastMonthDay = firstMonthDay.AddMonths(1).AddDays(-1);

        return riskEntities
            .Count(y =>
                (isResolved ? y.rsk_status == RiskStatusEnum.Solved : y.rsk_status != RiskStatusEnum.Solved) &&
                y.rsk_alert_date >= firstMonthDay && y.rsk_alert_date <= lastMonthDay);
    }

    public static int GetTotalCriticalRisks(this List<tb_risk> riskEntities)
        => riskEntities.Count(y => y.rsk_classification == RiskClassificationLevelsEnum.K1);

    public static int GetTotalLowImpactRisks(this List<tb_risk> riskEntities)
        => riskEntities.Count(y => y.rsk_classification == RiskClassificationLevelsEnum.K4);

    public static int GetRisksByUser(this List<tb_risk> riskEntities, int? userId)
        => riskEntities.Count(y => y.rsk_usr_id == userId);

    public static int GetMostAffectedJalonId(this List<tb_risk> riskEntities)
        => riskEntities
            .GroupBy(r => r.rsk_jalon_id)
            .OrderByDescending(g => g.Count())
            .Select(g => g.Key)
            .FirstOrDefault();

    public static int GetMostAffectedMetierId(this List<tb_risk> riskEntities)
        => riskEntities
            .GroupBy(r => r.rsk_metier_id)
            .OrderByDescending(g => g.Count())
            .Select(g => g.Key)
            .FirstOrDefault();

    public static Dictionary<string, int> GetRisksPerProjects(this List<tb_risk> riskEntities)
        => riskEntities
            .OrderBy(r => r.TbProject.pjc_id)
            .GroupBy(r => r.TbProject.pjc_name)
            .ToDictionary(g => g.Key, g => g.Count());

    public static Dictionary<string, int> GetRisksPerType(this List<tb_risk> riskEntities)
        => riskEntities
            .OrderBy(r => r.rsk_type)
            .GroupBy(r => r.rsk_type)
            .ToDictionary(g => g.Key.GetDescription(), g => g.Count());
}