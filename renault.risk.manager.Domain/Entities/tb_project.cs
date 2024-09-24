namespace renault.risk.manager.Domain.Entities;

public class tb_project
{
    public int pjc_id { get; set; }
    public string pjc_name { get; set; }
    public string pjc_img_path { get; set; }
    public List<int> pjc_jalons { get; set; }
    public List<int> pjc_metiers { get; set; }
    public DateTime pjc_created_at { get; set; }
    public DateTime pjc_updated_at { get; set; }
}