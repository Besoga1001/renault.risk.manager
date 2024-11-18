using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace renault.risk.manager.Domain.Entities;

public class tb_global_log
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int log_id { get; set; }
    public required string log_entity_name { get; set; }
    public required string log_field_name { get; set; }
    public required string log_old_value { get; set; }
    public required string log_new_value { get; set; }
    public required string log_user_email { get; set; }
    public DateTime log_created_at { get; set; }
}

