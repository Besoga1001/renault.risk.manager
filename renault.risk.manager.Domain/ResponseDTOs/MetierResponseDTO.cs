namespace renault.risk.manager.Domain.ResponseDTOs;

public record MetierResponseDTO(
    int MetId,
    string MetDescription,
    bool MetStatus,
    DateTime MetCreatedAt,
    DateTime MetUpdatedAt
);