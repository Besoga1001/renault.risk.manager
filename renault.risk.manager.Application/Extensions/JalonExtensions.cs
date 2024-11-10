using renault.risk.manager.Domain.Entities;
using renault.risk.manager.Domain.RequestDTOs;
using renault.risk.manager.Domain.RequestDTOs.JalonDTOs;
using renault.risk.manager.Domain.ResponseDTOs;

namespace renault.risk.manager.Application.Extensions;

public static class JalonExtensions
{
    public static tb_jalon ToEntity(this JalonRequestDTO jalonRequestDto) => new ()
    {
        jal_description = jalonRequestDto.JalDescription,
        jal_status = true,
        jal_created_at = DateTime.Now
    };

    public static JalonResponseDTO ToDto(this tb_jalon jalonEntity) => new
    (
        jalonEntity.jal_id,
        jalonEntity.jal_description,
        jalonEntity.jal_status,
        jalonEntity.jal_created_at,
        jalonEntity.jal_updated_at
    );

    public static void Mapper(this tb_jalon jalonEntity, JalonUpdateDTO jalonUpdateDto)
    {
        if (jalonUpdateDto.JalStatus != null)
            jalonEntity.jal_status = jalonUpdateDto.JalStatus.Value;
        jalonEntity.jal_updated_at = DateTime.Now;
    }
}