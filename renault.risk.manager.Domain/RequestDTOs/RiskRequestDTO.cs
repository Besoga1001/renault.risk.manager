using System.Text.Json.Serialization;

namespace renault.risk.manager.Domain.RequestDTOs;

public class RiskRequestDTO
{
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
    [JsonPropertyName("rskUserId")]
    public int UserId { get; set; }
}