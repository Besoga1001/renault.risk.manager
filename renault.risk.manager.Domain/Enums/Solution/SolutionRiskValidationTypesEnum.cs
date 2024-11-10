using System.ComponentModel;

namespace renault.risk.manager.Domain.Enums.Solution;

public enum SolutionRiskValidationTypesEnum
{
    [Description("Em risco")]
    AtRisk = 1,
    [Description("Em trajetória")]
    InTrajectory = 2,
    [Description("Resolvido")]
    Resolved = 3,
    [Description("Problema")]
    Problem = 4
}