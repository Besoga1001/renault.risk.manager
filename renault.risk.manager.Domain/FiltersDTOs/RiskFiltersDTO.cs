using renault.risk.manager.Domain.Enums;

namespace renault.risk.manager.Domain.FiltersDTOs;

public record RiskFiltersDTO(
    int? ProjectId,
    string? Description,
    RiskFieldLevelsEnum? ImpactId,
    MetiersEnum? MetierId,
    JalonsEnum? JalonId,
    RiskStatusEnum? StatusId,
    bool? IsCaptalization
    );