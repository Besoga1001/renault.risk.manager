using renault.risk.manager.Domain.Entities;
using renault.risk.manager.Domain.Enums;

namespace renault.risk.manager.Application.Extensions;

public static class HomeExtensions
{
    public static int GetWeeklyRisks(this List<tb_risk> riskEntities, DateTime firstWeekDay, DateTime lastWeekDay)
    {
        return riskEntities.Count(y => y.rsk_alert_date >= firstWeekDay && y.rsk_alert_date <= lastWeekDay);
    }

    public static int GetMonthRisks(this List<tb_risk> riskEntities, bool isResolved,
        DateTime firstMonthDay, DateTime lastMonthDay)
    {
        return riskEntities
            .Count(y =>
                (isResolved ? y.rsk_status == RiskStatusEnum.Solved : y.rsk_status != RiskStatusEnum.Solved) &&
                    y.rsk_alert_date >= firstMonthDay && y.rsk_alert_date <= lastMonthDay);
    }

    public static int GetTotalCriticalRisks(this List<tb_risk> riskEntities)
    {
        return riskEntities.Count(y => y.rsk_classification == RiskClassificationLevelsEnum.K1);
    }


}