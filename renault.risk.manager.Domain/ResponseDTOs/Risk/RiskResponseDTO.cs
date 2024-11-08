using System.Text.Json.Serialization;
using renault.risk.manager.Domain.Enums;

namespace renault.risk.manager.Domain.ResponseDTOs;

public class RiskResponseDTO
{
    [JsonPropertyName("rskId")]
    public int Id { get; set; }
    [JsonPropertyName("rskDescription")]
    public required string Description { get; set; }
    [JsonPropertyName("rskType")]
    public required string Type { get; set; }
    [JsonPropertyName("rskProbability")]
    public required string Probability { get; set; }
    [JsonPropertyName("rskResponsibleArea")]
    public required string ResponsibleArea { get; set; }
    [JsonPropertyName("rskClassification")]
    public required string Classification { get; set; }
    [JsonPropertyName("rskProjectId")]
    public int ProjectId { get; set; } // FK
    [JsonPropertyName("rskProjectDescription")]
    public required string ProjectDescription { get; set; }
    [JsonPropertyName("rskAlertDate")]
    public DateTime AlertDate { get; set; }
    [JsonPropertyName("rskImpact")]
    public required string Impact { get; set; }
    [JsonPropertyName("rskPlant")]
    public required string Plant { get; set; }
    [JsonPropertyName("rskConsequence")]
    public required string Consequence { get; set; }
    [JsonPropertyName("rskJalon")]
    public required string Jalon { get; set; }
    [JsonPropertyName("rskMetier")]
    public required string Metier { get; set; }
    [JsonPropertyName("rskStatus")]
    public required string Status { get; set; }
    [JsonPropertyName("rskSolutionId")]
    public int SolutionId { get; set; }
    [JsonPropertyName("rskUserId")]
    public int UserId { get; set; }
    [JsonPropertyName("rskCreatedAt")]
    public DateTime CreatedAt { get; set; }
    [JsonPropertyName("rskUpdatedAt")]
    public DateTime UpdatedAt { get; set; }
}