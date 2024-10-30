using System.ComponentModel;

namespace renault.risk.manager.Domain.Enums;

public enum RiskFieldLevelsEnum
{
    [Description("Muito Baixo")]
    VeryLow = 1,
    [Description("Baixo")]
    Low = 2,
    [Description("Médio")]
    Medium = 3,
    [Description("Alto")]
    High = 4,
    [Description("Muito Alto")]
    VeryHigh = 5
}