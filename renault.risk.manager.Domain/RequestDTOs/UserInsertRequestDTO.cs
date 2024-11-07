namespace renault.risk.manager.Domain.RequestDTOs;

public record UserInsertRequestDTO(
    string UsrName,
    string UsrEmail,
    List<string> UsrMetiers
);