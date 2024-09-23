namespace renault.risk.manager.Domain.RequestDTOs;

public record ProjectRequestDTO(
    string name,
    string imgPath,
    List<int> jalons,
    List<int> metiers
);