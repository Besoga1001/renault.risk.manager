using renault.risk.manager.Domain.Enums;

namespace renault.risk.manager.Domain.FiltersDTOs;

public record RiskFiltersDTO(
    string? ProjectIds,
    string? Description,
    string? ImpactIds,
    string? MetierIds,
    string? JalonIds,
    string? StatusIds,
    bool? IsCaptalization
    );