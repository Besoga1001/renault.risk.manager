using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using renault.risk.manager.Domain.Enums;

namespace renault.risk.manager.Domain.Entities;

public class tb_project
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int pjc_id { get; set; }
    public string pjc_name { get; set; }
    public string pjc_img_path { get; set; }
    public IEnumerable<JalonsEnum> pjc_jalons { get; set; }
    public IEnumerable<MetiersEnum> pjc_metiers { get; set; }
    public DateTime pjc_created_at { get; set; }
    public DateTime pjc_updated_at { get; set; }
    [InverseProperty("TbProject")]
    public virtual ICollection<tb_risk> TbRisks { get; set; } = new List<tb_risk>();
}