using renault.risk.manager.Domain.Entities;
using renault.risk.manager.Domain.RequestDTOs;
using renault.risk.manager.Domain.ResponseDTOs;

namespace renault.risk.manager.Application.Extensions;

public static class ProjectExtensions
{

    public static tb_project ToEntity(this ProjectRequestDTO projectRequestDto, ICollection<tb_jalon> jalonEntities)
        => new ()
    {
        pjc_name = projectRequestDto.Name,
        pjc_img_path = projectRequestDto.ImgPath,
        pjc_status = true,
        pjc_created_at = DateTime.Now,
        TbJalons = jalonEntities
    };

    public static ProjectResponseDTO ToDto(this tb_project projectEntity) => new
    (
        projectEntity.pjc_id,
        projectEntity.pjc_name,
        projectEntity.pjc_img_path,
        projectEntity.pjc_status,
        projectEntity.TbJalons.ToDictionary(p => p.jal_id, p => p.jal_description)
    );

}