using System.ComponentModel;

namespace renault.risk.manager.Domain.Enums;

public enum RiskResponsibleAreasEnum
{
    [Description("APO")]
    Apo = 1,
    [Description("DE-VB")]
    DeVb = 2,
    [Description("DEA-TD")]
    DeaTd = 3
}