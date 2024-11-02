namespace renault.risk.manager.Domain.ResponseDTOs;

public record JalonResponseDTO(int JalId, string JalName, bool JalStatus, DateTime JalCreatedAt, DateTime JalUpdatedAt)
{

}