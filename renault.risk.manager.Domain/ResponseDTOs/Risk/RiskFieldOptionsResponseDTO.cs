using renault.risk.manager.Domain.Enums;

namespace renault.risk.manager.Domain.ResponseDTOs.Risk;

public record RiskFieldOptionsResponseDTO(
    Dictionary<int, string> RskType,
    Dictionary<int, string> RskProbability,
    Dictionary<int, string> RskResponsibleArea,
    Dictionary<int, string> RskClassification,
    Dictionary<int, string> RskImpact,
    Dictionary<int, string> RskPlant,
    Dictionary<int, string> RskProject,
    Dictionary<int, string> RskMetier,
    Dictionary<int, string> RskJalon,
    Dictionary<int, string> RskStatus
);
