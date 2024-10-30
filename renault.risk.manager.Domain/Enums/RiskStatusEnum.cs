using System.ComponentModel;

namespace renault.risk.manager.Domain.Enums;

public enum RiskStatusEnum
{
    [Description("Open")]
    Open = 1,
    [Description("Inactive")]
    Inactive = 2,
    [Description("Solved")]
    Solved = 3
}