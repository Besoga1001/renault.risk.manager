using System.ComponentModel;

namespace renault.risk.manager.Domain.Enums;

public enum RiskTypesEnum
{
    [Description("Desconhecido")]
    Unknow = 0,
    [Description("Conformidade")]
    Conformity = 1,
    [Description("Recursos Humanos")]
    HumanResources = 2,
    [Description("Operacional")]
    Operational = 3,
    [Description("Estratégico")]
    Strategic = 4
}