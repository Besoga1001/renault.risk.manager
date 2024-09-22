using renault.risk.manager.Domain.Entities;
using renault.risk.manager.Domain.Enums;
using renault.risk.manager.Domain.RequestDTOs;
using renault.risk.manager.Domain.ResponseDTOs;

namespace renault.risk.manager.Application.Extensions;

public static class ProjectExtensions
{

    public static tb_project ToEntity(this ProjectRequestDTO projectRequestDto) => new tb_project()
    {
        pjc_name = projectRequestDto.name,
        pjc_img_path = projectRequestDto.imgPath,
        pjc_jalons = projectRequestDto.jalons,
        pjc_metiers = projectRequestDto.metiers
    };

    public static ProjectResponseDTO ToDto(this tb_project projectEntity) => new
    (
        projectEntity.pjc_id,
        projectEntity.pjc_name,
        projectEntity.pjc_img_path,
        projectEntity.pjc_jalons.GetJalonsEnums(),
        projectEntity.pjc_metiers.GetMetiersEnums()
    );

    private static List<string> GetJalonsEnums(this IEnumerable<int> jalonsCodes)
    { 
        return jalonsCodes.Select(item => (JalonsEnum)item).Select(jalonsEnum => jalonsEnum.ToString()).ToList();
    }
    
    private static List<string> GetMetiersEnums(this IEnumerable<int> metiersCodes)
    {
        return metiersCodes.Select(item => (MetiersEnum)item).Select(metiersEnum => metiersEnum.ToString()).ToList();
    }

}