using System.Text.Json.Serialization;

namespace renault.risk.manager.Domain.ResponseDTOs.Home;

public record CardsHomeResponseDTO
{
    [JsonPropertyName("weeklyRisks")]
    public int WeeklyRisk { get; set; }
    [JsonPropertyName("resolvedMonthlyRisks")]
    public int ResolvedMonthlyRisks { get; set; }
    [JsonPropertyName("noResolvedMonthlyRisks")]
    public int NoResolvedMonthlyRisks { get; set; }
    [JsonPropertyName("totalCriticalRisks")]
    public int TotalCriticalRisks { get; set; }
}