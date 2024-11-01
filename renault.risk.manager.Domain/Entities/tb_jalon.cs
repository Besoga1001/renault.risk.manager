using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace renault.risk.manager.Domain.Entities;

public class tb_jalon
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int jal_id { get; set; }
    public required string jal_description { get; set; }
    public bool jal_status { get; set; }
    public DateTime jal_created_at { get; set; }
    public DateTime jal_updated_at { get; set; }
    public virtual ICollection<tb_project> TbProjects { get; set; } = new List<tb_project>();
}