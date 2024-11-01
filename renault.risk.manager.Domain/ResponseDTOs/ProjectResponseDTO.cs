using renault.risk.manager.Domain.Enums;

namespace renault.risk.manager.Domain.ResponseDTOs;

public record ProjectResponseDTO(
    int id,
    string name,
    string imgPath
    // IEnumerable<JalonsEnum> jalons,
    // IEnumerable<MetiersEnum> metiers
);