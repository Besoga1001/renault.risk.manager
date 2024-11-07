using renault.risk.manager.Domain.Entities;
using renault.risk.manager.Domain.RequestDTOs;

namespace renault.risk.manager.Application.Extensions;

public static class UserExtensions
{
    public static tb_user ToEntity(this UserInsertRequestDTO userInsertRequestDto, List<tb_metier> metierEntities) =>
        new()
    {
        usr_name = userInsertRequestDto.UsrName,
        usr_email = userInsertRequestDto.UsrEmail,
        usr_created_at = DateTime.Now,
        TbMetiers = metierEntities
    };
}