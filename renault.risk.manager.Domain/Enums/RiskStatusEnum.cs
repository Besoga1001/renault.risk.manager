using System.ComponentModel;

namespace renault.risk.manager.Domain.Enums;

public enum RiskStatusEnum
{
    [Description("Active")]
    Active = 0,
    [Description("Inactive")]
    Inactive = 1,
    [Description("Solved")]
    Solved = 2
}