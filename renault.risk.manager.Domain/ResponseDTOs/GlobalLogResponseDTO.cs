namespace renault.risk.manager.Domain.ResponseDTOs;

public record GlobalLogResponseDTO(
    int LogId,
    string LogEntityName,
    string LogFieldName,
    string LogOldValue,
    string LogNewValue,
    string LogUserEmail,
    DateTime LogDateTime);