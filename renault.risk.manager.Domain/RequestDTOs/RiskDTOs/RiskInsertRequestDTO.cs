using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using renault.risk.manager.Domain.Enums;

namespace renault.risk.manager.Domain.RequestDTOs;

public class RiskInsertRequestDTO
{
    [JsonPropertyName("rskDescription")]
    [Required]
    public string Description { get; set; }
    [JsonPropertyName("rskType")]
    [Required]
    public RiskTypesEnum Type { get; set; }
    [JsonPropertyName("rskProbability")]
    [Required]
    public RiskFieldLevelsEnum Probability { get; set; }
    [JsonPropertyName("rskResponsibleArea")]
    [Required]
    public RiskResponsibleAreasEnum ResponsibleArea { get; set; }
    [JsonPropertyName("rskClassification")]
    [Required]
    public RiskClassificationLevelsEnum Classification { get; set; }
    [JsonPropertyName("rskProjectId")]
    [Required]
    public int ProjectId { get; set; } // FK
    [JsonPropertyName("rskAlertDate")]
    [Required]
    public DateTime AlertDate { get; set; }
    [JsonPropertyName("rskImpact")]
    [Required]
    public RiskFieldLevelsEnum Impact { get; set; }
    [JsonPropertyName("rskPlant")]
    [Required]
    public RiskPlantsEnum Plant { get; set; }
    [JsonPropertyName("rskConsequence")]
    [Required]
    public string Consequence { get; set; }
    [JsonPropertyName("rskJalon")]
    [Required]
    public JalonsEnum Jalon { get; set; }
    [JsonPropertyName("rskMetier")]
    [Required]
    public MetiersEnum Metier { get; set; }
    [JsonPropertyName("rskUserId")]
    [Required]
    public int UserId { get; set; }
}