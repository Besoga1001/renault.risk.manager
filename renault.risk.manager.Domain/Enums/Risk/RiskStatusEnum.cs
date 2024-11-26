using System.ComponentModel;

namespace renault.risk.manager.Domain.Enums.Risk;

public enum RiskStatusEnum
{
    [Description("Em Aberto")]
    Open = 1,
    [Description("Inativo")]
    Inactive = 2,
    [Description("Resolvido")]
    Solved = 3
}