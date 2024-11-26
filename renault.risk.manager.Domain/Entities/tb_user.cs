using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace renault.risk.manager.Domain.Entities;

public class tb_user
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int usr_id { get; set; }
    public required string usr_name { get; set; }
    public required string usr_email { get; set; }
    public required byte[] usr_password_hash { get; set; }
    public required byte[] usr_password_salt { get; set; }
    public DateTime usr_created_at { get; set; }
    public DateTime? usr_updated_at { get; set; }
    public virtual ICollection<tb_metier> TbMetiers { get; set; } = new List<tb_metier>();
    public virtual ICollection<tb_risk> TbRisk { get; set; } = new List<tb_risk>();
    public virtual ICollection<tb_global_log> TbGlobalLogs { get; set; } = new List<tb_global_log>();
}