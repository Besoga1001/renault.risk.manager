using renault.risk.manager.Domain.Enums;

namespace renault.risk.manager.Domain.RequestDTOs;

public record ProjectRequestDTO(
    string name,
    string imgPath,
    IEnumerable<int> jalons,
    IEnumerable<int> metiers
);