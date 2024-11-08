using System.Text.Json.Serialization;
using renault.risk.manager.Domain.Enums;

namespace renault.risk.manager.Domain.RequestDTOs.RiskDTOs;

public class RiskUpdateRequestDTO
{
    [JsonPropertyName("rskDescription")]
    public string? Description { get; set; }
    [JsonPropertyName("rskType")]
    public RiskTypesEnum? Type { get; set; }
    [JsonPropertyName("rskProbability")]
    public RiskFieldLevelsEnum? Probability { get; set; }
    [JsonPropertyName("rskResponsibleArea")]
    public RiskResponsibleAreasEnum? ResponsibleArea { get; set; }
    [JsonPropertyName("rskClassification")]
    public RiskClassificationLevelsEnum? Classification { get; set; }
    [JsonPropertyName("rskProjectId")]
    public int? ProjectId { get; set; } // FK
    [JsonPropertyName("rskAlertDate")]
    public DateTime? AlertDate { get; set; }
    [JsonPropertyName("rskImpact")]
    public RiskFieldLevelsEnum? Impact { get; set; }
    [JsonPropertyName("rskPlant")]
    public RiskPlantsEnum? Plant { get; set; }
    [JsonPropertyName("rskConsequence")]
    public string? Consequence { get; set; }
    [JsonPropertyName("rskJalon")]
    public int? Jalon { get; set; }
    [JsonPropertyName("rskMetierId")]
    public int? Metier { get; set; }
    [JsonPropertyName("rskStatus")]
    public RiskStatusEnum? Status { get; set; }
    [JsonPropertyName("rskUserId")]
    public int? UserId { get; set; }
}