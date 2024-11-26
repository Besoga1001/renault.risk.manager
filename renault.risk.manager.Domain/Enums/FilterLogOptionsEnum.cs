using System.ComponentModel.DataAnnotations;

namespace renault.risk.manager.Domain.Enums;

public enum FilterLogOptionsEnum
{
    [Display(Name = "Risco", Description = "tb_risk")]
    TbRisk = 1,

    [Display(Name = "Solução", Description = "tb_solution")]
    TbSolution = 2,

    [Display(Name = "Jalon", Description = "tb_jalon")]
    TbJalon = 3,

    [Display(Name = "Metier", Description = "tb_metier")]
    TbMetier = 4,

    [Display(Name = "Projeto", Description = "tb_project")]
    TbProject = 5,

    [Display(Name = "Usuário", Description = "tb_user")]
    TbUser = 6
}