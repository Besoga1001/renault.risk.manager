using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using renault.risk.manager.Domain.Enums;

namespace renault.risk.manager.Domain.RequestDTOs;

public class RiskInsertRequestDTO
{
    [Required]
    [JsonPropertyName("rskDescription")]
    public string Description { get; set; }
    [Required]
    [JsonPropertyName("rskType")]
    public RiskTypesEnum Type { get; set; }
    [Required]
    [JsonPropertyName("rskProbability")]
    public FieldLevelsEnum Probability { get; set; }
    [Required]
    [JsonPropertyName("rskResponsibleArea")]
    public RiskResponsibleAreasEnum ResponsibleArea { get; set; }
    [Required]
    [JsonPropertyName("rskClassification")]
    public RiskClassificationLevelsEnum Classification { get; set; }
    [Required]
    [JsonPropertyName("rskProjectId")]
    public int ProjectId { get; set; } // FK
    [Required]
    [JsonPropertyName("rskAlertDate")]
    public DateTime AlertDate { get; set; }
    [Required]
    [JsonPropertyName("rskImpact")]
    public FieldLevelsEnum Impact { get; set; }
    [Required]
    [JsonPropertyName("rskPlant")]
    public RiskPlantsEnum Plant { get; set; }
    [Required]
    [JsonPropertyName("rskConsequence")]
    public string Consequence { get; set; }
    [Required]
    [JsonPropertyName("rskJalonId")]
    public int Jalon { get; set; }
    [Required]
    [JsonPropertyName("rskMetierId")]
    public int Metier { get; set; }
    [Required]
    [JsonPropertyName("rskUserId")]
    public int UserId { get; set; }
}