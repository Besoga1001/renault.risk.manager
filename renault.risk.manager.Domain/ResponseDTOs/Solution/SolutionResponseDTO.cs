using System.Text.Json.Serialization;

namespace renault.risk.manager.Domain.ResponseDTOs;

public class SolutionResponseDTO
{
    [JsonPropertyName("sln_id")]
    public int Id { get; set; }
    [JsonPropertyName("sln_strategy")]
    public string Strategy { get; set; }
    [JsonPropertyName("sln_residual_probability")]
    public string ResidualProbability { get; set; }
    [JsonPropertyName("sln_residual_impact")]
    public string ResidualImpact { get; set; }
    [JsonPropertyName("sln_action_validation")]
    public string ActionValidation { get; set; }
    [JsonPropertyName("sln_risk_validation")]
    public string RiskValidation { get; set; }
    [JsonPropertyName("sln_alert_date")]
    public DateTime AlertDate { get; set; }
    [JsonPropertyName("sln_captalization")]
    public bool Captalization { get; set; }
    [JsonPropertyName("sln_user_pilot_id")]
    public int UserPilotId { get; set; }
    [JsonPropertyName("sln_start_action_plan_date")]
    public DateTime StartActionPlanDate { get; set; }
    [JsonPropertyName("sln_action")]
    public string Action { get; set; }
    [JsonPropertyName("sln_observation")]
    public string Observation { get; set; }
    [JsonPropertyName("sln_resolution_date")]
    public DateTime ResolutionDate { get; set; }
}