using renault.risk.manager.Domain.Enums;

namespace renault.risk.manager.Domain.ResponseDTOs;

public record ProjectResponseDTO(
    int Id,
    string Name,
    string ImgPath,
    IDictionary<int, string> Jalons
    // IEnumerable<MetiersEnum> metiers
);