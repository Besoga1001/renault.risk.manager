namespace renault.risk.manager.Domain.ResponseDTOs;

public record ProjectResponseDTO(
    int PjcId,
    string PjcName,
    string PjcImgPath,
    bool PjcStatus,
    IDictionary<int, string> PjcJalons
    // IEnumerable<MetiersEnum> metiers
);