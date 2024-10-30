using System.Text.Json.Serialization;
using renault.risk.manager.Domain.Enums;

namespace renault.risk.manager.Domain.ResponseDTOs;

public class RiskResponseDTO
{
    [JsonPropertyName("rskId")]
    public int Id { get; set; }
    [JsonPropertyName("rskDescription")]
    public string Description { get; set; }
    [JsonPropertyName("rskType")]
    public RiskTypesEnum Type { get; set; }
    [JsonPropertyName("rskProbability")]
    public RiskFieldLevelsEnum Probability { get; set; }
    [JsonPropertyName("rskResponsibleArea")]
    public RiskResponsibleAreasEnum ResponsibleArea { get; set; }
    [JsonPropertyName("rskClassification")]
    public RiskClassificationLevelsEnum Classification { get; set; }
    [JsonPropertyName("rskProjectId")]
    public int ProjectId { get; set; } // FK
    [JsonPropertyName("rskAlertDate")]
    public DateTime AlertDate { get; set; }
    [JsonPropertyName("rskImpact")]
    public RiskFieldLevelsEnum Impact { get; set; }
    [JsonPropertyName("rskPlant")]
    public RiskPlantsEnum Plant { get; set; }
    [JsonPropertyName("rskConsequence")]
    public string Consequence { get; set; }
    [JsonPropertyName("rskJalon")]
    public JalonsEnum Jalon { get; set; }
    [JsonPropertyName("rskMetier")]
    public MetiersEnum Metier { get; set; }
    [JsonPropertyName("rskStatus")]
    public RiskStatusEnum Status { get; set; }
    [JsonPropertyName("rskSolutionId")]
    public int SolutionId { get; set; }
    [JsonPropertyName("rskUserId")]
    public int UserId { get; set; }
    [JsonPropertyName("rskCreatedAt")]
    public DateTime CreatedAt { get; set; }
    [JsonPropertyName("rskUpdatedAt")]
    public DateTime UpdatedAt { get; set; }
}