namespace renault.risk.manager.Domain.RequestDTOs.UserDTOs;

public record UserInsertRequestDTO(
    string UsrName,
    string UsrEmail,
    string UsrPassword,
    List<int> UsrMetiers
);