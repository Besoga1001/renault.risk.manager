using System.ComponentModel;

namespace renault.risk.manager.Domain.Enums.Solution;

public enum SolutionStrategiesTypesEnum
{
    [Description("Evitar")]
    Avoid = 1,
    [Description("Mitigar")]
    Mitigate = 2,
    [Description("Transferir")]
    Transfer = 3,
    [Description("Aceitar")]
    Accept = 4
}