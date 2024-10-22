using System.Text.Json.Serialization;

namespace renault.risk.manager.Domain.ResponseDTOs;

public class RiskResponseDTO
{
    [JsonPropertyName("rskId")]
    public int Id { get; set; }
    [JsonPropertyName("rskDescription")]
    public string Description { get; set; }
    [JsonPropertyName("rskType")]
    public string Type { get; set; }
    [JsonPropertyName("rskProbability")]
    public string Probability { get; set; }
    [JsonPropertyName("rskResponsibleArea")]
    public string ResponsibleArea { get; set; }
    [JsonPropertyName("rskClassification")]
    public string Classification { get; set; }
    [JsonPropertyName("rskProjectId")]
    public int ProjectId { get; set; } // FK
    [JsonPropertyName("rskAlertDate")]
    public DateTime AlertDate { get; set; }
    [JsonPropertyName("rskImpact")]
    public string Impact { get; set; }
    [JsonPropertyName("rskPlant")]
    public string Plant { get; set; }
    [JsonPropertyName("rskConsequence")]
    public string Consequence { get; set; }
    [JsonPropertyName("rskJalon")]
    public string Jalon { get; set; }
    [JsonPropertyName("rskMetier")]
    public string Metier { get; set; }
    [JsonPropertyName("rskSolutionId")]
    public int SolutionId { get; set; }
    [JsonPropertyName("rskUserId")]
    public int UserId { get; set; }
    [JsonPropertyName("rskCreatedAt")]
    public DateTime CreatedAt { get; set; }
    [JsonPropertyName("rskUpdatedAt")]
    public DateTime UpdatedAt { get; set; }
}