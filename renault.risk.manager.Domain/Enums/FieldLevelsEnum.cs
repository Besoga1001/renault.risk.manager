using System.ComponentModel;

namespace renault.risk.manager.Domain.Enums;

public enum FieldLevelsEnum
{
    [Description("Desconhecido")]
    Unknow = 6,
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