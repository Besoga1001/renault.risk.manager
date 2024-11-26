using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace renault.risk.manager.Domain.Entities;

public class tb_metier
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int met_id { get; set; }
    public required string met_description { get; set; }
    public bool met_status { get; set; }
    public DateTime met_created_at { get; set; }
    public DateTime met_updated_at { get; set; }
    public virtual ICollection<tb_user> TbUsers { get; set; } = new List<tb_user>();
    public virtual ICollection<tb_risk> TbRisks { get; set; } = new List<tb_risk>();
}