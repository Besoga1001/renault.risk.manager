using renault.risk.manager.Domain.Enums;

namespace renault.risk.manager.Domain.RequestDTOs;

public record ProjectRequestDTO(int id, string name, string imgPath,
    IEnumerable<JalonsEnum> jalons, IEnumerable<MetiersEnum> metiers);