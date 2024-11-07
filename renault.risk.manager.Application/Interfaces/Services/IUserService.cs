using renault.risk.manager.Domain.RequestDTOs;

namespace renault.risk.manager.Application.Interfaces.Services;

public interface IUserService
{
    Task InsertRangeAsync(List<UserInsertRequestDTO> userInsertRequestDtos);
}