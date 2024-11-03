namespace renault.risk.manager.Domain.ResponseDTOs;

public record JalonResponseDTO(
    int JalId,
    string JalDescription,
    bool JalStatus,
    DateTime JalCreatedAt,
    DateTime JalUpdatedAt
);