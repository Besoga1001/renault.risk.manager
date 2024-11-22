namespace renault.risk.manager.Domain.ResponseDTOs;

public record AccessTokenResponseDTO(string UsrName, string AccessToken, DateTime GeneratedIn);