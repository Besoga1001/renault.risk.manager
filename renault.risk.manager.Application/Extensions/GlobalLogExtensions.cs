using renault.risk.manager.Domain.Entities;
using renault.risk.manager.Domain.ResponseDTOs;

namespace renault.risk.manager.Application.Extensions;

public static class GlobalLogExtensions
{
    public static GlobalLogResponseDTO ToDto(this tb_global_log globalLogEntity) => new
    (
        globalLogEntity.log_id,
        globalLogEntity.log_entity_name,
        globalLogEntity.log_field_name,
        globalLogEntity.log_old_value,
        globalLogEntity.log_new_value,
        globalLogEntity.log_user_email,
        globalLogEntity.log_created_at
    );
}