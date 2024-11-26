using renault.risk.manager.Domain.Entities;
using renault.risk.manager.Domain.RequestDTOs;
using renault.risk.manager.Domain.RequestDTOs.MetierDTOs;
using renault.risk.manager.Domain.ResponseDTOs;

namespace renault.risk.manager.Application.Extensions;

public static class MetierExtensions
{
    public static tb_metier ToEntity(this MetierRequestDTO metierRequestDto) => new ()
    {
        met_description = metierRequestDto.MetDescription,
        met_status = true,
        met_created_at = DateTime.Now
    };

    public static MetierResponseDTO ToDto(this tb_metier metierEntity) => new
    (
        metierEntity.met_id,
        metierEntity.met_description,
        metierEntity.met_status,
        metierEntity.met_created_at,
        metierEntity.met_updated_at
    );

    public static void Mapper(this tb_metier metierEntity, MetierUpdateDTO metierUpdateDto)
    {
        if (metierUpdateDto.MetStatus != null)
            metierEntity.met_status = metierUpdateDto.MetStatus.Value;
        metierEntity.met_updated_at = DateTime.Now;
    }
}