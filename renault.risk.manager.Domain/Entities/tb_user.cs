using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace renault.risk.manager.Domain.Entities;

public class tb_user
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int usr_id { get; set; } 
    public string usr_name { get; set; } 
    public string usr_email { get; set; } 
    public DateTime usr_created_at { get; set; } 
    public DateTime? usr_updated_at { get; set; }
    public IEnumerable<tb_risk> TbRisk { get; set; }
}