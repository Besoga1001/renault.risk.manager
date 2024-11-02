using System.Text.Json.Serialization;
using renault.risk.manager.Domain.Entities;
using renault.risk.manager.Domain.Enums;

namespace renault.risk.manager.Domain.RequestDTOs;

public record ProjectRequestDTO(
    string Name,
    string ImgPath,
    ICollection<int> Jalons,
    ICollection<int> Metiers
);