using System.ComponentModel;

namespace renault.risk.manager.Domain.Enums.Risk;

public enum RiskClassificationLevelsEnum
{
    [Description("Desconhecido")]
    Unknow = 0,
    [Description("Crítico")]
    K1 = 1,
    [Description("Severo")]
    K2 = 2,
    [Description("Moderado")]
    K3 = 3,
    [Description("Sustentável")]
    K4 = 4
}