using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace renault.risk.manager.Domain.Entities;

public class tb_risk_log
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int rkl_id { get; set; }
    public required string rkl_field_name { get; set; }
    public required string rkl_old_value { get; set; }
    public required string rkl_new_value { get; set; }
    public DateTime rsk_created_at { get; set; }
    public int rkl_user_id { get; set; }
    [ForeignKey("rkl_user_id")]
    public virtual tb_user TbUser { get; set; }

    public tb_risk_log(
        string rklFieldName,
        string rklOldValue,
        string rklNewValue,
        DateTime rskCreatedAt,
        int rklUserId)
    {
        rkl_field_name = rklFieldName;
        rkl_old_value = rklOldValue;
        rkl_new_value = rklNewValue;
        rsk_created_at = rskCreatedAt;
        rkl_user_id = rklUserId;
    }
}

