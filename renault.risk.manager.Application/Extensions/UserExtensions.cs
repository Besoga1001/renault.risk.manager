using renault.risk.manager.Domain.Entities;
using renault.risk.manager.Domain.RequestDTOs;
using renault.risk.manager.Domain.RequestDTOs.UserDTOs;

namespace renault.risk.manager.Application.Extensions;

public static class UserExtensions
{
    public static tb_user ToEntity(
        this UserInsertRequestDTO userInsertRequestDto,
        byte[] passwordHash,
        byte[] passwordSalt,
        List<tb_metier> metierEntities) => new()
    {
        usr_name = userInsertRequestDto.UsrName,
        usr_email = userInsertRequestDto.UsrEmail,
        usr_created_at = DateTime.Now,
        usr_password_hash = passwordHash,
        usr_password_salt = passwordSalt,
        TbMetiers = metierEntities
    };
}