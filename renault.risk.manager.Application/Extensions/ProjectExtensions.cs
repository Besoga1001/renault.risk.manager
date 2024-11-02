using renault.risk.manager.Domain.Entities;
using renault.risk.manager.Domain.RequestDTOs;
using renault.risk.manager.Domain.ResponseDTOs;

namespace renault.risk.manager.Application.Extensions;

public static class ProjectExtensions
{

    public static tb_project ToEntity(this ProjectRequestDTO projectRequestDto) => new ()
    {
        pjc_name = projectRequestDto.Name,
        pjc_img_path = projectRequestDto.ImgPath
        // pjc_jalons = projectRequestDto.jalons,
        // pjc_metiers = projectRequestDto.metiers
    };

    public static ProjectResponseDTO ToDto(this tb_project projectEntity) => new
    (
        projectEntity.pjc_id,
        projectEntity.pjc_name,
        projectEntity.pjc_img_path,
        projectEntity.TbJalons.ToDictionary(p => p.jal_id, p => p.jal_description)
    );

}