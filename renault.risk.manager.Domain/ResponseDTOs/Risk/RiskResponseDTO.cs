namespace renault.risk.manager.Domain.ResponseDTOs.Risk;

public record RiskResponseDTO
(
    int RskId,
    string RskDescription,
    string RskType,
    string RskProbability,
    string RskResponsibleArea,
    string RskClassification,
    int RskProjectId,
    string RskProjectDescription,
    DateTime RskAlertDate,
    string RskImpact,
    string RskPlant,
    string RskConsequence,
    string RskJalon,
    string RskMetier,
    string RskStatus,
    int SlnId,
    int UsrId,
    DateTime RskCreatedAt,
    DateTime RskUpdatedAt
);