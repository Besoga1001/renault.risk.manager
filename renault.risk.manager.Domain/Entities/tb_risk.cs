using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace renault.risk.manager.Domain.Entities;

public class tb_risk
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int rsk_id { get; set; }
    public string rsk_description { get; set; }
    public string rsk_type { get; set; }
    public string rsk_probability { get; set; }
    public string rsk_responsible_area { get; set; }
    public string rsk_classification { get; set; }
    public int rsk_project_id { get; set; }
    [ForeignKey("rsk_project_id")]
    public virtual tb_project TbProject { get; set; }
    public DateTime rsk_alert_date { get; set; }
    public string rsk_impact { get; set; }
    public string rsk_plant { get; set; }
    public string rsk_consequence { get; set; }
    public string rsk_jalon { get; set; }
    public string rsk_metier { get; set; }
    public DateTime rsk_created_at { get; set; }
    public DateTime rsk_updated_at { get; set; }
    public int rsk_usr_id { get; set; }
    [ForeignKey("rsk_usr_id")]
    public virtual tb_user TbUser { get; set; }
    public virtual tb_solution? TbSolution { get; set; }

}