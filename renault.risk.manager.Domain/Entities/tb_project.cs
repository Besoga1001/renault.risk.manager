using renault.risk.manager.Domain.Enums;

namespace renault.risk.manager.Domain.Entities;

public class tb_project
{
    public int pjc_id { get; set; }
    public string pjc_name { get; set; }
    public string pjc_img_path { get; set; }
    public IEnumerable<JalonsEnum> pjc_jalons { get; set; }
    public IEnumerable<MetiersEnum> pjc_metiers { get; set; }
}