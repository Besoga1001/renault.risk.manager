using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using renault.risk.manager.Domain.Enums;

namespace renault.risk.manager.Domain.Entities;

public class tb_risk //TODO "Add Enums Different Fields"
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int rsk_id { get; set; }
    public string rsk_description { get; set; }
    public RiskTypesEnum rsk_type { get; set; }
    public FieldLevelsEnum rsk_probability { get; set; }
    public RiskResponsibleAreasEnum rsk_responsible_area { get; set; }
    public RiskClassificationLevelsEnum rsk_classification { get; set; }
    public int rsk_project_id { get; set; }
    [ForeignKey("rsk_project_id")]
    public virtual tb_project TbProject { get; set; }
    public DateTime rsk_alert_date { get; set; }
    public FieldLevelsEnum rsk_impact { get; set; }
    public RiskPlantsEnum rsk_plant { get; set; }
    public string rsk_consequence { get; set; }
    public int rsk_jalon_id { get; set; }
    [ForeignKey("rsk_jalon_id")]
    public virtual tb_jalon TbJalon { get; set; }
    public int rsk_metier_id { get; set; }
    [ForeignKey("rsk_metier_id")]
    public virtual tb_metier TbMetier { get; set; }
    public RiskStatusEnum rsk_status { get; set; }
    public DateTime rsk_created_at { get; set; }
    public DateTime rsk_updated_at { get; set; }
    public int rsk_usr_id { get; set; }
    [ForeignKey("rsk_usr_id")]
    public virtual tb_user TbUser { get; set; }
    public virtual tb_solution? TbSolution { get; set; }
}