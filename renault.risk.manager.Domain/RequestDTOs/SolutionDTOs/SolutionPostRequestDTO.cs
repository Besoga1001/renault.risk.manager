using System.Text.Json.Serialization;

namespace renault.risk.manager.Domain.RequestDTOs;

public class SolutionRequestDTO
{
    [JsonPropertyName("slnStrategy")]
    public string Strategy { get; set; }
    [JsonPropertyName("slnResidualProbability")]
    public string ResidualProbability { get; set; }
    [JsonPropertyName("slnResidualImpact")]
    public string ResidualImpact { get; set; }
    [JsonPropertyName("slnActionValidation")]
    public string ActionValidation { get; set; }
    [JsonPropertyName("slnRiskValidation")]
    public string RiskValidation { get; set; }
    [JsonPropertyName("slnAlertDate")]
    public DateTime AlertDate { get; set; }
    [JsonPropertyName("slnCaptalization")]
    public bool Captalization { get; set; }
    [JsonPropertyName("slnUserPilotId")]
    public int UserPilotId { get; set; }
    [JsonPropertyName("slnStartActionPlanDate")]
    public DateTime StartActionPlanDate { get; set; }
    [JsonPropertyName("slnAction")]
    public string Action { get; set; }
    [JsonPropertyName("slnObservation")]
    public string Observation { get; set; }
    [JsonPropertyName("slnResolutionDate")]
    public DateTime ResolutionDate { get; set; }
    [JsonPropertyName("slnRiskId")]
    public int RiskId { get; set; }

}