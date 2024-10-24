using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace renault.risk.manager.Domain.Entities;

public class tb_solution
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int sln_id { get; set; }
    public string sln_strategy { get; set; }
    public string sln_residual_probability { get; set; }
    public string sln_residual_impact { get; set; }
    public string sln_action_validation { get; set; }
    public string sln_risk_validation { get; set; }
    public DateTime sln_alert_date { get; set; }
    public bool sln_captalization { get; set; }
    public int sln_user_pilot_id { get; set; } // FK
    public DateTime sln_start_action_plan_date { get; set; }
    public string sln_action { get; set; }
    public string sln_observation { get; set; }
    public DateTime sln_resolution_date { get; set; }
    public DateTime sln_created_at { get; set; }
    public DateTime sln_updated_at { get; set; }
    [ForeignKey("rsk_id")]
    public int sln_risk_id { get; set; }
    public virtual tb_risk TbRisk { get; set; }
}